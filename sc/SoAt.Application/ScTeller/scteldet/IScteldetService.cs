namespace SoAt.Application.ScTeller;

/// <summary>
/// scteldet — ประวัติสมาชิก (Member Profile Viewer, read-only).
/// migrate จาก legacy C:\SoAt_PEAN\scTeller\scteldet (panHead + panTabs dynamic + 10 tab G1).
/// </summary>
public interface IScteldetService
{
    // ── Dynamic permission-driven tab metadata (si_security_apps) ─────────────
    /// <summary>กลุ่ม (i_level=4) + แท็บลูก (i_level=5) ของ scteldet ตามสิทธิ์ — legacy panTabs.ascx.cs</summary>
    Task<List<TabGroupDto>> GetTabMetadataAsync();

    // ── Header (panHead.ascx dsHead) ──────────────────────────────────────────
    Task<ScteldetHeaderDto?> GetMemberHeaderAsync(string membershipNo);
    Task<byte[]?> GetMemberPhotoAsync(string membershipNo);
    /// <summary>รูปลายเซ็น — popup popSignature (sc_mem_m_member_signature.mem_signature)</summary>
    Task<byte[]?> GetMemberSignatureAsync(string membershipNo);
    /// <summary>อ่านบัตร ปชช. → membership_no (legacy pka_mid_sync.fp_find_memno)</summary>
    Task<string?> LookupMemberByIdCardAsync(string idCard);

    // ── G1 "ข้อมูลหลักสมาชิก" 10 tabs ─────────────────────────────────────────
    /// <summary>ครอบครัว — คู่สมรส + พ่อ/แม่</summary>
    Task<SpouseInfoDto?> GetSpouseInfoAsync(string membershipNo);
    Task<ParentInfoDto?> GetParentInfoAsync(string membershipNo);

    /// <summary>การทำงาน — main + ที่อยู่ที่ทำงาน</summary>
    Task<WorkMainDto?> GetWorkMainAsync(string membershipNo);
    Task<WorkAddressDto?> GetWorkAddressAsync(string membershipNo);

    /// <summary>สมาชิกโอนมา</summary>
    Task<OwnInfoDto?> GetOwnInfoAsync(string membershipNo);

    /// <summary>ผู้รับผลประโยชน์ (grid)</summary>
    Task<List<GainDetailDto>> GetGainDetailAsync(string membershipNo);

    /// <summary>ปันผลเฉลี่ยคืน — year selector + multi-grid</summary>
    Task<List<DevidendYearDto>> GetDevidendYearsAsync(string membershipNo);
    Task<DevidendHeadDto?> GetDevidendHeadAsync(string membershipNo, int accountYear);
    Task<List<GotintDto>> GetDevidendGotintAsync(string membershipNo, int accountYear);
    Task<List<DividendDetailDto>> GetDevidendDetailAsync(string membershipNo, int accountYear);
    Task<List<DevidendPaymentDto>> GetDevidendPaymentAsync(string membershipNo, int accountYear);

    /// <summary>ปันผลรวมทุกปี (grid)</summary>
    Task<List<DevidendAllDto>> GetDevidendAllAsync(string membershipNo);

    /// <summary>บัญชีธนาคาร (grid)</summary>
    Task<List<BankInfoDto>> GetBankInfoAsync(string membershipNo);

    /// <summary>ATM (grid)</summary>
    Task<List<AtmDto>> GetAtmAsync(string membershipNo);

    /// <summary>เบอร์มือถือ (grid)</summary>
    Task<List<MobileDto>> GetMobileAsync(string membershipNo);

    /// <summary>ประวัติสัมมนา (grid)</summary>
    Task<List<SurminarDto>> GetSurminarAsync(string membershipNo);

    // ── G2 "สิทธิ/สวัสดิการ" 8 tabs ───────────────────────────────────────────
    /// <summary>สวัสดิการ (u_tabpg_mem_detail_welfare — view_tel_mem_wef)</summary>
    Task<List<WelfareDto>> GetWelfareAsync(string membershipNo);

    /// <summary>สมาคมฌาปนกิจ (u_tabpg_mem_detail_smk — sc_mem_m_member_cremation)</summary>
    Task<List<SmkDto>> GetSmkAsync(string membershipNo);

    /// <summary>ประกัน (u_tabpg_mem_detail_insurance_detail)</summary>
    Task<List<InsureDto>> GetInsureAsync(string membershipNo);

