/**
 * sctelnewbma/Header.tsx — ฟอร์มข้อมูลสมาชิก (scroll ได้)
 *
 * รวม 5 tabs เดิมเป็น form เดียว แบ่งเป็น sections:
 *   ข้อมูลใบสมัคร · ชื่อ-นามสกุล · ชื่อภาษาอังกฤษ · ข้อมูลส่วนตัว
 *   บัตรประจำตัวประชาชน · ข้อมูลสหกรณ์
 *   ที่อยู่ปัจจุบัน · ที่อยู่ตามทะเบียนบ้าน · ที่อยู่ที่ทำงาน
 *   ข้อมูลการทำงาน · การส่งหุ้น · สมาชิกอ้างอิง · ผู้รับผลประโยชน์
 */
import type { Dispatch, SetStateAction } from 'react'
import Form, { Item, GroupItem, RequiredRule } from 'devextreme-react/form'
import DataGrid, { Column, Editing, Pager, Paging } from 'devextreme-react/data-grid'
import {
  MASK_IDCARD, FMT_DATE_TH, FMT_MONEY, FMT_PERCENT2, selOpts,
  type DsItem,
  type AppAddressDto, type AppWorkInfoDto,
  type AppMemberReferDto, type AppRecrieveGainDto,
  type ApplicationFormDto, type DsType,
  type RawDistrict, type RawSubdistrict,
} from './types'

// ── Section divider ────────────────────────────────────────────────────────────

function Divider({ title }: { title: string }) {
  return (
    <div style={{ borderBottom: '1.5px solid #1a3760', paddingBottom: 5,
                  marginTop: 20, marginBottom: 12 }}>
      <span style={{ fontWeight: 700, fontSize: 13, color: '#1a3760' }}>{title}</span>
    </div>
  )
}

// ── AddressForm ────────────────────────────────────────────────────────────────

interface AddressFormProps {
  title:           string
  data:            AppAddressDto
  onChange:        Dispatch<SetStateAction<AppAddressDto>>
  provinces:       DsItem[]
  allDistricts:    RawDistrict[]
  allSubdistricts: RawSubdistrict[]
}

function AddressForm({ title, data, onChange, provinces, allDistricts, allSubdistricts }: AddressFormProps) {
  const fd = (field: keyof AppAddressDto) => ({
    onValueChanged: (e: { value: unknown }) => {
      onChange(prev => {
        const next = { ...prev, [field]: e.value }
        // cascade reset เมื่อเปลี่ยนจังหวัด / อำเภอ
        if (field === 'provinceCode') { next.districtCode = undefined; next.tambol = undefined; next.postcode = undefined }
        if (field === 'districtCode') { next.tambol = undefined; next.postcode = undefined }
        return next
      })
    },
  })

  const curDistricts    = data.provinceCode ? allDistricts.filter(d => d.provinceCode === data.provinceCode) : allDistricts
  const curSubdistricts = data.districtCode ? allSubdistricts.filter(s => s.districtCode === data.districtCode) : allSubdistricts

  return (
    <div style={{ border: '1px solid #e5e7eb', borderRadius: 8, padding: '12px 16px', marginBottom: 10 }}>
      <div style={{ fontWeight: 600, color: '#1a3760', marginBottom: 10, fontSize: 13 }}>{title}</div>
      <Form formData={data} labelLocation="top" colCount={4}>
        <Item dataField="addressNo"    label={{ text: 'บ้านเลขที่' }}  editorOptions={fd('addressNo')} />
        <Item dataField="moo"          label={{ text: 'หมู่ที่' }}      editorOptions={fd('moo')} />
        <Item dataField="mooban"       label={{ text: 'หมู่บ้าน' }}     editorOptions={fd('mooban')} />
        <Item dataField="soi"          label={{ text: 'ซอย' }}           editorOptions={fd('soi')} />
        <Item dataField="road"         label={{ text: 'ถนน' }}           editorOptions={fd('road')} />
        <Item dataField="provinceCode" label={{ text: 'จังหวัด' }}
              editorType="dxSelectBox"
              editorOptions={{ dataSource: provinces, valueExpr: 'value', displayExpr: 'display',
                               searchEnabled: true, showClearButton: true, ...fd('provinceCode') }} />
        <Item dataField="districtCode" label={{ text: 'อำเภอ/เขต' }}
              editorType="dxSelectBox"
              editorOptions={{ dataSource: curDistricts, valueExpr: 'value', displayExpr: 'display',
                               searchEnabled: true, showClearButton: true, ...fd('districtCode') }} />
        <Item dataField="tambol"       label={{ text: 'ตำบล/แขวง' }}
              editorType="dxSelectBox"
              editorOptions={{ dataSource: curSubdistricts, valueExpr: 'value', displayExpr: 'display',
                               searchEnabled: true, showClearButton: true, ...fd('tambol') }} />
        <Item dataField="postcode"     label={{ text: 'รหัสไปรษณีย์' }} editorOptions={fd('postcode')} />
        <Item dataField="telephone"    label={{ text: 'โทรศัพท์' }}      editorOptions={fd('telephone')} />
      </Form>
    </div>
  )
}

