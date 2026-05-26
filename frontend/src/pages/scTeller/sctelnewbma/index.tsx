/**
 * scTeller / sctelnewbma — สมัครสมาชิก
 * API: /api/scTeller/sctelnewbma
 */
import { useCallback, useEffect, useRef, useState } from 'react'
import Form, { Item, GroupItem, RequiredRule } from 'devextreme-react/form'
import TabPanel from 'devextreme-react/tab-panel'
import Button from 'devextreme-react/button'
import TextBox from 'devextreme-react/text-box'
import DataGrid, { Column, Editing, Pager, Paging } from 'devextreme-react/data-grid'
import notify from 'devextreme/ui/notify'
import { api } from '@/services/api'

// ── Types ─────────────────────────────────────────────────────────────────────

interface PrenameDto       { code: string; name?: string; sex?: string; marriageStatus?: string }
interface MemberTypeDto    { code: string; desc?: string; maximunShare?: number; notSalary?: string; mprocApart?: string }
interface MemberGroupDto   { no: string; name?: string; memTypeDefault?: string; notSal?: string; ingoreDropshrRule?: string }
interface ElectionGroupDto { code: string; name?: string; zone?: string }
interface NationalityDto   { code: string; description?: string }
interface MarriageStatusDto{ code: string; name?: string }
interface BloodDto         { code: string; desc?: string }
interface ProvinceDto      { code: string; name?: string }
interface DistrictDto      { code: string; name?: string; provinceCode?: string; postCode?: string }
interface SubdistrictDto   { code: string; name?: string; districtCode?: string }
interface ApplicationTypeDto { code: string; name?: string; fee?: number; memTypeCode?: string }
interface ConcernDto       { code: string; relatedNa?: string }
interface GroupPositionDto { code: string; description?: string; sortOrder?: number }
interface PositionDto      { code: string; name?: string; sortOrder?: number }
interface CoopConfigDto    { coopNo: string; countResign?: number; autoApproveNewmem?: string; memTypeOngroup?: string }

interface LookupsDto {
  prenames:         PrenameDto[]
  memberTypes:      MemberTypeDto[]
  memberGroups:     MemberGroupDto[]
  electionGroups:   ElectionGroupDto[]
  nationalities:    NationalityDto[]
  marriageStatuses: MarriageStatusDto[]
  bloods:           BloodDto[]
  provinces:        ProvinceDto[]
  districts:        DistrictDto[]
  subdistricts:     SubdistrictDto[]
  applicationTypes: ApplicationTypeDto[]
  concerns:         ConcernDto[]
  groupPositions:   GroupPositionDto[]
  positions:        PositionDto[]
  coopConfig?:      CoopConfigDto
}

interface AppAddressDto {
  addressType?: string
  addressNo?: string; moo?: string; mooban?: string; soi?: string; road?: string
  tambol?: string; districtCode?: string; provinceCode?: string; postcode?: string; telephone?: string
}

interface AppWorkInfoDto {
  workingDate?: string; salaryId?: string; groupOther?: string
  groupPosition?: string; positionLong?: string; levelCode?: string; salaryRateCode?: string
  salaryAmount?: number; academicSalary?: number; remunerationAmount?: number; salaryReal?: number
  endingcontractDate?: string
}

interface AppMemberReferDto { seqNo: number; membershipNo?: string; memberName?: string; concernCode?: string }
interface AppRecrieveGainDto {
  seqNo: number; prenameCode?: string; gainName?: string; gainSurname?: string
  concernCode?: string; wefType?: string; gainPercent?: number; gainIdCard?: string
  bookDate?: string; orderNumber?: number; gainAddress?: string; gainTelephone?: string; gainDesc?: string
}

interface ApplicationFormDto {
  applicationFormNo?: string; applyDate?: string
  prenameCode?: string; memberName?: string; memberSurname?: string
  memberGroupNo?: string; memType?: string; dateOfBirth?: string; sex?: string
  applTypeCode?: string; humId?: string; marriageStatus?: string
  nationalityCode?: string; bloodCode?: string; mobileNumber?: string; email?: string; remark?: string
  approveStatus?: string; cancelStatus?: string
  prenameEng?: string; nameEng?: string; surnameEng?: string
  idCardDate?: string; idCardEnddate?: string; idCardNumber?: string; idCardOrganize?: string
  electionGroup?: string
  addressCurrent?: AppAddressDto; addressHome?: AppAddressDto; addressWork?: AppAddressDto
  workInfo?: AppWorkInfoDto; shareMonthly?: number
  memberRefers?: AppMemberReferDto[]; recrieveGains?: AppRecrieveGainDto[]
  pictureBase64?: string; signatureBase64?: string
}