    /// <summary>ผู้รับเงินสงเคราะห์ 1-3 (u_tabpg_mem_recipient_ss1..3 — crem_type '01'/'02'/'03')</summary>
    Task<List<CremGainDto>> GetCremGainAsync(string membershipNo, string cremType);

    /// <summary>ผู้รับเงินสงเคราะห์ 4 (u_tabpg_mem_recipient_ss4 — view_tel_det_crem_gain_04)</summary>
    Task<List<CremGainDto>> GetCremGain04Async(string membershipNo);

    /// <summary>ผู้ค้ำ/ผู้ใช้ค้ำ (u_tabpg_mem_member_refer)</summary>
    Task<List<MemberReferDto>> GetMemberReferAsync(string membershipNo);

    // ── G3 "เงินกู้/หุ้น" 5 tabs ───────────────────────────────────────────────
    /// <summary>รายละเอียดเงินกู้ (u_tabpg_mem_detail_loan_detail — view_tel_det_lon ∪ คำขอ)</summary>
    Task<List<LoanDetailDto>> GetLoanDetailAsync(string membershipNo);

    /// <summary>หุ้นค้ำ/กองทุน (u_tabpg_mem_detail_share_coll — sc_fund_mem)</summary>
    Task<List<ShareCollDto>> GetShareCollAsync(string membershipNo);

    /// <summary>สถานะหุ้น — header (u_tabpg_mem_detail_share_state — sc_mem_m_share_mem)</summary>
    Task<ShareStateHeadDto?> GetShareStateHeadAsync(string membershipNo);

    /// <summary>สถานะหุ้น — grid (u_tabpg_mem_detail_share_state — sc_mem_m_share_holding_detail)</summary>
    Task<List<ShareStateDto>> GetShareStateAsync(string membershipNo);

    /// <summary>งดส่งเงินกู้ (u_tabpg_mem_detail_drop_loan — sc_mem_m_member_drop_loan)</summary>
    Task<List<DropLoanDto>> GetDropLoanAsync(string membershipNo);

    /// <summary>หลักประกัน — สัญญาที่สมาชิกไปค้ำให้คนอื่น (u_tabpg_mem_detail_coll_detail — sctel.getCalcCollUsed)</summary>
    Task<List<CollDetailDto>> GetCollDetailAsync(string membershipNo);

    /// <summary>ข้อความสรุปสิทธิค้ำใต้ grid (pkb_ktm.fp_get_msg_collused_teldet — KTM-only, PEAN คืนค่าว่าง)</summary>
    Task<string> GetCollUsedMsgAsync(string membershipNo);

    // ── popup กองทุนผู้ค้ำ (popShareCollDetail) 3 sub-tabs (key = loan_contract_no) ─
    /// <summary>sub 1: รายละเอียดกองทุน (u_tabpg_share_coll_detail — sc_fund_mem) form</summary>
    Task<ShareCollDetailMainDto?> GetShareCollMainAsync(string loanContractNo);

    /// <summary>sub 2: รายการเคลื่อนไหว (u_tabpg_share_coll_detail_state — sc_fund_mem_detail)</summary>
    Task<List<ShareCollStateDto>> GetShareCollStateAsync(string loanContractNo);

    /// <summary>sub 3a: จ่ายคืน (u_tabpg_share_coll_fund gvFundRet — sc_lon_m_req_fund_ret)</summary>
    Task<List<ShareCollFundRetDto>> GetShareCollFundRetAsync(string loanContractNo);

    /// <summary>sub 3b: เก็บเพิ่ม (u_tabpg_share_coll_fund gvFundNew — sc_lon_m_req_fund_new)</summary>
    Task<List<ShareCollFundNewDto>> GetShareCollFundNewAsync(string loanContractNo);

    // ── popup รายละเอียดเงินกู้ (popLoan_detail) 9 sub-tabs (key = loan_contract_no) ─
    /// <summary>sub 0: รายละเอียดเงินกู้ (u_tabpg_loan_detail_loan_detail_main) form</summary>
    Task<LoanDetailMainDto?> GetLoanDetailMainAsync(string loanContractNo);

    /// <summary>sub 1: เคลื่อนไหวสัญญา (u_tabpg_loan_detail_loan_detail)</summary>
    Task<List<LoanDetailMoveDto>> GetLoanDetailMoveAsync(string loanContractNo);

    /// <summary>sub 2: เงินกู้เอทีเอ็ม (u_tabpg_loan_detail_atmdet)</summary>
    Task<List<LoanDetailAtmDto>> GetLoanDetailAtmAsync(string loanContractNo);

