namespace sc
{
    // REMOVED: inner class scPrintForm — 100% DevExpress XtraReport rendering, not applicable in API
    // REMOVED: setCashBalance(ASPxGridView/ASPxCallbackPanel/ASPxCallback) — DevExpress UI
    // REMOVED: isProgrammer() — depended on HttpContext session
    // CHANGED: constructor takes sc.db directly (was sc.page)
    // CHANGED: ROWNUM < 2 → LIMIT 1
    // CHANGED: db.getSessionTable()/getSessionValue() → db.getValue()/getValueString()
    // CHANGED: sc.util.setSession/getSession removed — callers handle session state
    // CHANGED: sc.app.loginUser → passed as parameter where needed
    public class scCoop : sc.service
    {
        public const string emptyValue = "NULL";

        public scCoop(sc.db db) : base(db) { }

        // ─── Coop config ──────────────────────────────────────────────────────────

        public string getCoopName()
            => (db.getValue("select coop_name from sc_cnt_m_coop") ?? string.Empty).ToString()!;

        public string getCoopSysName()
            => db.getValueString("select sys_name from sc_cnt_m_coop").ToUpper();

        // CHANGED: ROWNUM < 2 → LIMIT 1
        public string getCoopBankDefault()
            => db.getValueString("select bank_id from sc_acc_m_ucf_bank where sort_order = 0 and contract_bank_status = '1' LIMIT 1");

        public string getCoopFinBankDefault()
            => db.getValueString("select bank_fin from sc_fin_m_bank where sort_order = 0 and close_status = '0' LIMIT 1");

        public object? getDepositDate()
            => db.pkFunction("pka_dep_daily.fp_deposit_date");

        public object? getFinanceDate()
            => db.pkFunction("pka_fin_daily.fp_finance_date('1')");

        public object? getCashBalance()
            => db.pkFunction("pka_fin_daily.fp_cash_balance");

        // ─── Branches / Users ─────────────────────────────────────────────────────

        public List<Dictionary<string, object?>> getCoopBranches()
            => db.getValueT("select branch_id ,branch_name from sc_com_m_branch order by branch_id");

