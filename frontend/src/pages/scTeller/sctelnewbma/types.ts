/**
 * sctelnewbma/types.ts — Shared types + format constants
 * (ใช้ร่วมกันระหว่าง Header.tsx / Tabs.tsx / Operate.tsx / index.tsx)
 */

// ── Format constants (อ้างอิงจาก sc.mask, sc.value) ──────────────────────────

// sc.mask.maskIdCard = "9-9999-99999-99-9"
export const MASK_IDCARD = '9-9999-99999-99-9'

// sc.value.toStringTH / sc.value.toDate — แสดงเป็น พ.ศ., เก็บ DB เป็น ค.ศ.
export const FMT_DATE_TH = {
  formatter: (d: Date) => {
    const dd = String(d.getDate()).padStart(2, '0')
    const mm = String(d.getMonth() + 1).padStart(2, '0')
    return `${dd}/${mm}/${d.getFullYear() + 543}`
  },
  parser: (s: string) => {
    const p = s.split('/')
    if (p.length !== 3 || p[2].length !== 4) return null
    return new Date(+p[2] - 543, +p[1] - 1, +p[0])
  },
}

// sc.mask.maskDecimal → จำนวนเงิน (2 ทศนิยม)
export const FMT_MONEY: object = { format: '#,##0.00', min: 0 }

// sc.mask.maskPercent2 → เปอร์เซ็นต์ (2 ทศนิยม, 0-100)
export const FMT_PERCENT2: object = { format: '#,##0.00', min: 0, max: 100 }

// ── Helper ────────────────────────────────────────────────────────────────────

export type DsItem = { value: string; display: string }

export const selOpts = (data: DsItem[]) => ({
  dataSource:      data,
  valueExpr:       'value',
  displayExpr:     'display',
  searchEnabled:   true,
  showClearButton: true,
})

// ── Lookup interfaces (ตรงกับ SctelnewbmaLookupsDto ใน Application layer) ──────

// Generic dropdown item — ตรงกับ ComboItemDto ใน Application layer
export interface ComboItemDto     { code: string; name?: string }
export interface MemberTypeDto    { code: string; desc?: string; maximunShare?: number; notSalary?: string; mprocApart?: string }
export interface MemberGroupDto   { no: string;   name?: string; memTypeDefault?: string; notSal?: string; ingoreDropshrRule?: string }
export interface ElectionGroupDto { code: string; name?: string; zone?: string }
export interface NationalityDto   { code: string; description?: string }
export interface BloodDto         { code: string; desc?: string }
export interface ProvinceDto      { code: string; name?: string }
export interface DistrictDto      { code: string; name?: string; provinceCode?: string; postCode?: string }
export interface SubdistrictDto   { code: string; name?: string; districtCode?: string }
export interface ApplicationTypeDto { code: string; name?: string; fee?: number; memTypeCode?: string }
export interface ConcernDto       { code: string; relatedNa?: string }
export interface GroupPositionDto { code: string; description?: string; sortOrder?: number }
export interface PositionDto      { code: string; name?: string; sortOrder?: number }
export interface CoopConfigDto    { coopNo: string; countResign?: number; autoApproveNewmem?: string; memTypeOngroup?: string }

export interface LookupsDto {
  prenames:         ComboItemDto[]   // sc.combo.sc_mem_m_ucf_prename
  sexes:            ComboItemDto[]   // sc.combo.sex
  memberTypes:      MemberTypeDto[]
  memberGroups:     MemberGroupDto[]
  electionGroups:   ElectionGroupDto[]
  nationalities:    NationalityDto[]
  marriageStatuses: ComboItemDto[]   // sc.combo.sc_mem_m_ucf_marriage_status
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

// ── Form data interfaces (ตรงกับ ApplicationFormDto ใน Application layer) ──────

export interface AppAddressDto {
  addressType?: string
  addressNo?: string; moo?: string; mooban?: string; soi?: string; road?: string
  tambol?: string; districtCode?: string; provinceCode?: string; postcode?: string; telephone?: string
}

export interface AppWorkInfoDto {
  workingDate?: string | Date; salaryId?: string; groupOther?: string
  groupPosition?: string; positionLong?: string; levelCode?: string; salaryRateCode?: string
  salaryAmount?: number; academicSalary?: number; remunerationAmount?: number; salaryReal?: number
  endingcontractDate?: string | Date
}

export interface AppMemberReferDto {
  seqNo: number; membershipNo?: string; memberName?: string; concernCode?: string
}

export interface AppRecrieveGainDto {
  seqNo: number; prenameCode?: string; gainName?: string; gainSurname?: string
  concernCode?: string; wefType?: string; gainPercent?: number; gainIdCard?: string
  bookDate?: string | Date; orderNumber?: number; gainAddress?: string; gainTelephone?: string; gainDesc?: string
}

export interface ApplicationFormDto {
  applicationFormNo?: string; applyDate?: string | Date
  prenameCode?: string; memberName?: string; memberSurname?: string
  memberGroupNo?: string; memType?: string; dateOfBirth?: string | Date; sex?: string
  applTypeCode?: string; humId?: string; marriageStatus?: string
  nationalityCode?: string; bloodCode?: string; mobileNumber?: string; email?: string; remark?: string
  approveStatus?: string; cancelStatus?: string
  prenameEng?: string; nameEng?: string; surnameEng?: string
  idCardDate?: string | Date; idCardEnddate?: string | Date; idCardNumber?: string; idCardOrganize?: string
  electionGroup?: string
  addressCurrent?: AppAddressDto; addressHome?: AppAddressDto; addressWork?: AppAddressDto
  workInfo?: AppWorkInfoDto; shareMonthly?: number
  memberRefers?: AppMemberReferDto[]; recrieveGains?: AppRecrieveGainDto[]
  pictureBase64?: string; signatureBase64?: string
}

// ── Computed dropdown datasource type ────────────────────────────────────────

export interface DsType {
  prenames:  DsItem[]
  sexes:     DsItem[]
  marr:      DsItem[]
  memTypes:  DsItem[]
  memGroups: DsItem[]
  elections: DsItem[]
  natl:      DsItem[]
  blood:     DsItem[]
  provinces: DsItem[]
  applTypes: DsItem[]
  concerns:  DsItem[]
  groupPos:  DsItem[]
  positions: DsItem[]
}

export interface RawDistrict    { value: string; display: string; provinceCode?: string }
export interface RawSubdistrict { value: string; display: string; districtCode?: string }