    /// <summary>sub 3: รายการค้ำประกัน (u_tabpg_loan_detail_coll_detail gvLoanColl)</summary>
    Task<List<LoanDetailCollDto>> GetLoanDetailCollAsync(string loanContractNo);

    /// <summary>sub 4: โอนหนี้ให้ผู้ค้ำ (u_tabpg_loan_detail_coll_trans)</summary>
    Task<List<LoanDetailCollTransDto>> GetLoanDetailCollTransAsync(string loanContractNo);

    /// <summary>sub 5: การจ่ายเงิน (u_tabpg_loan_detail_payment) form</summary>
    Task<LoanDetailPaymentDto?> GetLoanDetailPaymentAsync(string loanContractNo);

    /// <summary>sub 6a: รายการหักกลบ head (u_tabpg_loan_detail_recclear) form</summary>
    Task<LoanDetailRecclearHeadDto?> GetLoanDetailRecclearHeadAsync(string loanContractNo);

    /// <summary>sub 6b: รายการหักกลบ item (u_tabpg_loan_detail_recclear grid)</summary>
    Task<List<LoanDetailRecclearItemDto>> GetLoanDetailRecclearItemAsync(string loanContractNo);

    /// <summary>sub 7: หลายวัตถุประสงค์ (u_tabpg_loan_detail_multiobject)</summary>
    Task<List<LoanDetailMultiobjectDto>> GetLoanDetailMultiobjectAsync(string loanContractNo);

    /// <summary>sub 8: ค่างวดรายเดือน (u_tabpg_loan_detail_step_pay)</summary>
    Task<List<LoanDetailStepPayDto>> GetLoanDetailStepPayAsync(string loanContractNo);

    // ── G4 "เรียกเก็บ" 3 tabs ──────────────────────────────────────────────────
    /// <summary>การจ่ายเงิน (u_tabpg_mem_detail_money_payment — sc_com_m_receipt + _item)</summary>
    Task<List<MoneyPaymentDto>> GetMoneyPaymentAsync(string membershipNo);

    /// <summary>เรียกเก็บรายเดือน (u_tabpg_mem_detail_monthly_return — sc_kep_t_monthly_receive)</summary>
    Task<List<MonthlyReturnDto>> GetMonthlyReturnAsync(string membershipNo);

    /// <summary>รายละเอียดใบเสร็จคืน — popup (popMonthlyReturn). receiveYear = พ.ศ. (service ลบ 543 ให้)</summary>
    Task<List<MonthlyReturnDetailDto>> GetMonthlyReturnDetailAsync(string membershipNo, int receiveYear, int receiveMonth, decimal seqNo);

    /// <summary>หักผ่านธนาคาร — รายการปี (พ.ศ.) สำหรับ combo (u_tabpg_mem_detail_month_giro_detail)</summary>
    Task<List<GiroYearDto>> GetGiroYearsAsync(string membershipNo);

    /// <summary>หักผ่านธนาคาร — เดือนล่าสุด (default) ของปีที่ระบุ. receiveYear = พ.ศ. (service ลบ 543 ให้)</summary>
    Task<int?> GetGiroLatestMonthAsync(string membershipNo, int receiveYear);

    /// <summary>หักผ่านธนาคาร — รายละเอียดเดือน (seq ล่าสุด). receiveYear = พ.ศ. (service ลบ 543 ให้)</summary>
    Task<List<GiroDetailDto>> GetGiroDetailAsync(string membershipNo, int receiveYear, int receiveMonth);

    // ── G5 "การเงิน/เงินฝาก" 3 tabs ────────────────────────────────────────────
    /// <summary>รายละเอียดเงินฝาก (u_tabpg_mem_detail_dept_detail — sc_dep_m_creditor + _rule)</summary>
    Task<List<DepositListDto>> GetDepositListAsync(string membershipNo);

    /// <summary>ข้อมูลเครดิต (u_tabpg_mem_detail_credit — sc_mem_m_member_credit)</summary>
    Task<List<CreditDto>> GetCreditAsync(string membershipNo);

    /// <summary>เงินรอจ่ายคืน (u_tabpg_mem_detail_money_return — sc_fin_money_return)</summary>
    Task<List<MoneyReturnDto>> GetMoneyReturnAsync(string membershipNo);

