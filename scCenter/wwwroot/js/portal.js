// localStorage helpers สำหรับ portal — favorites (ปักหมุด) per-browser, ไม่แตะ DB
// storage ใช้ไม่ได้ (private mode / ถูกบล็อก) → ปักหมุดยังทำงานในหน้านั้น แค่ไม่จำข้ามครั้ง
window.soatPortal = {
    _read(key) {
        try { const v = JSON.parse(localStorage.getItem(key) || '[]'); return Array.isArray(v) ? v : []; }
        catch { return []; }
    },

    _favs: null,   // สำเนาในหน่วยความจำ — เป็นตัวจริงเมื่อ storage เขียนไม่ได้
    getFavorites() {
        if (this._favs === null) { this._favs = this._read('soat.favorites'); this._mirrorFavs(); }
        return this._favs;
    },

    // สำเนาลง cookie ให้ server วาดกลุ่มปักหมุดตอน prerender ได้ (ไม่เด้งแทรกหลังหน้าโหลด)
    _mirrorFavs() {
        document.cookie = 'soat.favs=' + encodeURIComponent(this._favs.join(',')) +
                          '; path=/; max-age=31536000; SameSite=Lax';
    },

    toggleFavorite(app) {
        const f = this.getFavorites();
        const i = f.indexOf(app);
        if (i >= 0) f.splice(i, 1); else f.unshift(app);
        try { localStorage.setItem('soat.favorites', JSON.stringify(f)); } catch { }
        this._mirrorFavs();
        return f;
    },

    // ── modal focus management (login / ลืมรหัสผ่าน) ─────────────────────
    // เปิด: พื้นหลังทุกชั้นเป็น inert + Tab วนอยู่ใน dialog + focus ช่องแรก
    // ปิด: ปลด inert แล้วคืน focus ให้ปุ่มที่เปิด dialog (stack รองรับ dialog ซ้อน)
    _modals: [],
    // ห้าม inert: UI ของ Blazor เอง (reconnect / error) ต้องกดได้แม้ dialog เปิดอยู่
    _keepLive: '#components-reconnect-modal, #blazor-error-ui',
    _returnFallback: '.pt-login',

    _focusables(root) {
        return [...root.querySelectorAll(
            'a[href], button:not([disabled]), input:not([disabled]):not([type=hidden]), ' +
            'select:not([disabled]), textarea:not([disabled]), [tabindex]:not([tabindex="-1"])')]
            .filter(el => el.getClientRects().length > 0);
    },

    // ช่วง prerender ผู้ใช้พิมพ์ในฟอร์ม login ได้ก่อน circuit ต่อ — แต่ Blazor แทน DOM ใหม่ทั้งชุด
    // ค่าที่พิมพ์ + ช่องที่ focus อยู่จะหาย → จดไว้ในหน่วยความจำ แล้วคืนให้ตอน openModal ครั้งแรก
    _draft: {},
    _draftFocus: null,
    _live: false,

    _keepDraft(e) {
        if (this._live || !e.target.closest?.('.lg-dialog') || !e.target.id) return;
        this._draftFocus = e.target.id;
        if (e.type !== 'focusin') this._draft[e.target.id] = e.target.value;
    },

    _restoreDraft() {
        for (const [id, v] of Object.entries(this._draft)) {
            const el = document.getElementById(id);
            if (el && !el.value) el.value = v;
        }
        const id = this._draftFocus;
        this._draft = {};
        this._draftFocus = null;
        return id;
    },

    openModal(dialogId, focusId) {
        const dlg = document.getElementById(dialogId);
        const overlay = dlg?.closest('.lg-overlay');
        if (!overlay) return;
        const first = !this._live;
        this._live = true;
        const draftFocus = first ? this._restoreDraft() : null;

        const prev = document.activeElement;
        const inerted = [];
        for (let node = overlay; node && node !== document.body; node = node.parentElement) {
            for (const sib of node.parentElement.children) {
                if (sib !== node && !sib.inert && sib.tagName !== 'SCRIPT' && !sib.matches(this._keepLive)) {
                    sib.inert = true;
                    inerted.push(sib);
                }
            }
        }

        const onKey = e => {
            if (e.key !== 'Tab') return;
            const f = this._focusables(dlg);
            if (f.length === 0) return;
            const first = f[0], last = f[f.length - 1];
            if (e.shiftKey && document.activeElement === first) { last.focus(); e.preventDefault(); }
            else if (!e.shiftKey && document.activeElement === last) { first.focus(); e.preventDefault(); }
        };
        dlg.addEventListener('keydown', onKey);
        this._modals.push({ dlg, prev, inerted, onKey });

        (document.getElementById(draftFocus ?? focusId) ?? this._focusables(dlg)[0])?.focus();
    },

    closeModal() {
        const m = this._modals.pop();
        if (!m) return;
        m.dlg.removeEventListener('keydown', m.onKey);
        m.inerted.forEach(el => el.inert = false);
        // dialog ที่เปิดจาก query (?login=1 / module เด้งมา) ไม่มีปุ่มเปิด → คืน focus ให้ปุ่ม "เข้าสู่ระบบ" แทน body
        const back = m.prev?.isConnected && m.prev !== document.body ? m.prev
                   : this._modals.length === 0 ? document.querySelector(this._returnFallback) : null;
        back?.focus();
    },

    // native POST (login/logout): กันกดซ้ำระหว่างรอ server ตอบ
    lockSubmit(form) {
        form.querySelectorAll('button[type=submit]').forEach(b => {
            b.disabled = true;
            b.setAttribute('aria-busy', 'true');
            b.dataset.locked = '';
        });
    }
};

['input', 'change', 'focusin'].forEach(t =>
    document.addEventListener(t, e => soatPortal._keepDraft(e), true));

// กลับมาด้วยปุ่ม Back (bfcache) → ปลดล็อกปุ่ม submit ที่ค้าง disabled
window.addEventListener('pageshow', e => {
    if (!e.persisted) return;
    document.querySelectorAll('button[data-locked]').forEach(b => {
        b.disabled = false;
        b.removeAttribute('aria-busy');
        delete b.dataset.locked;
    });
});
