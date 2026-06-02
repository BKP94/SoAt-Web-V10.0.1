/**
 * scTeller / sctelnewbma — สมัครสมาชิก
 * API: /api/scTeller/sctelnewbma
 *
 * Layout (width):
 *   index  = 100%  (full page)
 *   master = 80%   ของ index (คุมทุก section)
 *
 *   ┌─────────────────────────── master (80%) ──────────────────┐
 *   │  Header (flex:1, scroll ได้)                  │ Operate   │
 *   ├───────────────────────────────────────────────┤ (fixed w) │
 *   │  Tabs (flex:1)                                │           │
 *   └───────────────────────────────────────────────┴───────────┘
 */
import { useCallback, useEffect, useState } from 'react'
import Popup from 'devextreme-react/popup'
import TextBox from 'devextreme-react/text-box'
import Button from 'devextreme-react/button'
import notify from 'devextreme/ui/notify'
import { api } from '@/services/api'

import Header from './Header'
import Tabs   from './Tabs'
import Operate from './Operate'
import type {
  LookupsDto, ApplicationFormDto,
  AppAddressDto, AppWorkInfoDto,
  AppMemberReferDto, AppRecrieveGainDto,
  DsType, RawDistrict, RawSubdistrict,
} from './types'

// ── Layout constants ──────────────────────────────────────────────────────────
const MASTER_WIDTH  = '80%'   // ความกว้าง content area (index = 100%)

// ── Page Component ─────────────────────────────────────────────────────────────