    // ── G5 popup popDeptDetail 3 sub-tabs (key = deposit_account_no ดิบ) ─────────
    /// <summary>ข้อมูลเงินฝาก — popup sub-tab 1 (u_tabpg_dept_detail_main — sc_dep_m_creditor)</summary>
    Task<DepositMainDto?> GetDepositMainAsync(string depositAccountNo);

    /// <summary>การเคลื่อนไหว — popup sub-tab 2 (u_tabpg_dept_detail_dept_detail — sc_dep_m_creditor_item)</summary>
    Task<List<DepositMovementDto>> GetDepositMovementAsync(string depositAccountNo);

    /// <summary>ภาระค้ำประกัน — popup sub-tab 3 (u_tabpg_dept_detail_dept_detail_coll — sc_lon_m_contract_coll)</summary>
    Task<List<DepositCollDto>> GetDepositCollAsync(string depositAccountNo);

    // ── G6 "รายละเอียดอื่น" 6 tabs ─────────────────────────────────────────────
    /// <summary>สถานะสมาชิก (u_tabpg_mem_detail_status_detail — sc_mem_m_member_special)</summary>
    Task<List<StatusDetailDto>> GetStatusDetailAsync(string membershipNo);

    /// <summary>สถานะธุรการ (u_tabpg_mem_admstatus — sc_mem_m_membership_registered, single row)</summary>
    Task<AdmstatusDto?> GetAdmstatusAsync(string membershipNo);

    /// <summary>บันทึกหมายเหตุ (u_tabpg_mem_comment_log — sc_mem_m_member_memo)</summary>
    Task<List<CommentLogDto>> GetCommentLogAsync(string membershipNo);

    /// <summary>ทุนการศึกษา (u_tabpg_mem_detail_sch_detail — sc_sch_mem_regis)</summary>
    Task<List<SchDetailDto>> GetSchDetailAsync(string membershipNo);

    /// <summary>อายัด (u_tabpg_mem_detail_sequester — sc_mem_m_membership_sequester)</summary>
    Task<List<SequesterDto>> GetSequesterAsync(string membershipNo);

    /// <summary>ดำเนินคดี (u_tabpg_mem_detail_law_prosec — sc_law_prosecutions)</summary>
    Task<List<LawProsecDto>> GetLawProsecAsync(string membershipNo);

    // ── popup ดำเนินคดี (popLaw) 11 sub-tabs (key = prosec_no) ──────────────────
    /// <summary>sub 1: ค่าธรรมเนียม/ประกัน (deposit_collection — sc_law_tadnen_kadee_fee)</summary>
    Task<List<LawDepositCollectionDto>> GetLawDepositCollectionAsync(string prosecNo);

    /// <summary>sub 2: จำเลย (collateral_detail — sc_law_prosec_defendants)</summary>
    Task<List<LawCollateralDetailDto>> GetLawCollateralDetailAsync(string prosecNo);

    /// <summary>sub 3: ภาระหนี้คงเหลือตามคำพิพากษา (loan_detailstatus — sc_law_prosec_loan)</summary>
    Task<List<LawLoanDetailStatusDto>> GetLawLoanDetailStatusAsync(string prosecNo);

    /// <summary>sub 4: ดำเนินคดี (dum_nern_kadee — sc_law_tad_nenkadee_operate) — default tab</summary>
    Task<List<LawDumNernKadeeDto>> GetLawDumNernKadeeAsync(string prosecNo);

    /// <summary>sub 5/7/9: หัวเรื่องคดี (sc_law_tad_nenkadee_head) — form single row (ใช้ร่วม 3 แท็บ)</summary>
    Task<LawKadeeHeadDto?> GetLawKadeeHeadAsync(string prosecNo);

    /// <summary>sub 6: หนังสือแจ้งการชำระ (book_alertpay — sc_law_tadnen_kadee_notice)</summary>
    Task<List<LawBookAlertpayDto>> GetLawBookAlertpayAsync(string prosecNo);

    /// <summary>sub 8: จำเลย (jumley_detail — sc_law_prosec_defendants)</summary>
    Task<List<LawJumleyDetailDto>> GetLawJumleyDetailAsync(string prosecNo);

    /// <summary>sub 10: ประเมินราคาที่ดิน — head combo (cascade: sc_law_land_appraisal_head item_code)</summary>
    Task<List<sc.ComboItem>> GetLawLandItemCodesAsync(string prosecNo);