        public List<Dictionary<string, object?>> getSecurityUsers()
            => db.getValueT(@"select distinct s_user.user_id ,branch_id ,close_status, flg_first_login, s_group.c_status
                    from si_security_user s_user, si_security_user_group s_user_group, si_security_group s_group
                    where s_user.user_id = s_user_group.user_id
                      and s_user_group.group_id = s_group.group_id");

        // ─── Member no ────────────────────────────────────────────────────────────

        /// <summary>เติม 0 หน้า + ตรวจสอบว่ามีในระบบ</summary>
        public string ofParse(string membership_no)
        {
            var (formatted, _) = ofFormat(membership_no);
            if (!string.IsNullOrWhiteSpace(formatted))
                ofValidMemno(formatted, alert: true);
            return formatted;
        }

        // CHANGED: removed sc.util.setSession("MessageMembershipno") → returns message as second tuple value
        public (string membershipNo, string message) ofFormat(string membership_no)
        {
            if (string.IsNullOrWhiteSpace(membership_no))
                return (string.Empty, string.Empty);

            var size = sc.value.toInteger(db.getValue("select size_member_no from sc_cnt_m_coop"));
            if (size < 5) size = 5;

            bool hasLetter = membership_no.Any(char.IsLetter);
            var formatted  = hasLetter
                ? membership_no.Trim()
                : membership_no.Trim().PadLeft(size, '0');

            var message = string.Empty;
            if (!hasLetter)
            {
                message = sc.value.toString(db.pkFunction("PKA_MEM_MSGALERT.fp_msg", formatted));
                message = message?.Replace("!NL!", Environment.NewLine) ?? string.Empty;
            }

            return (formatted, message);
        }

        public bool ofValidMemno(string membership_no, bool alert = false)
        {
            bool valid = db.getCount("sc_mem_m_membership_registered",
                db.sqlArgs("where membership_no = {0}", membership_no)) == 1;
            if (!valid && alert)
                throw new Exception("E43:ไม่พบทะเบียนสมาชิก ," + membership_no);
            return valid;
        }

        public bool ofValidMemnoInvest(string membership_no, bool alert = false)
        {
            bool valid = db.getCount("sc_mem_m_membership_registered",
                db.sqlArgs("where membership_no = {0} and invest_status = '1'", membership_no)) == 1;
            if (!valid && alert)
                throw new Exception("C158 ไม่ใช่ทะเบียนองค์กร ไม่สามารถทำรายการได้! ," + membership_no);
            return valid;
        }

        public string getFullName(string membership_no)
            => (db.getValue(@"select (select prename from sc_mem_m_ucf_prename where prename_code = r.prename_code)
                ||' '||r.member_name||'  '||r.member_surname
                from sc_mem_m_membership_registered r
                where membership_no = {0}", membership_no) ?? string.Empty).ToString()!;

        public string getGroupName(string membership_no)
            => sc.value.toString(db.pkFunction("pka_com_function.fp_get_group_name_mem", membership_no));

        // ─── Permit ───────────────────────────────────────────────────────────────

        public bool isPermitActive(string appName, string security_code)
        {
            var active = sc.value.toString(db.getValue(
                "select active_status from sc_security_permit_ucf where applications = {0} and security_code = {1}",
                appName, security_code));
            return active == "1";
        }

        public int ofPermitInstall(string request_remark, string? specify_permit_id = null,
            List<object>? items = null, decimal request_amount = 0, string as_ref_no = "")
        {
            var request_group = sc.value.toInteger(db.pkFunction("pka_sec_permit.fp_max_request_group")) + 1;

            db.pkProcedure("pka_sec_permit.sp_post_permit_h",
                request_group, request_remark, specify_permit_id, request_amount, as_ref_no);

            if (items != null)
            {
                foreach (var itemx in items)
                {
                    if (itemx is not Dictionary<string, object> item) continue;
                    if (sc.value.toString(item, "cancel_status") == "1") continue;
                    var security_code  = sc.value.toString(item, "security_code");
                    var security_remark = sc.value.toString(item, "security_remark");
                    db.pkProcedure("pka_sec_permit.sp_post_permit_d",
                        request_group, security_code, security_remark);
                }
            }

            return request_group;
        }

        public void ofPermitApprove(string request_id, int request_group, string permit_result)
            => db.pkProcedure("pka_sec_permit.sp_post_approve", request_id, request_group, permit_result);

        // CHANGED: loginUser must be passed by caller (was sc.app.loginUser from session)
        public string ofPermitValidate(Dictionary<string, object> vals, string loginUser)
        {
            var money_type    = sc.value.toString(vals, "money_type");
            var security_code = sc.value.toString(vals, "security_code");
            var item_amount   = sc.value.toDecimal(vals, "item_amount");
            var as_cash       = money_type == "01" ? "1" : money_type == "N" ? "N" : "0";
            var remark        = sc.value.toString(vals, "remark");
            return sc.value.toString(db.pkFunction(
                "pka_sec_permit.fp_validmsg_permit", security_code, as_cash, loginUser, item_amount, remark));
        }

        // ─── E-document signature ─────────────────────────────────────────────────

        // CHANGED: urlServerEdocument must be passed by caller (was sc.app.getAppSettings("UrlServerEdocument"))
        public string getSignatureEdoc(string membership_no, string urlServerEdocument)
        {
            var page_no = db.getValueString(@"select max(page_no)||'' as page_no from sc_edoc_mem
                where 1=1 and doc_type = '05' and membership_no = {0} and filename != 'DELETED'
                order by page_no", membership_no);

            if (string.IsNullOrEmpty(page_no))
                return "C321 ยังไม่มีลายเซ็น";

            var detail   = db.getValueR(@"select filename,entry_id,entry_date from sc_edoc_mem
                where membership_no = {0} and doc_type = '05' and page_no = {1}", membership_no, page_no);
            var filename = sc.value.toString(detail, "filename");

            var path = db.getValueString("select FILE_INI_ADDRESS||MEMBER_NEW_FOLDER from SC_EDOC_CONSTANT where SEQ_NO = '1' and USE_PDF = '1'");
            path = path.Replace("\\", "//");

            if (string.IsNullOrWhiteSpace(path)) return "C336 ไม่พบตำแหน่งเก็บไฟล์";
            if (string.IsNullOrWhiteSpace(filename)) return "C340 ไม่พบชื่อไฟล์";

            return "../ctr/panImgAndPdf.aspx?FILE=" + urlServerEdocument + path + "//" + filename;
        }

        // ─── Deposit print form ───────────────────────────────────────────────────

        public string getDepPrintForm(string dw_print_where, string deposit_type_code)
        {
            var ruleRow = db.getValueR(@"select dw_print_card,dw_print_passbook_fp,dw_print_passbook_item,
                dw_print_slip,dw_print_interest,dw_print_withdraw_fee,dw_print_slip_withdraw,dw_statement
                from sc_dep_m_rule where deposit_type_code = {0}", deposit_type_code);

            var constRow = db.getValueR(@"select dw_print_card,dw_print_passbook_fp,dw_print_passbook_item,
                dw_print_slip,dw_print_interest,dw_print_withdraw_fee,dw_print_slip_withdraw,dw_statement
                from sc_dep_m_constant");

            var result = sc.value.toString(ruleRow, dw_print_where);
            if (string.IsNullOrWhiteSpace(result))
                result = sc.value.toString(constRow, dw_print_where);
            return result;
        }

        // ─── ID Card sync ─────────────────────────────────────────────────────────

        // CHANGED: removed HttpContext.Current + sc.util.getSession — caller passes idCardData + pageApplication directly
        // CHANGED: removed page.isEnableIDScan() — caller checks before calling
        public void ofSaveCardInfo(string pageApplication, string ref_docno, Dictionary<string, object>? idCardData)
        {
            var ls_data = string.Empty;
            if (idCardData != null && idCardData.Count > 0)
            {
                var parts = idCardData.Select((kv, i) => kv.Key + "=" + kv.Value);
                ls_data = string.Join("&", parts);
            }
            db.pkProcedure("pka_mid_sync.sp_insert_activate", pageApplication, ref_docno, ls_data);
        }
    }
}