export default function SctelnewbmaPage() {

  // ── State ──────────────────────────────────────────────────────────────────
  const [lookups,  setLookups]  = useState<LookupsDto | null>(null)
  const [loading,  setLoading]  = useState(true)
  const [saving,   setSaving]   = useState(false)
  const [openVisible, setOpenVisible] = useState(false)
  const [appNo,    setAppNo]    = useState('')
  const [mode,     setMode]     = useState<'new' | 'edit'>('new')

  const [form,          setForm]          = useState<ApplicationFormDto>({})
  const [addrCur,       setAddrCur]       = useState<AppAddressDto>({})
  const [addrHome,      setAddrHome]      = useState<AppAddressDto>({})
  const [addrWork,      setAddrWork]      = useState<AppAddressDto>({})
  const [workInfo,      setWorkInfo]      = useState<AppWorkInfoDto>({})
  const [shareMonthly,  setShareMonthly]  = useState<number | undefined>()
  const [memberRefers,  setMemberRefers]  = useState<AppMemberReferDto[]>([])
  const [recrieveGains, setRecrieveGains] = useState<AppRecrieveGainDto[]>([])

  // ── Load lookups ───────────────────────────────────────────────────────────
  useEffect(() => {
    api.get<LookupsDto>('/scTeller/sctelnewbma/lookups')
      .then(r => setLookups(r.data))
      .catch(() => notify('ไม่สามารถโหลดข้อมูล dropdown ได้', 'error', 3000))
      .finally(() => setLoading(false))
  }, [])

  // ── Operate: ใหม่ ─────────────────────────────────────────────────────────
  const handleNew = () => {
    setForm({ applyDate: new Date() })
    setAddrCur({}); setAddrHome({}); setAddrWork({})
    setWorkInfo({}); setShareMonthly(undefined)
    setMemberRefers([]); setRecrieveGains([])
    setAppNo(''); setMode('new')
  }

  // ── Operate: เปิดเอกสาร ───────────────────────────────────────────────────
  const handleOpen = () => setOpenVisible(true)

  const handleLoad = useCallback(() => {
    if (!appNo.trim()) return
    setLoading(true)
    api.get<ApplicationFormDto>(`/scTeller/sctelnewbma/${appNo.trim()}`)
      .then(r => {
        const d = r.data
        setForm(d)
        setAddrCur(d.addressCurrent  ?? {})
        setAddrHome(d.addressHome    ?? {})
        setAddrWork(d.addressWork    ?? {})
        setWorkInfo(d.workInfo       ?? {})
        setShareMonthly(d.shareMonthly)
        setMemberRefers(d.memberRefers   ?? [])
        setRecrieveGains(d.recrieveGains ?? [])
        setMode('edit')
        setOpenVisible(false)
        notify('โหลดข้อมูลสำเร็จ', 'success', 2000)
      })
      .catch(() => notify(`ไม่พบใบสมัคร ${appNo}`, 'error', 3000))
      .finally(() => setLoading(false))
  }, [appNo])

  // ── Operate: บันทึก ───────────────────────────────────────────────────────
  const handleSave = async () => {
    setSaving(true)
    const payload: ApplicationFormDto = {
      ...form,
      addressCurrent: addrCur,
      addressHome:    addrHome,
      addressWork:    addrWork,
      workInfo,
      shareMonthly,
      memberRefers,
      recrieveGains,
    }
    try {
      if (mode === 'new') {
        const res = await api.post<{ applicationFormNo: string; message: string }>('/scTeller/sctelnewbma', payload)
        setAppNo(res.data.applicationFormNo)
        setForm(prev => ({ ...prev, applicationFormNo: res.data.applicationFormNo }))
        setMode('edit')
        notify(`บันทึกสำเร็จ เลขที่ ${res.data.applicationFormNo}`, 'success', 4000)
      } else {
        await api.put(`/scTeller/sctelnewbma/${form.applicationFormNo}`, payload)
        notify('อัปเดตข้อมูลสำเร็จ', 'success', 3000)
      }
    } catch (err: unknown) {
      const msg = (err as { response?: { data?: { message?: string } } })?.response?.data?.message ?? 'เกิดข้อผิดพลาด'
      notify(msg, 'error', 4000)
    } finally {
      setSaving(false)
    }
  }

  // ── Operate: ยกเลิก ───────────────────────────────────────────────────────
  const handleCancel = () => handleNew()

  // ── Computed dropdown datasources ─────────────────────────────────────────
  const ds: DsType = {
    prenames:  lookups?.prenames.map(x         => ({ value: x.code, display: x.name ?? x.code })) ?? [],
    sexes:     lookups?.sexes.map(x            => ({ value: x.code, display: x.name ?? x.code })) ?? [],
    marr:      lookups?.marriageStatuses.map(x => ({ value: x.code, display: x.name ?? x.code })) ?? [],
    memTypes:  lookups?.memberTypes.map(x      => ({ value: x.code, display: `${x.code} - ${x.desc ?? ''}` })) ?? [],
    memGroups: lookups?.memberGroups.map(x     => ({ value: x.no,   display: `${x.no} - ${x.name ?? ''}` })) ?? [],
    elections: lookups?.electionGroups.map(x   => ({ value: x.code, display: `${x.code} : ${x.name ?? ''}` })) ?? [],
    natl:      lookups?.nationalities.map(x    => ({ value: x.code, display: x.description ?? x.code })) ?? [],
    blood:     lookups?.bloods.map(x           => ({ value: x.code, display: x.desc ?? x.code })) ?? [],
    provinces: lookups?.provinces.map(x        => ({ value: x.code, display: x.name ?? x.code })) ?? [],
    applTypes: lookups?.applicationTypes.map(x => ({ value: x.code, display: `${x.name ?? x.code} [${x.fee ?? 0} บาท]` })) ?? [],
    concerns:  lookups?.concerns.map(x         => ({ value: x.code, display: x.relatedNa ?? x.code })) ?? [],
    groupPos:  lookups?.groupPositions.map(x   => ({ value: x.code, display: x.description ?? x.code })) ?? [],
    positions: lookups?.positions.map(x        => ({ value: x.code, display: x.name ?? x.code })) ?? [],
  }

  // district/subdistrict สำหรับ cascade filter ใน AddressForm
  const allDistricts:    RawDistrict[]    = lookups?.districts.map(x    => ({ value: x.code, display: x.name ?? x.code, provinceCode: x.provinceCode }))    ?? []
  const allSubdistricts: RawSubdistrict[] = lookups?.subdistricts.map(x => ({ value: x.code, display: x.name ?? x.code, districtCode: x.districtCode })) ?? []

  if (loading && !lookups) {
    return <div style={{ padding: 32, color: '#64748b' }}>กำลังโหลดข้อมูล...</div>
  }

  // ── Render ─────────────────────────────────────────────────────────────────
  return (
    // index: 100% — full page container
    <div style={{ width: '100%', padding: '12px 16px' }}>

      {/* master: MASTER_WIDTH (80%) centered — คุมความกว้างของ Header / Tabs / Operate ทั้งหมด */}
      <div style={{ width: MASTER_WIDTH, margin: '0 auto', display: 'flex', gap: 10 }}>

        {/* ── Left: Header + Tabs ───────────────────────────────────────────── */}
        <div style={{ flex: 1, minWidth: 0, display: 'flex', flexDirection: 'column', gap: 10 }}>
          <Header
            form={form}               setForm={setForm}
            addrCur={addrCur}         setAddrCur={setAddrCur}
            addrHome={addrHome}       setAddrHome={setAddrHome}
            addrWork={addrWork}       setAddrWork={setAddrWork}
            workInfo={workInfo}       setWorkInfo={setWorkInfo}
            shareMonthly={shareMonthly}   setShareMonthly={setShareMonthly}
            memberRefers={memberRefers}   setMemberRefers={setMemberRefers}
            recrieveGains={recrieveGains} setRecrieveGains={setRecrieveGains}
            ds={ds}
            allDistricts={allDistricts}
            allSubdistricts={allSubdistricts}
          />
          <Tabs />
        </div>

        {/* ── Right: Operate ────────────────────────────────────────────────── */}
        <Operate
          onNew={handleNew}
          onOpen={handleOpen}
          onSave={handleSave}
          onCancel={handleCancel}
          saving={saving}
        />

      </div>{/* /master */}

      {/* ── Popup: เปิดเอกสาร (overlay — อยู่นอก master ได้) ───────────────── */}
      <Popup
        visible={openVisible}
        onHiding={() => setOpenVisible(false)}
        title="เปิดเอกสาร"
        width={340}
        height={140}
        showCloseButton
      >
        <div style={{ display: 'flex', gap: 8, padding: '12px 16px', alignItems: 'flex-end' }}>
          <div style={{ flex: 1 }}>
            <div style={{ fontSize: 12, color: '#64748b', marginBottom: 4 }}>เลขที่ใบสมัคร</div>
            <TextBox
              value={appNo}
              onValueChanged={e => setAppNo(e.value ?? '')}
              placeholder="เช่น 2600001"
              onEnterKey={handleLoad}
            />
          </div>
          <Button text="เปิด"   type="default" stylingMode="contained"
                  onClick={handleLoad} disabled={!appNo.trim() || loading} />
          <Button text="ยกเลิก" onClick={() => setOpenVisible(false)} />
        </div>
      </Popup>

    </div>
  )
}