    /// <summary>sub 10: ประเมินราคาที่ดิน — head form ตาม item_code</summary>
    Task<LawLandAppraisalHeadDto?> GetLawLandHeadAsync(string prosecNo, string itemCode);

    /// <summary>sub 10: ประเมินราคาที่ดิน — detail grid ตาม item_code (ofDetailCal ใน service)</summary>
    Task<List<LawLandAppraisalDetailDto>> GetLawLandDetailAsync(string prosecNo, string itemCode);

    /// <summary>sub 11: ขายทอดตลาด — head combo (cascade: sc_law_bung_kub_kadee_result seq_no_yed)</summary>
    Task<List<sc.ComboItem>> GetLawBungKubSeqAsync(string prosecNo);

    /// <summary>sub 11: ขายทอดตลาด — head form ตาม seq_no_yed</summary>
    Task<LawBungKubKadeeHeadDto?> GetLawBungKubHeadAsync(string prosecNo, string seqNoYed);

    /// <summary>sub 11: ขายทอดตลาด — detail grid ตาม seq_no_yed (sc_law_bang_kup_detail)</summary>
    Task<List<LawBungKubKadeeDetailDto>> GetLawBungKubDetailAsync(string prosecNo, string seqNoYed);

    // ── G7 "รายการแก้ไข" 14 tabs (change-log) ─────────────────────────────────────
    /// <summary>tab 1: ประวัติเปลี่ยนหลักประกัน (chg_coll_history)</summary>
    Task<List<CollChangeHistoryDto>> GetCollChangeHistoryAsync(string membershipNo);

    /// <summary>tab 2: เปลี่ยนรหัสโนติส (chg_debtor_code)</summary>
    Task<List<DebtorCodeChgDto>> GetDebtorCodeChgAsync(string membershipNo);

    /// <summary>tab 3: เปลี่ยนยอดชำระเงินกู้รายเดือน (chg_loan_send_month — view_tel_det_chg &lt;&gt; 'SHR')</summary>
    Task<List<SendMonthChgDto>> GetLoanSendMonthChgAsync(string membershipNo);

    /// <summary>tab 4: เปลี่ยนยอดส่งหุ้นรายเดือน (chg_share_send_month — view_tel_det_chg = 'SHR')</summary>
    Task<List<SendMonthChgDto>> GetShareSendMonthChgAsync(string membershipNo);

    /// <summary>tab 5: เปลี่ยนสถานะ/บันทึกช่วยจำ (chg_memo_status)</summary>
    Task<List<MemoStatusChgDto>> GetMemoStatusChgAsync(string membershipNo);

    /// <summary>tab 6: เปลี่ยนโครงการหุ้น-กู้ (chg_shareloan_code)</summary>
    Task<List<ShareloanCodeChgDto>> GetShareloanCodeChgAsync(string membershipNo);

    /// <summary>tab 7: ประวัติเปลี่ยนเกรด (chg_grade_history)</summary>
    Task<List<GradeHistoryChgDto>> GetGradeHistoryChgAsync(string membershipNo);

    /// <summary>tab 8: เปลี่ยนสถานะอื่น (chg_other_status)</summary>
    Task<List<OtherStatusChgDto>> GetOtherStatusChgAsync(string membershipNo);

    /// <summary>tab 9: เปลี่ยนการออมอื่น (chg_ot_saving_member)</summary>
    Task<List<OtSavingMemberChgDto>> GetOtSavingMemberChgAsync(string membershipNo);

    /// <summary>tab 10: ประวัติเปลี่ยนที่อยู่ (addresshistory)</summary>
    Task<List<AddressHistoryDto>> GetAddressHistoryAsync(string membershipNo);

    /// <summary>tab 11: ประวัติเปลี่ยนชื่อ-สกุล (namehistory)</summary>
    Task<List<NameHistoryDto>> GetNameHistoryAsync(string membershipNo);

    /// <summary>tab 12: ประวัติย้ายหน่วยงาน (movejobhistory)</summary>
    Task<List<MoveJobHistoryDto>> GetMoveJobHistoryAsync(string membershipNo);

    /// <summary>tab 13: ประวัติเปลี่ยนเงินเดือน (history_salary)</summary>
    Task<List<HistorySalaryDto>> GetHistorySalaryAsync(string membershipNo);

    /// <summary>tab 14: ประวัติเปลี่ยนสิทธิ์ (permit_changed)</summary>
    Task<List<PermitChangedDto>> GetPermitChangedAsync(string membershipNo);

