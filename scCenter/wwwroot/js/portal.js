// localStorage helpers สำหรับ portal — favorites (ปักหมุด) + recent (ใช้ล่าสุด)
// per-browser, ไม่แตะ DB
window.soatPortal = {
    _read(key) { try { return JSON.parse(localStorage.getItem(key) || '[]'); } catch { return []; } },

    getFavorites() { return this._read('soat.favorites'); },

    toggleFavorite(app) {
        const f = this.getFavorites();
        const i = f.indexOf(app);
        if (i >= 0) f.splice(i, 1); else f.unshift(app);
        localStorage.setItem('soat.favorites', JSON.stringify(f));
        return f;
    },

    getRecent() { return this._read('soat.recent'); },

    // เรียกจาก onclick ของการ์ดก่อน navigate ออกไป module
    pushRecent(app) {
        let r = this.getRecent().filter(x => x !== app);
        r.unshift(app);
        r = r.slice(0, 6);
        localStorage.setItem('soat.recent', JSON.stringify(r));
    }
};