// ── Props ──────────────────────────────────────────────────────────────────────

export interface HeaderProps {
  form:             ApplicationFormDto
  setForm:          Dispatch<SetStateAction<ApplicationFormDto>>
  addrCur:          AppAddressDto
  setAddrCur:       Dispatch<SetStateAction<AppAddressDto>>
  addrHome:         AppAddressDto
  setAddrHome:      Dispatch<SetStateAction<AppAddressDto>>
  addrWork:         AppAddressDto
  setAddrWork:      Dispatch<SetStateAction<AppAddressDto>>
  workInfo:         AppWorkInfoDto
  setWorkInfo:      Dispatch<SetStateAction<AppWorkInfoDto>>
  shareMonthly:     number | undefined
  setShareMonthly:  Dispatch<SetStateAction<number | undefined>>
  memberRefers:     AppMemberReferDto[]
  setMemberRefers:  Dispatch<SetStateAction<AppMemberReferDto[]>>
  recrieveGains:    AppRecrieveGainDto[]
  setRecrieveGains: Dispatch<SetStateAction<AppRecrieveGainDto[]>>
  ds:               DsType
  allDistricts:     RawDistrict[]
  allSubdistricts:  RawSubdistrict[]
}

// ── Header component ───────────────────────────────────────────────────────────