// ── Page Component ────────────────────────────────────────────────────────────

export default function SctelnewbmaPage() {
  const [lookups, setLookups] = useState<LookupsDto | null>(null)
  const [loading, setLoading] = useState(true)
  const [saving,  setSaving]  = useState(false)
  const [appNo,   setAppNo]   = useState('')
  const [mode,    setMode]    = useState<'new' | 'edit'>('new')

  // form data
  const [form, setForm]     = useState<ApplicationFormDto>({})
  const [addrCur, setAddrCur] = useState<AppAddressDto>({})
  const [addrHome, setAddrHome] = useState<AppAddressDto>({})
  const [addrWork, setAddrWork] = useState<AppAddressDto>({})
  const [workInfo, setWorkInfo] = useState<AppWorkInfoDto>({})
  const [shareMonthly, setShareMonthly] = useState<number | undefined>()
  const [memberRefers, setMemberRefers] = useState<AppMemberReferDto[]>([])
  const [recrieveGains, setRecrieveGains] = useState<AppRecrieveGainDto[]>([])

  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const formRef = useRef<any>(null)

  // ── Load lookups once ───────────────────────────────────────────────────────
  useEffect(() => {
    api.get<LookupsDto>('/scTeller/sctelnewbma/lookups')
      .then(r => setLookups(r.data))
      .catch(() => notify('ไม่สามารถโหลดข้อมูล dropdown ได้', 'error', 3000))
      .finally(() => setLoading(false))
  }, [])

  // ── Load existing application ───────────────────────────────────────────────
  const handleLoad = useCallback(() => {
    if (!appNo.trim()) return
    setLoading(true)
    api.get<ApplicationFormDto>(`/scTeller/sctelnewbma/${appNo.trim()}`)
      .then(r => {
        const d = r.data
        setForm(d)
        setAddrCur(d.addressCurrent ?? {})
        setAddrHome(d.addressHome ?? {})
        setAddrWork(d.addressWork ?? {})
        setWorkInfo(d.workInfo ?? {})
        setShareMonthly(d.shareMonthly)
        setMemberRefers(d.memberRefers ?? [])
        setRecrieveGains(d.recrieveGains ?? [])
        setMode('edit')
        notify('โหลดข้อมูลสำเร็จ', 'success', 2000)
      })
      .catch(() => notify(`ไม่พบใบสมัคร ${appNo}`, 'error', 3000))
      .finally(() => setLoading(false))
  }, [appNo])

  // ── New form ────────────────────────────────────────────────────────────────
  const handleNew = () => {
    setForm({ applyDate: new Date().toISOString().split('T')[0] })
    setAddrCur({}); setAddrHome({}); setAddrWork({})
    setWorkInfo({}); setShareMonthly(undefined)
    setMemberRefers([]); setRecrieveGains([])
    setAppNo('')
    setMode('new')
  }

  // ── Save ────────────────────────────────────────────────────────────────────
  const handleSave = async () => {
    const valid = formRef.current?.instance.validate()
    if (valid && !valid.isValid) {
      notify('กรุณากรอกข้อมูลให้ครบถ้วน', 'warning', 3000)
      return
    }
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

  // ── Derived datasources ─────────────────────────────────────────────────────
  const ds = {
    prenames:    lookups?.prenames.map(x => ({ value: x.code, display: x.name ?? x.code })) ?? [],
    memTypes:    lookups?.memberTypes.map(x => ({ value: x.code, display: `${x.code} - ${x.desc ?? ''}` })) ?? [],
    memGroups:   lookups?.memberGroups.map(x => ({ value: x.no, display: `${x.no} - ${x.name ?? ''}` })) ?? [],
    elections:   lookups?.electionGroups.map(x => ({ value: x.code, display: `${x.code} : ${x.name ?? ''}` })) ?? [],
    natl:        lookups?.nationalities.map(x => ({ value: x.code, display: x.description ?? x.code })) ?? [],
    marr:        lookups?.marriageStatuses.map(x => ({ value: x.code, display: x.name ?? x.code })) ?? [],
    blood:       lookups?.bloods.map(x => ({ value: x.code, display: x.desc ?? x.code })) ?? [],
    provinces:   lookups?.provinces.map(x => ({ value: x.code, display: x.name ?? x.code })) ?? [],
    applTypes:   lookups?.applicationTypes.map(x => ({ value: x.code, display: `${x.name ?? x.code} [${x.fee ?? 0} บาท]` })) ?? [],
    concerns:    lookups?.concerns.map(x => ({ value: x.code, display: x.relatedNa ?? x.code })) ?? [],
    groupPos:    lookups?.groupPositions.map(x => ({ value: x.code, display: x.description ?? x.code })) ?? [],
    positions:   lookups?.positions.map(x => ({ value: x.code, display: x.name ?? x.code })) ?? [],
  }

  // raw district/subdistrict with FK fields for cascade filtering inside AddressForm
  const rawDistricts: RawDistrict[]    = lookups?.districts.map(x => ({ value: x.code, display: x.name ?? x.code, provinceCode: x.provinceCode ?? undefined })) ?? []
  const rawSubdistricts: RawSubdistrict[] = lookups?.subdistricts.map(x => ({ value: x.code, display: x.name ?? x.code, districtCode: x.districtCode ?? undefined })) ?? []

  // ── common field options ─────────────────────────────────────────────────────
  const selectOpts = (data: { value: string; display: string }[]) => ({
    dataSource:      data,
    valueExpr:       'value',
    displayExpr:     'display',
    searchEnabled:   true,
    showClearButton: true,
  })

  if (loading && !lookups) {
    return <div style={{ padding: 32, color: '#64748b' }}>กำลังโหลดข้อมูล...</div>
  }

  // ── Tabs ─────────────────────────────────────────────────────────────────────
  const tabs = [
    { title: 'ข้อมูลทั่วไป' },
    { title: 'ที่อยู่' },
    { title: 'ข้อมูลการทำงาน' },
    { title: 'หุ้น / อ้างอิง' },
    { title: 'ผู้รับผลประโยชน์' },
  ]

  return (
    <div style={{ padding: '12px 16px', fontFamily: 'Sarabun, sans-serif' }}>
      {/* ── toolbar ─────────────────────────────────────────────────────────── */}
      <div style={{ display: 'flex', alignItems: 'center', gap: 8, marginBottom: 12,
                    borderBottom: '2px solid #1a3760', paddingBottom: 10 }}>
        <span style={{ fontWeight: 700, fontSize: 16, color: '#1a3760', flex: 1 }}>
          สมัครสมาชิก
          {form.applicationFormNo && (
            <span style={{ marginLeft: 12, fontWeight: 400, fontSize: 13, color: '#64748b' }}>
              เลขที่ {form.applicationFormNo}
              {form.approveStatus === '2' && <span style={{ marginLeft: 8, color: '#f59e0b', fontWeight: 600 }}>รออนุมัติ</span>}
              {form.approveStatus === '1' && <span style={{ marginLeft: 8, color: '#22c55e', fontWeight: 600 }}>อนุมัติแล้ว</span>}
            </span>
          )}
        </span>

        {/* Load by appNo */}
        <TextBox
          value={appNo}
          onValueChanged={e => setAppNo(e.value ?? '')}
          placeholder="เลขที่ใบสมัคร"
          width={150}
          onEnterKey={handleLoad}
        />
        <Button text="โหลด" onClick={handleLoad} disabled={!appNo.trim()} />
        <Button text="ใหม่"  onClick={handleNew}  type="normal" />
        <Button text={saving ? 'กำลังบันทึก...' : 'บันทึก'}
                onClick={handleSave}
                type="default"
                disabled={saving}
                stylingMode="contained" />
      </div>

      {/* ── tab panel ────────────────────────────────────────────────────────── */}
      <TabPanel
        dataSource={tabs}
        itemTitleRender={(item: { title: string }) => item.title}
        animationEnabled={false}
        itemRender={(item: { title: string }) => {
          // ── Tab 1: ข้อมูลทั่วไป ─────────────────────────────────────────────
          if (item.title === 'ข้อมูลทั่วไป') return (
            <div style={{ padding: '12px 0' }}>
              <Form formData={form} ref={formRef} labelLocation="top" colCount={4}
                    onFieldDataChanged={e => setForm(prev => ({ ...prev, [e.dataField!]: e.value }))}>
                <GroupItem caption="ข้อมูลใบสมัคร" colCount={4} colSpan={4}>
                  <Item dataField="applicationFormNo" label={{ text: 'เลขที่ใบสมัคร' }} editorOptions={{ readOnly: true, placeholder: '(สร้างอัตโนมัติ)' }} />
                  <Item dataField="applyDate"        label={{ text: 'วันที่สมัคร' }}    editorType="dxDateBox" editorOptions={{ displayFormat: 'dd/MM/yyyy', type: 'date' }} />
                  <Item dataField="applTypeCode"     label={{ text: 'ประเภทการสมัคร' }}  editorType="dxSelectBox" editorOptions={selectOpts(ds.applTypes)}>
                    <RequiredRule message="กรุณาเลือกประเภทการสมัคร" />
                  </Item>
                  <Item dataField="approveStatus"    label={{ text: 'สถานะ' }}           editorOptions={{ readOnly: true }} />
                </GroupItem>

                <GroupItem caption="ชื่อ-นามสกุล" colCount={4} colSpan={4}>
                  <Item dataField="prenameCode"  label={{ text: 'คำนำหน้า' }}   editorType="dxSelectBox" editorOptions={selectOpts(ds.prenames)}>
                    <RequiredRule message="กรุณาเลือกคำนำหน้า" />
                  </Item>
                  <Item dataField="memberName"   label={{ text: 'ชื่อ' }}>
                    <RequiredRule message="กรุณากรอกชื่อ" />
                  </Item>
                  <Item dataField="memberSurname" label={{ text: 'นามสกุล' }}>
                    <RequiredRule message="กรุณากรอกนามสกุล" />
                  </Item>
                  <Item dataField="sex"          label={{ text: 'เพศ' }}         editorType="dxSelectBox"
                        editorOptions={selectOpts([{ value: 'M', display: 'ชาย' }, { value: 'F', display: 'หญิง' }])} />
                </GroupItem>

                <GroupItem caption="ชื่อภาษาอังกฤษ" colCount={3} colSpan={4}>
                  <Item dataField="prenameEng"  label={{ text: 'Prefix' }} />
                  <Item dataField="nameEng"     label={{ text: 'Name' }} />
                  <Item dataField="surnameEng"  label={{ text: 'Surname' }} />
                </GroupItem>

                <GroupItem caption="ข้อมูลส่วนตัว" colCount={4} colSpan={4}>
                  <Item dataField="dateOfBirth"    label={{ text: 'วันเกิด' }}      editorType="dxDateBox" editorOptions={{ displayFormat: 'dd/MM/yyyy', type: 'date' }} />
                  <Item dataField="marriageStatus" label={{ text: 'สถานภาพสมรส' }} editorType="dxSelectBox" editorOptions={selectOpts(ds.marr)} />
                  <Item dataField="nationalityCode"label={{ text: 'สัญชาติ' }}      editorType="dxSelectBox" editorOptions={selectOpts(ds.natl)} />
                  <Item dataField="bloodCode"      label={{ text: 'หมู่เลือด' }}     editorType="dxSelectBox" editorOptions={selectOpts(ds.blood)} />
                  <Item dataField="mobileNumber"   label={{ text: 'โทรศัพท์มือถือ' }} />
                  <Item dataField="email"          label={{ text: 'E-mail' }} />
                </GroupItem>

                <GroupItem caption="บัตรประจำตัวประชาชน" colCount={4} colSpan={4}>
                  <Item dataField="humId"          label={{ text: 'เลขบัตร ปชช.' }}>
                    <RequiredRule message="กรุณากรอกเลขบัตรประจำตัวประชาชน" />
                  </Item>
                  <Item dataField="idCardNumber"   label={{ text: 'รหัสหลังบัตร' }} />
                  <Item dataField="idCardDate"     label={{ text: 'วันออกบัตร' }}   editorType="dxDateBox" editorOptions={{ displayFormat: 'dd/MM/yyyy', type: 'date' }} />
                  <Item dataField="idCardEnddate"  label={{ text: 'วันหมดอายุ' }}   editorType="dxDateBox" editorOptions={{ displayFormat: 'dd/MM/yyyy', type: 'date' }} />
                  <Item dataField="idCardOrganize" label={{ text: 'สถานที่ออกบัตร' }} colSpan={2} />
                </GroupItem>

                <GroupItem caption="ข้อมูลสหกรณ์" colCount={4} colSpan={4}>
                  <Item dataField="memberGroupNo"  label={{ text: 'หน่วยงาน' }}    editorType="dxSelectBox" editorOptions={selectOpts(ds.memGroups)}>
                    <RequiredRule message="กรุณาเลือกหน่วยงาน" />
                  </Item>
                  <Item dataField="memType"        label={{ text: 'ประเภทสมาชิก' }} editorType="dxSelectBox" editorOptions={selectOpts(ds.memTypes)}>
                    <RequiredRule message="กรุณาเลือกประเภทสมาชิก" />
                  </Item>
                  <Item dataField="electionGroup"  label={{ text: 'กลุ่มเลือกตั้ง' }} editorType="dxSelectBox" editorOptions={selectOpts(ds.elections)} />
                  <Item dataField="remark"         label={{ text: 'หมายเหตุ' }} />
                </GroupItem>
              </Form>
            </div>
          )

          // ── Tab 2: ที่อยู่ ───────────────────────────────────────────────────
          if (item.title === 'ที่อยู่') return (
            <div style={{ padding: '12px 0' }}>
              <AddressForm title="ที่อยู่ปัจจุบัน"  data={addrCur}  onChange={setAddrCur}
                           provinces={ds.provinces} allDistricts={rawDistricts} allSubdistricts={rawSubdistricts}
                           lookupDistricts={rawDistricts} lookupSubdistricts={rawSubdistricts} />
              <div style={{ height: 16 }} />
              <AddressForm title="ที่อยู่ตามทะเบียนบ้าน" data={addrHome} onChange={setAddrHome}
                           provinces={ds.provinces} allDistricts={rawDistricts} allSubdistricts={rawSubdistricts}
                           lookupDistricts={rawDistricts} lookupSubdistricts={rawSubdistricts} />
              <div style={{ height: 16 }} />
              <AddressForm title="ที่อยู่ที่ทำงาน" data={addrWork} onChange={setAddrWork}
                           provinces={ds.provinces} allDistricts={rawDistricts} allSubdistricts={rawSubdistricts}
                           lookupDistricts={rawDistricts} lookupSubdistricts={rawSubdistricts} />
            </div>
          )

          // ── Tab 3: ข้อมูลการทำงาน ───────────────────────────────────────────
          if (item.title === 'ข้อมูลการทำงาน') return (
            <div style={{ padding: '12px 0' }}>
              <Form formData={workInfo} labelLocation="top" colCount={4}
                    onFieldDataChanged={e => setWorkInfo(prev => ({ ...prev, [e.dataField!]: e.value }))}>
                <Item dataField="workingDate"        label={{ text: 'วันที่เริ่มทำงาน' }}   editorType="dxDateBox" editorOptions={{ displayFormat: 'dd/MM/yyyy', type: 'date' }} />
                <Item dataField="salaryId"           label={{ text: 'รหัสพนักงาน' }} />
                <Item dataField="groupPosition"      label={{ text: 'ประเภทงาน' }}     editorType="dxSelectBox" editorOptions={selectOpts(ds.groupPos)} />
                <Item dataField="positionLong"       label={{ text: 'ตำแหน่ง' }}        editorType="dxSelectBox" editorOptions={selectOpts(ds.positions)} />
                <Item dataField="levelCode"          label={{ text: 'ระดับ' }} />
                <Item dataField="salaryRateCode"     label={{ text: 'อัตราเงินเดือน' }} />
                <Item dataField="salaryAmount"       label={{ text: 'เงินเดือน (บาท)' }}     editorType="dxNumberBox" editorOptions={{ format: '#,##0.00' }} />
                <Item dataField="academicSalary"     label={{ text: 'เงินประจำตำแหน่ง' }} editorType="dxNumberBox" editorOptions={{ format: '#,##0.00' }} />
                <Item dataField="remunerationAmount" label={{ text: 'เงินอื่นๆ' }}           editorType="dxNumberBox" editorOptions={{ format: '#,##0.00' }} />
                <Item dataField="salaryReal"         label={{ text: 'เงินเดือนรวม' }}        editorType="dxNumberBox" editorOptions={{ format: '#,##0.00', readOnly: true }} />
                <Item dataField="endingcontractDate" label={{ text: 'วันสิ้นสุดสัญญา' }}   editorType="dxDateBox" editorOptions={{ displayFormat: 'dd/MM/yyyy', type: 'date' }} />
              </Form>
            </div>
          )

          // ── Tab 4: หุ้น / สมาชิกอ้างอิง ────────────────────────────────────
          if (item.title === 'หุ้น / อ้างอิง') return (
            <div style={{ padding: '12px 0' }}>
              {/* share */}
              <div style={{ marginBottom: 20 }}>
                <div style={{ fontWeight: 600, color: '#1a3760', marginBottom: 8 }}>การส่งหุ้น</div>
                <Form formData={{ shareMonthly }} labelLocation="left" colCount={2}
                      onFieldDataChanged={e => { if (e.dataField === 'shareMonthly') setShareMonthly(e.value) }}>
                  <Item dataField="shareMonthly" label={{ text: 'จำนวนหุ้น (บาท/เดือน)' }}
                        editorType="dxNumberBox" editorOptions={{ format: '#,##0.00', min: 0 }} />
                </Form>
              </div>

              {/* member refers */}
              <div style={{ fontWeight: 600, color: '#1a3760', marginBottom: 8 }}>สมาชิกอ้างอิง</div>
              <DataGrid
                dataSource={memberRefers}
                onRowInserted={e => setMemberRefers(prev => { const next = { ...e.data as AppMemberReferDto }; next.seqNo = prev.length + 1; return [...prev, next] })}
                onRowUpdated={e => setMemberRefers(prev => prev.map(r => r.seqNo === (e.data as AppMemberReferDto).seqNo ? { ...r, ...(e.data as AppMemberReferDto) } : r))}
                onRowRemoved={e => setMemberRefers(prev => prev.filter(r => r.seqNo !== (e.data as AppMemberReferDto).seqNo))}
                height={200}
              >
                <Editing mode="row" allowAdding allowUpdating allowDeleting />
                <Paging pageSize={10} /><Pager showPageSizeSelector showInfo />
                <Column dataField="membershipNo" caption="เลขที่สมาชิก" width={140} />
                <Column dataField="memberName"   caption="ชื่อ-นามสกุล" />
                <Column dataField="concernCode"  caption="ความสัมพันธ์"  width={160}
                        lookup={{ dataSource: ds.concerns, valueExpr: 'value', displayExpr: 'display' }} />
              </DataGrid>
            </div>
          )

          // ── Tab 5: ผู้รับผลประโยชน์ ─────────────────────────────────────────
          if (item.title === 'ผู้รับผลประโยชน์') return (
            <div style={{ padding: '12px 0' }}>
              <DataGrid
                dataSource={recrieveGains}
                onRowInserted={e => setRecrieveGains(prev => { const next = { ...e.data as AppRecrieveGainDto }; next.seqNo = prev.length + 1; return [...prev, next] })}
                onRowUpdated={e => setRecrieveGains(prev => prev.map(r => r.seqNo === (e.data as AppRecrieveGainDto).seqNo ? { ...r, ...(e.data as AppRecrieveGainDto) } : r))}
                onRowRemoved={e => setRecrieveGains(prev => prev.filter(r => r.seqNo !== (e.data as AppRecrieveGainDto).seqNo))}
                height={300}
              >
                <Editing mode="row" allowAdding allowUpdating allowDeleting />
                <Paging pageSize={10} /><Pager showPageSizeSelector showInfo />
                <Column dataField="prenameCode"  caption="คำนำหน้า"    width={110}
                        lookup={{ dataSource: ds.prenames, valueExpr: 'value', displayExpr: 'display' }} />
                <Column dataField="gainName"     caption="ชื่อ"         width={150} />
                <Column dataField="gainSurname"  caption="นามสกุล"     width={150} />
                <Column dataField="concernCode"  caption="ความสัมพันธ์" width={150}
                        lookup={{ dataSource: ds.concerns, valueExpr: 'value', displayExpr: 'display' }} />
                <Column dataField="gainPercent"  caption="เปอร์เซ็นต์"  width={110} dataType="number"
                        format="#,##0.##" />
                <Column dataField="gainIdCard"   caption="เลขบัตร ปชช." width={160} />
                <Column dataField="gainAddress"  caption="ที่อยู่" />
                <Column dataField="gainTelephone" caption="โทรศัพท์"    width={120} />
              </DataGrid>
            </div>
          )

          return null
        }}
      />
    </div>
  )
}

// ── AddressForm sub-component ─────────────────────────────────────────────────

interface RawDistrict    { value: string; display: string; provinceCode?: string }
interface RawSubdistrict { value: string; display: string; districtCode?: string  }

interface AddressFormProps {
  title:            string
  data:             AppAddressDto
  onChange:         (d: AppAddressDto) => void
  provinces:        { value: string; display: string }[]
  allDistricts:     RawDistrict[]
  allSubdistricts:  RawSubdistrict[]
  lookupDistricts:  RawDistrict[]
  lookupSubdistricts: RawSubdistrict[]
}

function AddressForm({ title, data, onChange, provinces, allDistricts, allSubdistricts, lookupDistricts, lookupSubdistricts }: AddressFormProps) {
  const selOpts = (arr: { value: string; display: string }[]) => ({
    dataSource: arr, valueExpr: 'value', displayExpr: 'display',
    searchEnabled: true, showClearButton: true,
  })

  const fd = (field: keyof AppAddressDto) => ({
    onValueChanged: (e: { value: unknown }) => {
      const next = { ...data, [field]: e.value }
      // cascade reset on province/district change
      if (field === 'provinceCode') { next.districtCode = undefined; next.tambol = undefined; next.postcode = undefined }
      if (field === 'districtCode') { next.tambol = undefined; next.postcode = undefined }
      onChange(next)
    }
  })

  // cascade-filtered district/subdistrict lists
  const curDistricts   = data.provinceCode
    ? allDistricts.filter(d => {
        const raw = lookupDistricts.find(x => x.value === d.value)
        return raw?.provinceCode === data.provinceCode
      })
    : allDistricts
  const curSubdistricts = data.districtCode
    ? allSubdistricts.filter(s => {
        const raw = lookupSubdistricts.find(x => x.value === s.value)
        return raw?.districtCode === data.districtCode
      })
    : allSubdistricts

  return (
    <div style={{ border: '1px solid #e5e7eb', borderRadius: 8, padding: '12px 16px' }}>
      <div style={{ fontWeight: 600, color: '#1a3760', marginBottom: 10 }}>{title}</div>
      <Form formData={data} labelLocation="top" colCount={4}>
        <Item dataField="addressNo"   label={{ text: 'บ้านเลขที่' }}   editorOptions={fd('addressNo')} />
        <Item dataField="moo"         label={{ text: 'หมู่ที่' }}        editorOptions={fd('moo')} />
        <Item dataField="mooban"      label={{ text: 'หมู่บ้าน' }}       editorOptions={fd('mooban')} />
        <Item dataField="soi"         label={{ text: 'ซอย' }}             editorOptions={fd('soi')} />
        <Item dataField="road"        label={{ text: 'ถนน' }}             editorOptions={fd('road')} />
        <Item dataField="provinceCode" label={{ text: 'จังหวัด' }}
              editorType="dxSelectBox"
              editorOptions={{ ...selOpts(provinces), ...fd('provinceCode') }} />
        <Item dataField="districtCode" label={{ text: 'อำเภอ/เขต' }}
              editorType="dxSelectBox"
              editorOptions={{ ...selOpts(curDistricts), ...fd('districtCode') }} />
        <Item dataField="tambol"      label={{ text: 'ตำบล/แขวง' }}
              editorType="dxSelectBox"
              editorOptions={{ ...selOpts(curSubdistricts), ...fd('tambol') }} />
        <Item dataField="postcode"    label={{ text: 'รหัสไปรษณีย์' }}   editorOptions={fd('postcode')} />
        <Item dataField="telephone"   label={{ text: 'โทรศัพท์' }}        editorOptions={fd('telephone')} />
      </Form>
    </div>
  )
}