    // ── G8 E-Document — ทะเบียนสมาชิก (edc_memregis) ──────────────────────────
    /// <summary>G8: เอกสารทะเบียนสมาชิก (sc_edoc_mem)</summary>
    Task<List<EdocMemDto>> GetEdocMemAsync(string membershipNo);

    /// <summary>G8: url เอกสาร/รูป สำหรับ popup (legacy popPDF.popEdocument, tab u_tabpg_edc_memregis)</summary>
    Task<EdocPdfResult> GetEdocMemPdfAsync(string membershipNo, string applicationFormNo, string docType, decimal pageNo);

    // ── G3: ประวัติการกู้ (loan_detail_history) ───────────────────────────────
    /// <summary>G3: ประวัติการกู้ทั้งหมด (view_tel_det_lon_zero)</summary>
    Task<List<LoanDetailHistoryDto>> GetLoanDetailHistoryAsync(string membershipNo);

    // ── G3: หลักประกัน (memcoll_detail) ───────────────────────────────────────
    /// <summary>G3: รายการหลักประกัน/ผู้ค้ำของสมาชิก</summary>
    Task<List<MemcollDetailDto>> GetMemcollDetailAsync(string membershipNo);

    // ── G6: วิธีชำระเงิน สมาคมฌาปนกิจ (cremation_paid_det) ─────────────────────
    /// <summary>G6: วิธีชำระเงินสมาคมฌาปนกิจ (sc_mem_m_member_cremation)</summary>
    Task<List<CremationPaidDetDto>> GetCremationPaidDetAsync(string membershipNo);

    // ── G6: สมาคมฌาปนกิจ (cremation_det) ──────────────────────────────────────
    /// <summary>G6: สมาคมฌาปนกิจ (view_tel_get_creamation)
    /// ⚠️ DEFERRED: view ยังไม่มีใน PG (federation 3 Oracle DB) → คืน list ว่าง</summary>
    Task<List<CremationDetDto>> GetCremationDetAsync(string membershipNo);

    // ── G6: สมาชิกสมทบ (userefer) ─────────────────────────────────────────────
    /// <summary>G6: สมาชิกสมทบที่สมาชิกนี้เป็นผู้อ้างอิงให้ (sc_mem_m_member_member_refer)</summary>
    Task<List<UsereferDto>> GetUsereferAsync(string membershipNo);

    // ── G7: ประวัติเปลี่ยนวิธีจ่ายปันผล (chg_recieve_dividend) ─────────────────
    /// <summary>G7: ประวัติเปลี่ยนวิธีจ่ายปันผล (sc_mem_edit_recieve_dividend)</summary>
    Task<List<ChgRecieveDividendDto>> GetChgRecieveDividendAsync(string membershipNo);

    // ── G8: สัญญาเงินกู้ (edc_loancontract) ────────────────────────────────────
    /// <summary>G8: เอกสารสัญญาเงินกู้ (sc_edoc_loan_contract)</summary>
    Task<List<EdocLoanContractDto>> GetEdocLoanContractAsync(string membershipNo);

    /// <summary>G8: url เอกสาร/รูป สัญญาเงินกู้ สำหรับ popup (sc_edoc_loan_contract)</summary>
    Task<EdocPdfResult> GetEdocLoanContractPdfAsync(string loanContractNo, string docType, decimal pageNo);

    // ── G4: เรียกเก็บรายเดือน (month_detail) ───────────────────────────────────
    /// <summary>G4: รายการปีที่มีข้อมูลเรียกเก็บ (พ.ศ., ล่าสุดก่อน) — SC_KEP_T_MONTHLY_RECEIVE</summary>
    Task<List<int>> GetMonthDetailYearsAsync(string membershipNo);

    /// <summary>G4: เดือนล่าสุดที่มีข้อมูลในปีนั้น (receiveYear = พ.ศ.)</summary>
    Task<int?> GetMonthDetailLatestMonthAsync(string membershipNo, int receiveYear);

    /// <summary>G4: header ใบเสร็จเรียกเก็บของ (ปี พ.ศ., เดือน)</summary>
    Task<MonthDetailHeadDto?> GetMonthDetailHeadAsync(string membershipNo, int receiveYear, int receiveMonth);

    /// <summary>G4: รายการรายละเอียดเรียกเก็บของ (ปี พ.ศ., เดือน)</summary>
    Task<List<MonthDetailRowDto>> GetMonthDetailRowsAsync(string membershipNo, int receiveYear, int receiveMonth);
}