export default function Header({
  form, setForm,
  addrCur, setAddrCur, addrHome, setAddrHome, addrWork, setAddrWork,
  workInfo, setWorkInfo,
  shareMonthly, setShareMonthly,
  memberRefers, setMemberRefers,
  recrieveGains, setRecrieveGains,
  ds, allDistricts, allSubdistricts,
}: HeaderProps) {
  return (
    <div style={{ overflowY: 'auto', maxHeight: '55vh',
                  border: '1px solid #e5e7eb', borderRadius: 8, padding: '12px 16px' }}>

      {/* ── ข้อมูลใบสมัคร ──────────────────────────────────────────────────── */}
      <Divider title="ข้อมูลใบสมัคร" />
      <Form formData={form} labelLocation="top" colCount={4}
            onFieldDataChanged={e => setForm(prev => ({ ...prev, [e.dataField!]: e.value }))}>
        <GroupItem colCount={4} colSpan={4}>
          <Item dataField="applicationFormNo" label={{ text: 'เลขที่ใบสมัคร' }}
                editorOptions={{ readOnly: true, placeholder: '(สร้างอัตโนมัติ)' }} />
          <Item dataField="applyDate"     label={{ text: 'วันที่สมัคร' }}
                editorType="dxDateBox"    editorOptions={{ displayFormat: FMT_DATE_TH, type: 'date' }} />
          <Item dataField="applTypeCode"  label={{ text: 'ประเภทการสมัคร' }}
                editorType="dxSelectBox"  editorOptions={selOpts(ds.applTypes)}>
            <RequiredRule message="กรุณาเลือกประเภทการสมัคร" />
          </Item>
          <Item dataField="approveStatus" label={{ text: 'สถานะ' }}
                editorOptions={{ readOnly: true }} />
        </GroupItem>
      </Form>

      {/* ── ชื่อ-นามสกุล ────────────────────────────────────────────────────── */}
      <Divider title="ชื่อ-นามสกุล" />
      <Form formData={form} labelLocation="top" colCount={4}
            onFieldDataChanged={e => setForm(prev => ({ ...prev, [e.dataField!]: e.value }))}>
        <GroupItem colCount={4} colSpan={4}>
          {/* sc.combo.sc_mem_m_ucf_prename */}
          <Item dataField="prenameCode"   label={{ text: 'คำนำหน้า' }}
                editorType="dxSelectBox"  editorOptions={selOpts(ds.prenames)}>
            <RequiredRule message="กรุณาเลือกคำนำหน้า" />
          </Item>
          <Item dataField="memberName"    label={{ text: 'ชื่อ' }}>
            <RequiredRule message="กรุณากรอกชื่อ" />
          </Item>
          <Item dataField="memberSurname" label={{ text: 'นามสกุล' }}>
            <RequiredRule message="กรุณากรอกนามสกุล" />
          </Item>
          {/* sc.combo.sex */}
          <Item dataField="sex"           label={{ text: 'เพศ' }}
                editorType="dxSelectBox"  editorOptions={selOpts(ds.sexes)} />
        </GroupItem>
      </Form>

      {/* ── ชื่อภาษาอังกฤษ ──────────────────────────────────────────────────── */}
      <Divider title="ชื่อภาษาอังกฤษ" />
      <Form formData={form} labelLocation="top" colCount={3}
            onFieldDataChanged={e => setForm(prev => ({ ...prev, [e.dataField!]: e.value }))}>
        <GroupItem colCount={3} colSpan={3}>
          <Item dataField="prenameEng" label={{ text: 'Prefix' }} />
          <Item dataField="nameEng"    label={{ text: 'Name' }} />
          <Item dataField="surnameEng" label={{ text: 'Surname' }} />
        </GroupItem>
      </Form>

      {/* ── ข้อมูลส่วนตัว ───────────────────────────────────────────────────── */}
      <Divider title="ข้อมูลส่วนตัว" />
      <Form formData={form} labelLocation="top" colCount={4}
            onFieldDataChanged={e => setForm(prev => ({ ...prev, [e.dataField!]: e.value }))}>
        <GroupItem colCount={4} colSpan={4}>
          <Item dataField="dateOfBirth"     label={{ text: 'วันเกิด' }}
                editorType="dxDateBox"      editorOptions={{ displayFormat: FMT_DATE_TH, type: 'date' }} />
          {/* sc.combo.sc_mem_m_ucf_marriage_status */}
          <Item dataField="marriageStatus"  label={{ text: 'สถานภาพสมรส' }}
                editorType="dxSelectBox"    editorOptions={selOpts(ds.marr)} />
          <Item dataField="nationalityCode" label={{ text: 'สัญชาติ' }}
                editorType="dxSelectBox"    editorOptions={selOpts(ds.natl)} />
          <Item dataField="bloodCode"       label={{ text: 'หมู่เลือด' }}
                editorType="dxSelectBox"    editorOptions={selOpts(ds.blood)} />
          {/* ไม่มี mask โทรศัพท์ */}
          <Item dataField="mobileNumber"    label={{ text: 'โทรศัพท์มือถือ' }} />
          <Item dataField="email"           label={{ text: 'E-mail' }} />
        </GroupItem>
      </Form>

      {/* ── บัตรประจำตัวประชาชน ─────────────────────────────────────────────── */}
      <Divider title="บัตรประจำตัวประชาชน" />
      <Form formData={form} labelLocation="top" colCount={4}
            onFieldDataChanged={e => setForm(prev => ({ ...prev, [e.dataField!]: e.value }))}>
        <GroupItem colCount={4} colSpan={4}>
          {/* sc.mask.maskIdCard = "9-9999-99999-99-9" */}
          <Item dataField="humId"          label={{ text: 'เลขบัตร ปชช.' }}
                editorType="dxTextBox"     editorOptions={{ mask: MASK_IDCARD, useMaskedValue: true }}>
            <RequiredRule message="กรุณากรอกเลขบัตรประจำตัวประชาชน" />
          </Item>
          <Item dataField="idCardNumber"   label={{ text: 'รหัสหลังบัตร' }} />
          <Item dataField="idCardDate"     label={{ text: 'วันออกบัตร' }}
                editorType="dxDateBox"     editorOptions={{ displayFormat: FMT_DATE_TH, type: 'date' }} />
          <Item dataField="idCardEnddate"  label={{ text: 'วันหมดอายุ' }}
                editorType="dxDateBox"     editorOptions={{ displayFormat: FMT_DATE_TH, type: 'date' }} />
          <Item dataField="idCardOrganize" label={{ text: 'สถานที่ออกบัตร' }} colSpan={2} />
        </GroupItem>
      </Form>

      {/* ── ข้อมูลสหกรณ์ ────────────────────────────────────────────────────── */}
      <Divider title="ข้อมูลสหกรณ์" />
      <Form formData={form} labelLocation="top" colCount={4}
            onFieldDataChanged={e => setForm(prev => ({ ...prev, [e.dataField!]: e.value }))}>
        <GroupItem colCount={4} colSpan={4}>
          <Item dataField="memberGroupNo"  label={{ text: 'หน่วยงาน' }}
                editorType="dxSelectBox"   editorOptions={selOpts(ds.memGroups)}>
            <RequiredRule message="กรุณาเลือกหน่วยงาน" />
          </Item>
          <Item dataField="memType"        label={{ text: 'ประเภทสมาชิก' }}
                editorType="dxSelectBox"   editorOptions={selOpts(ds.memTypes)}>
            <RequiredRule message="กรุณาเลือกประเภทสมาชิก" />
          </Item>
          <Item dataField="electionGroup"  label={{ text: 'กลุ่มเลือกตั้ง' }}
                editorType="dxSelectBox"   editorOptions={selOpts(ds.elections)} />
          <Item dataField="remark"         label={{ text: 'หมายเหตุ' }} />
        </GroupItem>
      </Form>

      {/* ── ที่อยู่ ──────────────────────────────────────────────────────────── */}
      <Divider title="ที่อยู่" />
      <AddressForm title="ที่อยู่ปัจจุบัน"        data={addrCur}  onChange={setAddrCur}
                   provinces={ds.provinces} allDistricts={allDistricts} allSubdistricts={allSubdistricts} />
      <AddressForm title="ที่อยู่ตามทะเบียนบ้าน" data={addrHome} onChange={setAddrHome}
                   provinces={ds.provinces} allDistricts={allDistricts} allSubdistricts={allSubdistricts} />
      <AddressForm title="ที่อยู่ที่ทำงาน"        data={addrWork} onChange={setAddrWork}
                   provinces={ds.provinces} allDistricts={allDistricts} allSubdistricts={allSubdistricts} />

      {/* ── ข้อมูลการทำงาน ──────────────────────────────────────────────────── */}
      <Divider title="ข้อมูลการทำงาน" />
      <Form formData={workInfo} labelLocation="top" colCount={4}
            onFieldDataChanged={e => setWorkInfo(prev => ({ ...prev, [e.dataField!]: e.value }))}>
        <GroupItem colCount={4} colSpan={4}>
          <Item dataField="workingDate"        label={{ text: 'วันที่เริ่มทำงาน' }}
                editorType="dxDateBox"         editorOptions={{ displayFormat: FMT_DATE_TH, type: 'date' }} />
          <Item dataField="salaryId"           label={{ text: 'รหัสพนักงาน' }} />
          <Item dataField="groupPosition"      label={{ text: 'ประเภทงาน' }}
                editorType="dxSelectBox"       editorOptions={selOpts(ds.groupPos)} />
          <Item dataField="positionLong"       label={{ text: 'ตำแหน่ง' }}
                editorType="dxSelectBox"       editorOptions={selOpts(ds.positions)} />
          <Item dataField="levelCode"          label={{ text: 'ระดับ' }} />
          <Item dataField="salaryRateCode"     label={{ text: 'อัตราเงินเดือน' }} />
          {/* sc.mask.maskDecimal → #,##0.00 */}
          <Item dataField="salaryAmount"       label={{ text: 'เงินเดือน (บาท)' }}
                editorType="dxNumberBox"       editorOptions={FMT_MONEY} />
          <Item dataField="academicSalary"     label={{ text: 'เงินประจำตำแหน่ง' }}
                editorType="dxNumberBox"       editorOptions={FMT_MONEY} />
          <Item dataField="remunerationAmount" label={{ text: 'เงินอื่นๆ' }}
                editorType="dxNumberBox"       editorOptions={FMT_MONEY} />
          <Item dataField="salaryReal"         label={{ text: 'เงินเดือนรวม' }}
                editorType="dxNumberBox"       editorOptions={{ ...FMT_MONEY, readOnly: true }} />
          <Item dataField="endingcontractDate" label={{ text: 'วันสิ้นสุดสัญญา' }}
                editorType="dxDateBox"         editorOptions={{ displayFormat: FMT_DATE_TH, type: 'date' }} />
        </GroupItem>
      </Form>

      {/* ── การส่งหุ้น ──────────────────────────────────────────────────────── */}
      <Divider title="การส่งหุ้น" />
      <Form formData={{ shareMonthly }} labelLocation="left" colCount={2}
            onFieldDataChanged={e => { if (e.dataField === 'shareMonthly') setShareMonthly(e.value as number | undefined) }}>
        {/* sc.mask.maskDecimal → #,##0.00 */}
        <Item dataField="shareMonthly" label={{ text: 'จำนวนหุ้น (บาท/เดือน)' }}
              editorType="dxNumberBox" editorOptions={FMT_MONEY} />
      </Form>

      {/* ── สมาชิกอ้างอิง ───────────────────────────────────────────────────── */}
      <Divider title="สมาชิกอ้างอิง" />
      {/* TODO: membershipNo ควรใช้ sc.scCoop.ofParse (validate + pad zeros) */}
      <DataGrid
        dataSource={memberRefers}
        onRowInserted={e  => setMemberRefers(prev => [...prev, { ...e.data as AppMemberReferDto,  seqNo: prev.length  + 1 }])}
        onRowUpdated={e   => setMemberRefers(prev => prev.map(r  => r.seqNo  === (e.data as AppMemberReferDto).seqNo  ? { ...r,  ...(e.data as AppMemberReferDto)  } : r))}
        onRowRemoved={e   => setMemberRefers(prev => prev.filter(r  => r.seqNo  !== (e.data as AppMemberReferDto).seqNo))}
        height={200}
      >
        <Editing mode="row" allowAdding allowUpdating allowDeleting />
        <Paging pageSize={10} /><Pager showPageSizeSelector showInfo />
        <Column dataField="membershipNo" caption="เลขที่สมาชิก" width={140} />
        <Column dataField="memberName"   caption="ชื่อ-นามสกุล" />
        <Column dataField="concernCode"  caption="ความสัมพันธ์" width={160}
                lookup={{ dataSource: ds.concerns, valueExpr: 'value', displayExpr: 'display' }} />
      </DataGrid>

      {/* ── ผู้รับผลประโยชน์ ─────────────────────────────────────────────────── */}
      <Divider title="ผู้รับผลประโยชน์" />
      <DataGrid
        dataSource={recrieveGains}
        onRowInserted={e => setRecrieveGains(prev => [...prev, { ...e.data as AppRecrieveGainDto, seqNo: prev.length + 1 }])}
        onRowUpdated={e  => setRecrieveGains(prev => prev.map(r  => r.seqNo === (e.data as AppRecrieveGainDto).seqNo ? { ...r, ...(e.data as AppRecrieveGainDto) } : r))}
        onRowRemoved={e  => setRecrieveGains(prev => prev.filter(r => r.seqNo !== (e.data as AppRecrieveGainDto).seqNo))}
        height={300}
      >
        <Editing mode="row" allowAdding allowUpdating allowDeleting />
        <Paging pageSize={10} /><Pager showPageSizeSelector showInfo />
        <Column dataField="prenameCode"   caption="คำนำหน้า"     width={110}
                lookup={{ dataSource: ds.prenames, valueExpr: 'value', displayExpr: 'display' }} />
        <Column dataField="gainName"      caption="ชื่อ"          width={150} />
        <Column dataField="gainSurname"   caption="นามสกุล"       width={150} />
        <Column dataField="concernCode"   caption="ความสัมพันธ์"  width={150}
                lookup={{ dataSource: ds.concerns, valueExpr: 'value', displayExpr: 'display' }} />
        {/* sc.mask.maskPercent2 → #,##0.00 */}
        <Column dataField="gainPercent"   caption="เปอร์เซ็นต์"   width={110} dataType="number"
                editorOptions={FMT_PERCENT2} format="#,##0.00" />
        {/* sc.mask.maskIdCard = "9-9999-99999-99-9" */}
        <Column dataField="gainIdCard"    caption="เลขบัตร ปชช."  width={170}
                editorOptions={{ mask: MASK_IDCARD, useMaskedValue: true }} />
        <Column dataField="gainAddress"   caption="ที่อยู่" />
        <Column dataField="gainTelephone" caption="โทรศัพท์"       width={120} />
      </DataGrid>

    </div>
  )
}
