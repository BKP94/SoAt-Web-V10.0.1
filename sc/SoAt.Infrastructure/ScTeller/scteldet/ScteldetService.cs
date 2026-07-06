using SoAt.Application.ScTeller;

namespace SoAt.Infrastructure.ScTeller;

/// <summary>
/// scteldet — ประวัติสมาชิก (Member Profile Viewer). impl ของ <see cref="IScteldetService"/>.
/// migrate SQL จาก legacy C:\SoAt_PEAN\scTeller\scteldet (read-only viewer):
///   Oracle→PG: NVL→COALESCE, DECODE→CASE, ROWNUM&lt;=1→ORDER BY..LIMIT 1, '||' null-safe ด้วย COALESCE,
///   UNPIVOT→CROSS JOIN LATERAL VALUES. pkg function ที่ migrate แล้วเรียกตรง (schema-qualified ได้ใน PG).
/// STUB (ยังไม่ migrate): fp_get_insure_cost→0, cremation federation (view_tel_get_creamation 3 DB).
/// </summary>
public class ScteldetService(sc.dbFactory dbFactory) : IScteldetService
{
    // ════════════════════════════════════════════════════════════════════════
    //  Dynamic permission-driven tab metadata (legacy panTabs.ascx.cs)
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<TabGroupDto>> GetTabMetadataAsync()
    {
        await using var scDb = dbFactory.create();

        // กลุ่ม = i_level=4 (NavBar group). legacy: i_parent_id=1 (= ลำดับเมนู level-3), i_sequence คือ ordinal ของกลุ่ม
        var groups = await scDb.getListAsync<TabGroupDto>(@"
            SELECT i_menu_id AS group_id, app_text AS group_text, COALESCE(i_sequence, order_no, 0) AS sequence
            FROM si_security_apps
            WHERE i_level = 4 AND sub_app_name = 'scteldet' AND active = true
            ORDER BY COALESCE(i_sequence, order_no, 0), i_menu_id");

        // แท็บ = i_level=5 (s_url = ชื่อ component .razor ตรงๆ → PanTabs.ResolveType GetType ตรง)
        var tabs = await scDb.getListAsync<TabItemDto>(@"
            SELECT i_menu_id AS tab_id, i_parent_id AS parent_id, app_text AS text,
                   s_url AS url, COALESCE(i_sequence, order_no, 0) AS sequence
            FROM si_security_apps
            WHERE i_level = 5 AND sub_app_name = 'scteldet' AND active = true AND s_url IS NOT NULL
            ORDER BY i_parent_id, COALESCE(i_sequence, order_no, 0), i_menu_id");

        // legacy panTabs.ascx.cs: _tabs.Select(""i_parent_id = "" + btIndex) — แท็บสังกัดกลุ่มด้วย
        //   tab.i_parent_id == group.i_sequence (ordinal 1..8) ไม่ใช่ group.i_menu_id
        foreach (var g in groups)
            g.Tabs = tabs.Where(t => t.ParentId == g.Sequence).ToList();

        return groups;
    }

    // ════════════════════════════════════════════════════════════════════════
    //  Header (legacy panHead.ascx dsHead)
    // ════════════════════════════════════════════════════════════════════════
    public async Task<ScteldetHeaderDto?> GetMemberHeaderAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();

        // เลขทะเบียน: เติม 0 หน้า + ตรวจว่ามีในระบบ (legacy pageForm.change_membership_no: page._membership_no = scCoop.ofParse(...))
        //   ofParse pad zeros ตาม size_member_no (sc_cnt_m_coop) + ofValidMemno (throw E43 ถ้าไม่พบ)
        //   ค่า padded ที่ return จะไหลไป _model.MembershipNo → ทุก tab ใช้ค่า padded เดียวกัน เหมือน legacy
        var coop = new sc.scCoop(scDb);
        try { membershipNo = coop.ofParse(membershipNo); }
        catch { return null; }   // ไม่พบทะเบียน → Page แสดง "ไม่พบสมาชิกเลขทะเบียน [x]"
        if (string.IsNullOrWhiteSpace(membershipNo)) return null;

        // หมายเหตุ faithful: '||' ใน PG null = NULL ทั้งสตริง (Oracle ถือ null=ว่าง) → ห่อ COALESCE
        //   insurance_cost STUB 0 (fp_get_insure_cost ยังไม่ migrate), cram STUB '' (federation 3 Oracle DB)
        return await scDb.getOneAsync<ScteldetHeaderDto>(@"
            SELECT reg.membership_no
                ,pka_com_function.fp_get_member_name(reg.membership_no) AS member_name
                ,COALESCE(reg.prename_eng,'')||' '||COALESCE(reg.name_eng,'')||' '||COALESCE(reg.surname_eng,'') AS eng_name
                ,reg.mem_type
                ,reg.member_group_no
                ,(SELECT COALESCE(member_group_no,'')||' - '||COALESCE(member_group_name,'')
                    FROM sc_mem_m_ucf_member_group WHERE member_group_no = reg.member_group_no) AS member_group_name
                ,reg.member_status_code
                ,reg.date_of_birth
                ,substr(pka_lon_reqsrv.fp_calc_agetext(pka_lon_reqsrv.fp_calc_install_m_age(reg.membership_no)),1,30) AS age_mem_text
                ,CASE WHEN reg.member_status_code = '3' THEN reg.resignation_approve_date ELSE NULL END AS resignation_approve_date
                ,reg.approve_date
                ,substr(pka_lon_reqsrv.fp_calc_agetext_m_live(reg.membership_no),1,30) AS age_life_text
                ,pka_lon_reqsrv.fp_calc_member_retire(reg.membership_no, reg.date_of_birth, 60) AS retire_date
                ,reg.sex
                ,reg.blood_code
                ,reg.id_card
                ,reg.deposit_account_id
                ,reg.remark
                ,0.00 AS insurance_cost
                ,pka_insure_paysrv.fp_get_insure_approve(reg.membership_no) AS insurance_pay
                ,reg.other_code, reg.marriage_status
                ,fpa_mobile_get_active(reg.membership_no) AS mobile_number
                ,(SELECT salary_real FROM sc_mem_m_member_work_info WHERE membership_no = reg.membership_no) AS salary_amount
                ,(SELECT salary_id   FROM sc_mem_m_member_work_info WHERE membership_no = reg.membership_no) AS salary_id
                ,pka_com_function.fp_get_member_address_pres(reg.membership_no) AS address
                ,pka_com_function.fp_get_member_address_perm(reg.membership_no) AS address_t
                ,tab.share_stock, tab.share_amount, tab.period_recrieve
                ,(SELECT first_date FROM sc_mem_m_member_own_info WHERE membership_no = reg.membership_no) AS first_date
                -- legacy fp_calc_agetext(first_date) → adt_req default = sysdate; PG overload ไม่มี default → ส่ง CURRENT_TIMESTAMP ชัดเจน (faithful)
                ,(SELECT pka_lon_reqsrv.fp_calc_agetext(first_date, LOCALTIMESTAMP) FROM sc_mem_m_member_own_info WHERE membership_no = reg.membership_no) AS agetext_member_first_date
                ,(SELECT position_code FROM sc_mem_m_member_work_info WHERE membership_no = reg.membership_no) AS position_long
                ,reg.total_loan_int
                , 0.00 AS other_amount
                ,reg.method_recieve_dividend
                ,0 AS academic_salary
                ,reg.resign_code
                ,reg.dead_date
                ,reg.retire_id
                ,reg.retire_text
                ,reg.email
                ,fp_get_bank_div(reg.membership_no) AS acc_no_rec_div
                ,'' AS cram
                ,tab.drop_status
                ,reg.election_group
                ,pka_lon_reqsrv.fp_calc_agetext(reg.approve_date
                ,pka_lon_reqsrv.fp_calc_member_retire(reg.membership_no, reg.date_of_birth, 60)) AS age_mem_60
            FROM sc_mem_m_membership_registered reg,
            (SELECT membership_no, share_stock, share_amount, period_recrieve, pending_amt, drop_status
            FROM sc_mem_m_share_mem) tab
            WHERE tab.membership_no = reg.membership_no
                AND reg.membership_no = {0}", membershipNo);
    }

    public async Task<byte[]?> GetMemberPhotoAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        var o = await scDb.getValueAsync(
            "SELECT mem_picture FROM sc_mem_m_member_picture WHERE membership_no = {0}", membershipNo);
        return o as byte[];
    }

    public async Task<byte[]?> GetMemberSignatureAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        var o = await scDb.getValueAsync(
            "SELECT mem_signature FROM sc_mem_m_member_signature WHERE membership_no = {0}", membershipNo);
        return o as byte[];
    }

    // อ่านบัตร ปชช. → membership_no (legacy pka_mid_sync.fp_find_memno)
    //  ลาออกสมัครใหม่ (id ซ้ำ) → เลือกทะเบียนสถานะปกติ; ไม่พบ → null
    public async Task<string?> LookupMemberByIdCardAsync(string idCard)
    {
        await using var scDb = dbFactory.create();
        var o = await scDb.getValueAsync("SELECT pka_mid_sync.fp_find_memno({0})", idCard);
        return o as string;
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G1 Tab 1 — ครอบครัว (u_tabpg_mem_spouse_info)
    // ════════════════════════════════════════════════════════════════════════
    public async Task<SpouseInfoDto?> GetSpouseInfoAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getOneAsync<SpouseInfoDto>(@"
            SELECT spouse_member_no, prename_code, spouse_name, spouse_surname,
                   occupation_code, salary_amount, salary_calloan, date_of_birth,
                   position_code, id_card, tax_id, workname,
                   work_address, work_moo, work_soi, work_road, work_tambol,
                   work_district_code, work_province_code, work_postcode, work_telephone
            FROM sc_mem_m_member_spouse_info WHERE membership_no = {0}", membershipNo);
    }

    public async Task<ParentInfoDto?> GetParentInfoAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getOneAsync<ParentInfoDto>(
            "SELECT father, mother FROM sc_mem_m_membership_registered WHERE membership_no = {0}", membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G1 Tab 2 — การทำงาน (u_tabpg_mem_detail_work_info) — ROWNUM<=1 → ORDER BY seq_no LIMIT 1
    // ════════════════════════════════════════════════════════════════════════
    public async Task<WorkMainDto?> GetWorkMainAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getOneAsync<WorkMainDto>(@"
            SELECT membership_no, position_long, employee_status, endingcontract_date,
                   keeping_group_no, level_code, salary_rate_code, salary_amount, academic_salary,
                   working_date, group_position, retire_status, retire_date, occupation_code,
                   remuneration_amount, salary_id, department_code, salary_real
            FROM sc_mem_m_member_work_info
            WHERE membership_no = {0}
            ORDER BY seq_no LIMIT 1", membershipNo);
    }

    public async Task<WorkAddressDto?> GetWorkAddressAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getOneAsync<WorkAddressDto>(@"
            SELECT membership_no, work_address, work_moo, work_soi, work_road, work_tambol,
                   work_province_code, work_district_code, work_postcode, work_telephone
            FROM sc_mem_m_member_work_info
            WHERE membership_no = {0}
            ORDER BY seq_no LIMIT 1", membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G1 Tab 3 — สมาชิกโอนมา (u_tabpg_mem_own)
    // ════════════════════════════════════════════════════════════════════════
    public async Task<OwnInfoDto?> GetOwnInfoAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getOneAsync<OwnInfoDto>(@"
            SELECT membership_no, other_saving, own_total_loan, mati_detail, first_date
            FROM sc_mem_m_member_own_info WHERE membership_no = {0}", membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G1 Tab 4 — ผู้รับผลประโยชน์ (u_tabpg_mem_detail_gain_detail)
    //  FPA_GET_GAIN_ADDRESS migrate แล้วใน PG; DECODE gain_status→CASE
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<GainDetailDto>> GetGainDetailAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<GainDetailDto>(@"
            SELECT g.membership_no,
                   h.change_doc_no,
                   COALESCE(h.condition_1,'-') AS condition_1,
                   g.order_number,
                   trim(p.prename) || trim(g.gain_name) || '  ' || trim(g.gain_surname) AS gain_name,
                   c.related_na,
                   g.book_date,
                   fpa_get_gain_address(g.membership_no, g.rec_no::integer) AS gain_address,
                   COALESCE(g.gain_percent,0) AS gain_percent,
                   g.gain_id_card, g.gain_telephone,
                   CASE WHEN g.gain_status = '0' THEN 'ปกติ' ELSE 'ยกเลิก' END AS gain_status_desc,
                   g.gain_status, g.rec_no, g.rec_date
            FROM sc_mem_m_member_recrieve_gain g,
                 sc_mem_m_member_recrieve_gain_head h,
                 sc_mem_m_ucf_prename p,
                 sc_mem_m_ucf_concern c
            WHERE g.membership_no = h.membership_no
              AND g.change_doc_no = h.change_doc_no
              AND g.prename_code  = p.prename_code
              AND g.conceern_code = c.conceern_code
              AND g.membership_no = {0}
            ORDER BY g.gain_status ASC, h.change_doc_no ASC, g.order_number ASC, g.rec_no ASC", membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G1 Tab 5 — ปันผลเฉลี่ยคืน (u_tabpg_mem_detail_devidend_detail)
    //  ปี: คืน account_year (ค.ศ.) — frontend แสดง +543 (พ.ศ.) ตาม sc.* convention
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<DevidendYearDto>> GetDevidendYearsAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        // account_year ใน PG เป็น double precision (Oracle NUMBER) → cast ::integer ให้ตรง DTO int (ปีเป็นจำนวนเต็ม)
        return await scDb.getListAsync<DevidendYearDto>(@"
            SELECT account_year::integer AS account_year
            FROM sc_mem_m_capital_stock_detail
            WHERE membership_no = {0}
            GROUP BY account_year
            ORDER BY account_year DESC", membershipNo);
    }

    public async Task<DevidendHeadDto?> GetDevidendHeadAsync(string membershipNo, int accountYear)
    {
        await using var scDb = dbFactory.create();
        // DECODE(NVL(drop_*,0),'0',amt,0) → drop flag เป็น text → CASE WHEN COALESCE(drop_*,'0')='0'
        return await scDb.getOneAsync<DevidendHeadDto>(@"
            SELECT stock.account_year::integer AS account_year,
                   stock.dividend, stock.drop_dividend, stock.average_return, stock.drop_average,
                   stock.group_pay_code, stock.total_interest,
                   stock.somtob_amount
                     + CASE WHEN COALESCE(stock.drop_dividend,'0')='0'     THEN stock.dividend          ELSE 0 END
                     + CASE WHEN COALESCE(stock.drop_average,'0')='0'      THEN stock.average_return     ELSE 0 END
                     + CASE WHEN COALESCE(stock.drop_money_reward,'0')='0' THEN stock.total_money_reward ELSE 0 END AS total_pay,
                   stock.full_interest, stock.bank_acc_no,
                   rate.share_rate * 100 AS share_rate, rate.lonint_rate * 100 AS lonint_rate,
                   stock.divavr_seize, stock.divavr_byshare, stock.total_money_reward,
                   stock.drop_money_reward, stock.somtob_amount, stock.bank_code
            FROM sc_mem_m_capital_stock_detail stock, sc_mem_m_capital_rate rate
            WHERE stock.account_year = rate.lon_year
              AND stock.membership_no = {0}
              AND stock.account_year = {1}", membershipNo, accountYear);
    }

    public async Task<List<GotintDto>> GetDevidendGotintAsync(string membershipNo, int accountYear)
    {
        await using var scDb = dbFactory.create();
        // Oracle UNPIVOT(got_int for col in (m01..m12)) → PG CROSS JOIN LATERAL VALUES (faithful)
        return await scDb.getListAsync<GotintDto>(@"
            SELECT v.got_int
            FROM sc_mem_m_capital_gotint g
            CROSS JOIN LATERAL (VALUES
                ('m01', g.m01), ('m02', g.m02), ('m03', g.m03), ('m04', g.m04),
                ('m05', g.m05), ('m06', g.m06), ('m07', g.m07), ('m08', g.m08),
                ('m09', g.m09), ('m10', g.m10), ('m11', g.m11), ('m12', g.m12)
            ) AS v(col, got_int)
            WHERE g.account_year = {1} AND g.membership_no = {0}
            ORDER BY v.col", membershipNo, accountYear);
    }

    public async Task<List<DividendDetailDto>> GetDevidendDetailAsync(string membershipNo, int accountYear)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<DividendDetailDto>(@"
            SELECT sc_mem_m_capital_stock_detail.account_year::integer AS account_year,
                   sc_mem_m_share_holding_pre.seq_no AS pre_seq_no,
                   sc_mem_m_share_holding_pre.operate_date AS pre_operate_date,
                   sc_mem_m_share_holding_pre.item_type || ' - ' ||
                     (SELECT item_type_description FROM sc_mem_m_ucf_share_item_type
                       WHERE item_type = sc_mem_m_share_holding_pre.item_type) AS pre_item_type,
                   sc_mem_m_share_holding_pre.share_value AS pre_share_value,
                   (CASE WHEN sc_mem_m_share_holding_pre.day_count > 0
                         THEN to_tdate(sc_mem_m_share_holding_pre.effect_date) || ' - ' || to_tdate(sc_lon_m_close_year.end_date)
                         ELSE '-' END) AS cal_pre_date,
                   sc_mem_m_share_holding_pre.day_count AS pre_day_count,
                   sc_mem_m_share_holding_pre.dividend AS pre_dividend
            FROM sc_mem_m_capital_stock_detail,
                 sc_mem_m_share_holding_pre,
                 sc_acc_m_account_year,
                 sc_lon_m_close_year
            WHERE sc_mem_m_capital_stock_detail.account_year = sc_mem_m_share_holding_pre.account_year
              AND sc_mem_m_capital_stock_detail.membership_no = sc_mem_m_share_holding_pre.membership_no
              AND sc_mem_m_capital_stock_detail.account_year = sc_acc_m_account_year.account_year
              AND sc_mem_m_capital_stock_detail.account_year = sc_lon_m_close_year.lon_year
              AND sc_mem_m_capital_stock_detail.membership_no = {0}
              AND sc_mem_m_capital_stock_detail.account_year = {1}", membershipNo, accountYear);
    }

    public async Task<List<DevidendPaymentDto>> GetDevidendPaymentAsync(string membershipNo, int accountYear)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<DevidendPaymentDto>(@"
            SELECT account_year::integer AS account_year, membership_no, seq_no, group_pay_code, item_amount,
                   bank_code, bank_branch, bank_acc_no, post_status, post_date, post_refno,
                   '   ' AS account_type, loan_contract_no, principal_amount, interest_amount,
                   balance, interest_to, ext_status, post_amount, isp_type_code
            FROM sc_mem_m_capital_pay
            WHERE 1=1 AND account_year = {1} AND membership_no = {0}", membershipNo, accountYear);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G1 Tab 6 — ปันผลรวมทุกปี (u_tabpg_mem_detail_devidend_detail_all)
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<DevidendAllDto>> GetDevidendAllAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<DevidendAllDto>(@"
            SELECT (sc_mem_m_capital_stock_detail.account_year + 543)::integer AS account_year,
                   sc_mem_m_capital_rate.share_rate * 100 AS share_rate,
                   CASE WHEN sc_mem_m_capital_stock_detail.drop_dividend = '1' THEN 'งด' ELSE '' END AS drop_dividend,
                   CASE WHEN sc_mem_m_capital_stock_detail.drop_dividend = '1' THEN 0 ELSE sc_mem_m_capital_stock_detail.dividend END AS dividend,
                   sc_mem_m_capital_rate.lonint_rate * 100 AS lonint_rate,
                   CASE WHEN sc_mem_m_capital_stock_detail.drop_average = '1' THEN 'งด' ELSE '' END AS drop_average,
                   CASE WHEN sc_mem_m_capital_stock_detail.drop_average = '1' THEN 0 ELSE sc_mem_m_capital_stock_detail.average_return END AS average_return,
                   CASE WHEN sc_mem_m_capital_stock_detail.drop_money_reward = '1' THEN 0 ELSE sc_mem_m_capital_stock_detail.total_money_reward END AS total_money_reward,
                   COALESCE((SELECT sum(sc_mem_m_capital_pay.item_amount)
                               FROM sc_mem_m_capital_pay
                              WHERE 1=1 AND sc_mem_m_capital_pay.ext_status = '1'
                                AND sc_mem_m_capital_pay.membership_no = sc_mem_m_capital_stock_detail.membership_no
                                AND sc_mem_m_capital_pay.account_year = sc_mem_m_capital_stock_detail.account_year), 0) AS expense,
                   sc_mem_m_capital_stock_detail.member_group_no,
                   (SELECT money_type_name FROM sc_com_m_ucf_money_type
                     WHERE money_type_id = sc_mem_m_capital_pay.group_pay_code) AS money_type_name,
                   sc_mem_m_capital_pay.item_amount,
                   sc_mem_m_capital_pay.bank_code,
                   sc_mem_m_capital_pay.bank_acc_no,
                   CASE WHEN sc_mem_m_capital_stock_detail.drop_dividend = '1' THEN 0 ELSE sc_mem_m_capital_stock_detail.dividend END
                 + CASE WHEN sc_mem_m_capital_stock_detail.drop_average = '1' THEN 0 ELSE sc_mem_m_capital_stock_detail.average_return END
                 + CASE WHEN sc_mem_m_capital_stock_detail.drop_money_reward = '1' THEN 0 ELSE sc_mem_m_capital_stock_detail.total_money_reward END AS total
            FROM sc_mem_m_capital_stock_detail,
                 sc_mem_m_capital_rate,
                 sc_mem_m_capital_pay
            WHERE sc_mem_m_capital_stock_detail.account_year = sc_mem_m_capital_rate.lon_year
              AND sc_mem_m_capital_stock_detail.account_year = sc_mem_m_capital_pay.account_year
              AND sc_mem_m_capital_stock_detail.membership_no = sc_mem_m_capital_pay.membership_no
              AND sc_mem_m_capital_stock_detail.membership_no = {0}
              AND sc_mem_m_capital_pay.ext_status = '0'
            ORDER BY sc_mem_m_capital_stock_detail.account_year DESC", membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G1 Tab 7 — บัญชีธนาคาร (u_tabpg_mem_bankinfo)
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<BankInfoDto>> GetBankInfoAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<BankInfoDto>(@"
            SELECT membership_no, bank_id, bank_acc_no, paid_loan, paid_dividen, share_withdraw,
                   atm_lon, atm_dep, bank_branch_id, mustcoll_loan, seq_no, paid_agent, paid_salary
            FROM sc_mem_m_member_bank_accno
            WHERE membership_no = {0}
            ORDER BY seq_no", membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G1 Tab 8 — ATM (u_tabpg_mem_detail_atm) — UNION บัญชีฝาก + บัญชีกู้ (close_status='0')
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<AtmDto>> GetAtmAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<AtmDto>(@"
            SELECT sc_atm_dep_creditor.deposit_account_no, sc_atm_dep_creditor.bank_code,
                   sc_atm_dep_creditor.approve_amount, sc_atm_dep_creditor.withdrawable_amount,
                   sc_atm_dep_creditor.modify_status, ' ' AS drop_status,
                   sc_dep_m_creditor.membership_no, sc_atm_dep_creditor.new_send_status,
                   sc_atm_dep_creditor.close_status, sc_atm_dep_creditor.current_account,
                   sc_atm_dep_creditor.seq_no, sc_atm_dep_creditor.date_regis
            FROM sc_atm_dep_creditor, sc_dep_m_creditor
            WHERE sc_atm_dep_creditor.deposit_account_no = sc_dep_m_creditor.deposit_account_no
              AND sc_dep_m_creditor.membership_no = {0}
              AND sc_atm_dep_creditor.close_status = '0'
            UNION
            SELECT sc_atm_lon_card.loan_contract_no, sc_atm_lon_card.bank_code,
                   sc_lon_m_contract.loan_approve_amount, sc_atm_lon_card.press_amount_real,
                   sc_atm_lon_card.modify_status, ' ' AS drop_status,
                   sc_lon_m_contract.membership_no, sc_atm_lon_card.new_send_status,
                   sc_atm_lon_card.close_status, sc_atm_lon_card.current_account,
                   sc_atm_lon_card.seq_no, sc_lon_m_contract.begining_of_contract
            FROM sc_atm_lon_card, sc_lon_m_contract, sc_lon_m_loan_card
            WHERE sc_atm_lon_card.loan_contract_no = sc_lon_m_contract.loan_contract_no
              AND sc_lon_m_contract.loan_contract_no = sc_lon_m_loan_card.loan_contract_no
              AND sc_lon_m_contract.membership_no = {0}
              AND sc_atm_lon_card.close_status = '0'", membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G1 Tab 9 — เบอร์มือถือ (u_tabpg_mem_mobile_number)
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<MobileDto>> GetMobileAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<MobileDto>(@"
            SELECT membership_no, seq_no, bank_id, mobile_number, close_status,
                   mobile_lon, mobile_dep, mobile_trans,
                   CASE WHEN close_status = '0' THEN '1' ELSE '0' END AS close_status_cb,
                   CASE WHEN mobile_lon   = 'Y' THEN '1' ELSE '0' END AS mobile_lon_cb,
                   CASE WHEN mobile_dep   = 'Y' THEN '1' ELSE '0' END AS mobile_dep_cb,
                   CASE WHEN mobile_trans = 'Y' THEN '1' ELSE '0' END AS mobile_trans_cb,
                   entry_id, entry_date, entry_br
            FROM sc_mobile_regis
            WHERE membership_no = {0}
            ORDER BY seq_no", membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G1 Tab 10 — ประวัติสัมมนา (u_tabpg_mem_surminar)
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<SurminarDto>> GetSurminarAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<SurminarDto>(@"
            SELECT s.membership_no, s.seq_no, s.operate, s.remark
            FROM sc_mem_surminar s, sc_mem_m_membership_registered r
            WHERE r.membership_no = s.membership_no
              AND s.membership_no = {0}
            ORDER BY s.membership_no, s.seq_no", membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G2 Tab 1 — สวัสดิการ (u_tabpg_mem_detail_welfare — view_tel_mem_wef)
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<WelfareDto>> GetWelfareAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<WelfareDto>(@"
            SELECT wef_type, wef_desc, operate_date, total_receive,
                   approve_status, approve_date, wef_detail
            FROM view_tel_mem_wef
            WHERE membership_no = {0}
            ORDER BY approve_date DESC", membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G2 Tab 2 — สมาคมฌาปนกิจ (u_tabpg_mem_detail_smk — sc_mem_m_member_cremation)
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<SmkDto>> GetSmkAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<SmkDto>(@"
            SELECT crem_type, crem_memno
            FROM sc_mem_m_member_cremation
            WHERE membership_no = {0}", membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G2 Tab 3 — ประกัน (u_tabpg_mem_detail_insurance_detail)
    //    sc_mem_m_insure JOIN sc_mem_m_insure_rule JOIN sc_mem_m_membership_registered
    //    เฉพาะ insurance_status='0' (ยังคงสัญญา) ตาม legacy
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<InsureDto>> GetInsureAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<InsureDto>(@"
            SELECT sc_mem_m_insure.membership_no, sc_mem_m_insure.insurance_no,
                   sc_mem_m_insure.insurance_type, sc_mem_m_insure.ref_contract,
                   sc_mem_m_insure.insurance_detail, sc_mem_m_insure.insurance_approve,
                   sc_mem_m_insure.insurance_balance, sc_mem_m_insure.insurance_period,
                   sc_mem_m_insure.insurance_period_amount, sc_mem_m_insure.last_period,
                   sc_mem_m_insure.cancel_status, sc_mem_m_insure.pending_amount,
                   sc_mem_m_insure.insurance_arrear_old, sc_mem_m_insure.insurance_arrear_pending,
                   sc_mem_m_insure.insurance_status, sc_mem_m_insure.begining_of_contract,
                   sc_mem_m_insure.insurance_cost, sc_mem_m_insure.start_keep_date,
                   sc_mem_m_insure.advan_amount
            FROM sc_mem_m_insure, sc_mem_m_insure_rule, sc_mem_m_membership_registered
            WHERE sc_mem_m_insure.insurance_type = sc_mem_m_insure_rule.insurance_type
              AND sc_mem_m_insure.insurance_status = '0'
              AND sc_mem_m_insure.membership_no = sc_mem_m_membership_registered.membership_no
              AND sc_mem_m_membership_registered.membership_no = {0}", membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G2 Tab 4-6 — ผู้รับเงินสงเคราะห์ 1-3 (u_tabpg_mem_recipient_ss1..3)
    //    SQL เดียวกัน ต่างแค่ crem_type '01'/'02'/'03'
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<CremGainDto>> GetCremGainAsync(string membershipNo, string cremType)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<CremGainDto>(@"
            SELECT sc_mem_m_member_crem_gain.seq_no,
                   sc_mem_m_ucf_prename.prename,
                   sc_mem_m_member_crem_gain.gain_name,
                   sc_mem_m_member_crem_gain.gain_surname,
                   --sc_mem_m_member_crem_gain.related_na,
                   sc_mem_m_member_crem_gain.id_card,
                   sc_mem_m_member_crem_gain.address_gain,
                   sc_mem_m_member_crem_gain.entry_id,
                   sc_mem_m_member_crem_gain.entry_date
            FROM sc_mem_m_member_crem_gain, sc_mem_m_ucf_concern, sc_mem_m_ucf_prename
            WHERE sc_mem_m_member_crem_gain.conceern_code = sc_mem_m_ucf_concern.conceern_code
              AND sc_mem_m_member_crem_gain.prename_code = sc_mem_m_ucf_prename.prename_code
              AND sc_mem_m_member_crem_gain.crem_type = {1}
              AND sc_mem_m_member_crem_gain.membership_no = {0}
            ORDER BY sc_mem_m_member_crem_gain.crem_type ASC, sc_mem_m_member_crem_gain.seq_no ASC",
            membershipNo, cremType);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G2 Tab 7 — ผู้รับเงินสงเคราะห์ 4 (u_tabpg_mem_recipient_ss4 — view_tel_det_crem_gain_04)
    //    view มี typo column "gaint_surname" → alias AS gain_surname ให้ตรง CremGainDto (เลียน select * legacy)
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<CremGainDto>> GetCremGain04Async(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<CremGainDto>(@"
            SELECT seq_no_gain, prename, gain_name, gaint_surname AS gain_surname,
                   related_na, id_card, address_gain, entry_id, entry_date
            FROM view_tel_det_crem_gain_04
            WHERE membership_no = {0}", membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G2 Tab 8 — ผู้ค้ำ/ผู้ใช้ค้ำ (u_tabpg_mem_member_refer)
    //    member_status_code มาจาก subquery (สถานะของผู้ถูกอ้างถึง) → row แดงเมื่อ '3' (ลาออก)
    //    refer_status='1' (ยกเลิก) → row แดงด้วย (จัดที่ frontend CustomizeElement)
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<MemberReferDto>> GetMemberReferAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<MemberReferDto>(@"
            SELECT sc_mem_m_member_member_refer.membership_no_ref,
                   pka_com_function.fp_get_member_name(sc_mem_m_member_member_refer.membership_no_ref) AS member_name,
                   (SELECT member_status_code FROM sc_mem_m_membership_registered
                     WHERE sc_mem_m_membership_registered.membership_no = sc_mem_m_member_member_refer.membership_no_ref) AS member_status_code,
                   sc_mem_m_member_member_refer.conceern_code,
                   sc_mem_m_member_member_refer.entry_id,
                   sc_mem_m_member_member_refer.cancel_id,
                   sc_mem_m_member_member_refer.refer_status,
                   sc_mem_m_member_member_refer.seq_no
            FROM sc_mem_m_member_member_refer
            WHERE sc_mem_m_member_member_refer.membership_no = {0}
            ORDER BY sc_mem_m_member_member_refer.seq_no", membershipNo);
    }

    // ══════════════════════════════════════════════════════════════════════════
    // G3 "เงินกู้/หุ้น" 5 tabs
    // ══════════════════════════════════════════════════════════════════════════

    // ── G3 Tab 1: รายละเอียดเงินกู้ (u_tabpg_mem_detail_loan_detail) ──────────────
    // legacy: view_tel_det_lon (tran_to_coll!='1') UNION ALL คำขอ (sc_lon_m_loan_request + sctel._sqlLoanRequest)
    //   outer filter principal_balance<>0 OR (atm_status='1' & loan_contract_no in sc_atm_lon_card close_status='0')
    // Oracle→PG: decode→CASE; เพิ่ม JOIN sc_lon_m_rule (color_red/green/blue) ให้สีตาม sctel.ofSetLoanColor
    //   + special_unpaid = loan_group_code='03' & pay_loan_period='1'
    //                      & loan_approve_amount > pka_lon_addloan.get_loan_special_paid(conno)
    public async Task<List<LoanDetailDto>> GetLoanDetailAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<LoanDetailDto>(@"
            SELECT d.membership_no, d.loan_contract_no, d.begining_of_contract, d.loan_approve_amount,
                   d.loan_installment_amount, d.period_payment_amount, d.last_calcint_date, d.last_access_date,
                   d.tran_to_coll, d.last_period, d.principal_balance, d.year_total_interest, d.interest_arrear,
                   d.loan_type, d.close_status, d.atm_status, d.loan_looping, d.loan_group, d.loan_group_code,
                   d.pay_loan_period, d.drop_payment_status, d.atm_balance, d.pending_amount,
                   r.color_red, r.color_green, r.color_blue,
                   CASE WHEN d.loan_group_code = '03' AND d.pay_loan_period = '1'
                             AND d.loan_approve_amount > pka_lon_addloan.get_loan_special_paid(d.loan_contract_no)
                        THEN true ELSE false END AS special_unpaid
            FROM (
                SELECT view_tel_det_lon.membership_no,
                       view_tel_det_lon.loan_contract_no,
                       view_tel_det_lon.begining_of_contract,
                       view_tel_det_lon.loan_approve_amount,
                       view_tel_det_lon.loan_installment_amount,
                       view_tel_det_lon.period_payment_amount,
                       view_tel_det_lon.last_calcint_date,
                       view_tel_det_lon.last_access_date,
                       view_tel_det_lon.tran_to_coll,
                       view_tel_det_lon.last_period,
                       view_tel_det_lon.principal_balance,
                       view_tel_det_lon.year_total_interest,
                       view_tel_det_lon.interest_arrear,
                       view_tel_det_lon.loan_type,
                       view_tel_det_lon.close_status,
                       view_tel_det_lon.atm_status,
                       view_tel_det_lon.loan_looping,
                       view_tel_det_lon.loan_group,
                       view_tel_det_lon.loan_group_code,
                       view_tel_det_lon.pay_loan_period,
                       view_tel_det_lon.drop_payment_status,
                       view_tel_det_lon.atm_balance,
                       view_tel_det_lon.pending_amount
                  FROM view_tel_det_lon
                 WHERE view_tel_det_lon.membership_no = {0}
                   AND view_tel_det_lon.tran_to_coll != '1'  -- ไม่แสดงคนที่เราค้ำ (fix_code_mwa)
                UNION ALL
                SELECT sc_lon_m_loan_request.membership_no,
                       CASE WHEN sc_lon_m_loan_request.approve_status = '1' THEN
                            (SELECT sc_lon_m_contract.loan_contract_no
                               FROM sc_lon_m_contract
                              WHERE sc_lon_m_contract.loan_requestment_no = sc_lon_m_loan_request.loan_requestment_no
                                AND sc_lon_m_contract.membership_no       = sc_lon_m_loan_request.membership_no)
                            ELSE sc_lon_m_rule.ref_contract_no || sc_lon_m_loan_request.loan_requestment_no
                       END AS loan_contract_no,
                       sc_lon_m_loan_request.begining_of_contract,
                       sc_lon_m_loan_request.loan_request_amount,
                       sc_lon_m_loan_request.loan_installment_amount,
                       sc_lon_m_loan_request.period_payment_amount,
                       sc_lon_m_loan_request.begining_of_contract AS last_calcint_date,
                       NULL AS last_access_date,
                       '0' AS tran_to_coll,
                       0 AS last_period,
                       0 AS principal_balance,
                       0 AS year_total_interest,
                       0 AS interest_arrear,
                       sc_lon_m_loan_request.loan_type,
                       '0' AS close_status,
                       sc_lon_m_rule.atm_status,
                       sc_lon_m_rule.loan_looping,
                       '2' AS loan_group,
                       sc_lon_m_rule.loan_group_code,
                       sc_lon_m_rule.pay_loan_period,
                       '0' AS drop_payment_status,
                       'คำขอ' AS atm_balance,
                       0 AS pending_amount
                  FROM sc_lon_m_loan_request, sc_lon_m_rule
                 WHERE sc_lon_m_loan_request.loan_type     = sc_lon_m_rule.loan_type
                   AND sc_lon_m_loan_request.membership_no = {0}
                   AND sc_lon_m_loan_request.cancel_status = '0'
                   AND (
                       sc_lon_m_loan_request.approve_status = '2'
                       OR (sc_lon_m_loan_request.approve_status = '1' AND EXISTS(
                           SELECT NULL FROM sc_lon_m_contract
                            WHERE sc_lon_m_contract.loan_requestment_no = sc_lon_m_loan_request.loan_requestment_no
                              AND (sc_lon_m_contract.rec_rep_status = '2' OR sc_lon_m_contract.rec_rep_status = '1')
                              AND sc_lon_m_contract.create_loan_status = '2'))
                   )
                   AND NOT EXISTS(
                       SELECT NULL FROM sc_lon_m_contract, sc_lon_m_loan_card
                        WHERE sc_lon_m_contract.loan_contract_no   = sc_lon_m_loan_card.loan_contract_no
                          AND sc_lon_m_contract.loan_requestment_no = sc_lon_m_loan_request.loan_requestment_no)
            ) d
            LEFT JOIN sc_lon_m_rule r ON r.loan_type = d.loan_type
            WHERE d.principal_balance <> 0
               OR ( d.atm_status = '1' AND d.loan_contract_no IN (
                        SELECT loan_contract_no FROM sc_atm_lon_card
                         WHERE loan_contract_no = d.loan_contract_no AND close_status = '0') )
            ORDER BY d.principal_balance DESC, d.last_access_date DESC, d.loan_type",
            membershipNo);
    }

    // ── G3 Tab 2: หุ้นค้ำ/กองทุน (u_tabpg_mem_detail_share_coll) — sc_fund_mem ─────
    // Oracle→PG: decode(close_status,'1','C',close_status) → CASE; close_status!='0' (หลัง decode) → row แดง
    public async Task<List<ShareCollDto>> GetShareCollAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<ShareCollDto>(@"
            SELECT sc_fund_mem.loan_contract_no,
                   sc_fund_mem.open_day,
                   sc_fund_mem.pricipal_balance,
                   sc_lon_m_loan_card.principal_balance,
                   sc_fund_mem.total_balance,
                   CASE WHEN sc_fund_mem.close_status = '1' THEN 'C'
                        ELSE sc_fund_mem.close_status END AS close_status,
                   sc_fund_mem.paid_return_method,
                   sc_fund_mem.return_date,
                   (SELECT fund_name FROM sc_fund_loan
                     WHERE sc_fund_loan.fund_loan_no = sc_fund_mem.fund_loan_no) AS fund_loan_no,
                   sc_fund_mem.last_access_date
            FROM sc_fund_mem, sc_lon_m_loan_card, sc_lon_m_rule
            WHERE sc_fund_mem.membership_no    = sc_lon_m_loan_card.membership_no
              AND sc_fund_mem.loan_contract_no = sc_lon_m_loan_card.loan_contract_no
              AND sc_lon_m_loan_card.loan_type = sc_lon_m_rule.loan_type
              AND sc_fund_mem.membership_no    = {0}
            ORDER BY sc_fund_mem.close_status, sc_fund_mem.open_day DESC", membershipNo);
    }

    // ── G3 Tab 3: สถานะหุ้น — header (u_tabpg_mem_detail_share_state) ─────────────
    public async Task<ShareStateHeadDto?> GetShareStateHeadAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getOneAsync<ShareStateHeadDto>(@"
            SELECT share_stock, share_amount, period_recrieve, pending_amt,
                   CASE WHEN keeping_status = '1' THEN 'ประมวลผลแล้ว' ELSE 'ยังไม่ประมวล' END AS keeping_status,
                   CASE WHEN drop_status    = '1' THEN 'งดเก็บ'       ELSE 'ปกติ'        END AS drop_status,
                   begin_balance, pending_arrear
            FROM sc_mem_m_share_mem
            WHERE membership_no = {0}", membershipNo);
    }

    // ── G3 Tab 3: สถานะหุ้น — grid (u_tabpg_mem_detail_share_state) ───────────────
    // sign_flag จาก sc_mem_m_ucf_share_item_type → decode (-1 ถอน / 1 เพิ่ม) เป็น to_char ไว้ใน SQL (faithful)
    // operate_date = fpb_get_share_operate_date(membership_no, seq_no); sign_flag<0 → font แดง, item_type='XS' → font เขียว
    public async Task<List<ShareStateDto>> GetShareStateAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<ShareStateDto>(@"
            SELECT shd.seq_no,
                   fpb_get_share_operate_date(shd.membership_no, shd.seq_no) AS operate_date,
                   shd.doc_no,
                   trim(shd.item_type) AS item_type,
                   shd.period,
                   shd.share_amount,
                   CASE WHEN (SELECT it.sign_flag FROM sc_mem_m_ucf_share_item_type it
                               WHERE it.item_type = trim(shd.item_type)) = -1
                        THEN to_char(shd.share_value,'999,999,999.99') ELSE '- ' END AS share_value_decr,
                   CASE WHEN (SELECT it.sign_flag FROM sc_mem_m_ucf_share_item_type it
                               WHERE it.item_type = trim(shd.item_type)) = 1
                        THEN to_char(shd.share_value,'999,999,999.99') ELSE '- ' END AS share_value_incr,
                   shd.share_stock,
                   shd.entry_id,
                   shd.entry_date,
                   shd.cancel_status,
                   (SELECT it.sign_flag FROM sc_mem_m_ucf_share_item_type it
                     WHERE it.item_type = trim(shd.item_type)) AS sign_flag,
                   shd.div_date,
                   shd.remark
            FROM sc_mem_m_share_holding_detail shd
            WHERE shd.membership_no = {0}
            ORDER BY shd.seq_no", membershipNo);
    }

    // ── G3 Tab 4: งดส่งเงินกู้ (u_tabpg_mem_detail_drop_loan) — sc_mem_m_member_drop_loan ──
    public async Task<List<DropLoanDto>> GetDropLoanAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<DropLoanDto>(@"
            SELECT loan_type FROM sc_mem_m_member_drop_loan
            WHERE membership_no = {0}", membershipNo);
    }

    // ── G3 Tab 5: หลักประกัน (u_tabpg_mem_detail_coll_detail) — port sctel.getCalcCollUsed ──
    //  3 unions: (1) สัญญาปกติ ที่สมาชิกค้ำ (2) สัญญาภาระแทน (3) คำขอกู้รออนุมัติ + _sqlLoanRequest
    //  Oracle→PG: nvl→COALESCE, decode→CASE, PKB_KTM.*→pkb_ktm.* (qualified), || คงเดิม
    //  เพิ่มจาก legacy (faithful presentation optimize — เลี่ยง N+1 ใน HtmlRowPrepared):
    //    - sc_lon_m_rule.color_red/green/blue (outer) → ใช้ลงสีแถวฝั่ง Razor แทน ofSetLoanColor
    //    - member_status_code (ผู้กู้) ในแต่ละ union → legacy query ราย row ใน HtmlRowPrepared
    //  {0} = membership_no ใช้ซ้ำ 3 จุด (ref_own_no union1, loan_card_a.membership_no union2, ref_own_no union3)
    //  coll_evaluate_balance คำนวณต่อใน C# (เลียน loop ใน getCalcCollUsed); req_amount = used_amount
    public async Task<List<CollDetailDto>> GetCollDetailAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        var rows = await scDb.getListAsync<CollDetailDto>(@"
            SELECT sum(1) OVER (PARTITION BY td.loan_group, td.loan_style ORDER BY td.loan_contract_no) AS loan_order,
                   td.used_amount AS req_amount,
                   0 AS coll_evaluate_balance,
                   sc_lon_m_rule.color_red,
                   sc_lon_m_rule.color_green,
                   sc_lon_m_rule.color_blue,
                   td.*
            FROM (
                /*สัญญาปกติ*/
                SELECT sc_lon_m_contract.loan_type,
                       sc_lon_m_loan_card.loan_contract_no,
                       sc_mem_m_membership_registered.membership_no,
                       (SELECT prename FROM sc_mem_m_ucf_prename WHERE prename_code = sc_mem_m_membership_registered.prename_code)
                           || ' ' || sc_mem_m_membership_registered.member_name || '  ' || sc_mem_m_membership_registered.member_surname AS member_name,
                       sc_lon_m_loan_card.principal_balance,
                       sc_lon_m_contract_coll.used_amount,
                       sc_lon_m_contract_coll.mem_coll,
                       CASE WHEN pka_lon_reqsrv.fp_isvalid_memloan_collfree(sc_lon_m_contract_coll.loan_contract_no) = '1'
                            THEN 'F' ELSE 'A' END AS coll_current,  -- F-หลุดค้ำ, A-ค้ำอยู่
                       '0' AS loan_group,
                       NULL AS loan_type_old,
                       COALESCE(trim(sc_lon_m_rule.group_loan), sc_lon_m_rule.loan_type) AS loan_style,
                       sc_mem_m_share_mem.share_stock,
                       sc_lon_m_loan_card.loan_code,
                       COALESCE(sc_lon_m_loan_card.principal_arr_all + sc_lon_m_loan_card.pending_month_arr, 0) AS sum_arr,
                       COALESCE(sc_lon_m_loan_card.interest_arrear + sc_lon_m_loan_card.old_interest_arrear, 0) AS sum_interrest,
                       pkb_ktm.fp_get_count_coll(sc_lon_m_contract.loan_contract_no) AS coll_use_amount,
                       sc_lon_m_contract.begining_of_contract AS begining_of_contract,
                       sc_mem_m_membership_registered.member_status_code
                FROM sc_lon_m_contract_coll,
                     sc_lon_m_contract,
                     sc_lon_m_loan_card,
                     sc_lon_m_rule,
                     sc_mem_m_membership_registered,
                     sc_mem_m_share_mem
                WHERE sc_lon_m_contract.loan_contract_no = sc_lon_m_contract_coll.loan_contract_no
                  AND sc_lon_m_contract.loan_contract_no = sc_lon_m_loan_card.loan_contract_no
                  AND sc_lon_m_contract.loan_type        = sc_lon_m_rule.loan_type
                  AND sc_lon_m_contract.membership_no    = sc_mem_m_membership_registered.membership_no
                  AND sc_mem_m_share_mem.membership_no   = sc_mem_m_membership_registered.membership_no
                  AND sc_lon_m_contract_coll.collateral_type_code = '01'  /*คนค้ำ*/
                  AND sc_lon_m_contract_coll.status      = '0'            /*ค้ำอยู่*/
                  AND ( sc_lon_m_loan_card.principal_balance > 0
                        OR ((sc_lon_m_rule.atm_status = '1' OR sc_lon_m_rule.loan_looping = '1') AND sc_lon_m_loan_card.close_status = '0')
                           AND COALESCE((SELECT modify_status FROM sc_atm_lon_card WHERE loan_contract_no = sc_lon_m_loan_card.loan_contract_no), '0') <> 'C' )
                  AND sc_lon_m_contract_coll.ref_own_no  = {0}
                UNION
                /*สัญญาภาระแทน*/
                SELECT sc_lon_m_contract_a.loan_type,
                       sc_lon_m_contract_a.loan_contract_no,
                       sc_mem_m_membership_registered.membership_no,
                       (SELECT prename FROM sc_mem_m_ucf_prename WHERE prename_code = sc_mem_m_membership_registered.prename_code)
                           || ' ' || sc_mem_m_membership_registered.member_name || '  ' || sc_mem_m_membership_registered.member_surname AS member_name,
                       sc_lon_m_loan_card_a.principal_balance,
                       COALESCE((
                           SELECT used_amount FROM sc_lon_m_contract_coll
                            WHERE loan_contract_no = sc_lon_m_contract_a.old_contract_no
                              AND ref_own_no = sc_lon_m_loan_card_a.membership_no
                              AND collateral_type_code = '01'
                              AND status = '0'
                       ), 0) AS used_amount,
                       NULL AS mem_coll,
                       'T' AS coll_current,  -- T-รับภาระหนี้
                       '0' AS loan_group,
                       sc_lon_m_loan_card_b.loan_type AS loan_type_old,
                       (SELECT COALESCE(trim(tr.group_loan), tr.loan_type)
                          FROM sc_lon_m_contract td, sc_lon_m_rule tr
                         WHERE td.loan_contract_no = sc_lon_m_contract_a.old_contract_no
                           AND td.loan_type = tr.loan_type) AS loan_style,
                       sc_mem_m_share_mem.share_stock,
                       sc_lon_m_loan_card_a.loan_code,
                       COALESCE(sc_lon_m_loan_card_a.principal_arr_all + sc_lon_m_loan_card_a.pending_month_arr, 0) AS sum_arr,
                       COALESCE(sc_lon_m_loan_card_a.interest_arrear + sc_lon_m_loan_card_a.old_interest_arrear, 0) AS sum_interrest,
                       pkb_ktm.fp_get_count_coll(sc_lon_m_contract_a.loan_contract_no) AS coll_use_amount,
                       sc_lon_m_contract_a.begining_of_contract AS begining_of_contract,
                       sc_mem_m_membership_registered.member_status_code
                FROM sc_lon_m_loan_card sc_lon_m_loan_card_a,
                     sc_lon_m_loan_card sc_lon_m_loan_card_b,
                     sc_lon_m_contract sc_lon_m_contract_a,
                     sc_lon_m_rule,
                     sc_mem_m_membership_registered,
                     sc_mem_m_share_mem
                WHERE ( sc_lon_m_loan_card_a.loan_contract_no = sc_lon_m_contract_a.loan_contract_no )
                  AND ( sc_lon_m_loan_card_a.principal_balance > 0 )
                  AND ( sc_lon_m_loan_card_a.membership_no = {0} )
                  AND sc_lon_m_contract_a.loan_type = sc_lon_m_rule.loan_type
                  AND EXISTS(SELECT NULL FROM sc_lon_m_rule td WHERE td.loan_tran_type = sc_lon_m_rule.loan_type)
                  AND ( sc_lon_m_contract_a.old_contract_no = sc_lon_m_loan_card_b.loan_contract_no )
                  AND sc_mem_m_membership_registered.membership_no = sc_lon_m_loan_card_b.membership_no
                  AND sc_mem_m_share_mem.membership_no = sc_mem_m_membership_registered.membership_no
                UNION
                /*คำขอรออนุมัติ*/
                SELECT sc_lon_m_loan_request.loan_type,
                       CASE WHEN sc_lon_m_loan_request.approve_status = '2'
                            THEN sc_lon_m_rule.ref_contract_no || sc_lon_m_req_coll.loan_requestment_no
                            ELSE (SELECT max(sc_lon_m_contract.loan_contract_no) FROM sc_lon_m_contract
                                   WHERE sc_lon_m_contract.loan_requestment_no = sc_lon_m_loan_request.loan_requestment_no)
                            END AS loan_contract_no,
                       sc_lon_m_loan_request.membership_no,
                       (SELECT prename FROM sc_mem_m_ucf_prename WHERE prename_code = sc_mem_m_membership_registered.prename_code)
                           || ' ' || sc_mem_m_membership_registered.member_name || '  ' || sc_mem_m_membership_registered.member_surname AS member_name,
                       sc_lon_m_loan_request.loan_request_amount AS principal_balance,
                       sc_lon_m_req_coll.req_amount AS used_amount,
                       sc_lon_m_req_coll.mem_coll,
                       CASE WHEN sc_lon_m_loan_request.approve_status = '2' THEN 'W' ELSE 'P' END AS coll_current,  -- W-รออนุมัติ, P-รอตัดจ่าย
                       '2' AS loan_group,
                       NULL AS loan_type_old,
                       NULL AS loan_style,
                       sc_mem_m_share_mem.share_stock AS share_stock,
                       '0' AS loan_code,
                       0 AS sum_arr,
                       0 AS sum_interrest,
                       pkb_ktm.fp_get_count_collin_req(sc_lon_m_loan_request.loan_requestment_no) AS coll_use_amount,
                       sc_lon_m_loan_request.begining_of_contract AS begining_of_contract,
                       sc_mem_m_membership_registered.member_status_code
                FROM sc_lon_m_loan_request,
                     sc_lon_m_req_coll,
                     sc_mem_m_membership_registered,
                     sc_mem_m_share_mem,
                     sc_lon_m_rule
                WHERE sc_lon_m_rule.loan_type = sc_lon_m_loan_request.loan_type
                  AND sc_lon_m_loan_request.loan_requestment_no = sc_lon_m_req_coll.loan_requestment_no
                  AND sc_lon_m_loan_request.membership_no = sc_mem_m_membership_registered.membership_no
                  AND sc_mem_m_share_mem.membership_no = sc_mem_m_membership_registered.membership_no
                  AND sc_lon_m_loan_request.cancel_status = '0'
                  AND sc_lon_m_req_coll.collateral_type_code = '01'
                  AND sc_lon_m_req_coll.ref_own_no = {0}
                  AND sc_lon_m_req_coll.status = '0'
                  AND (
                      sc_lon_m_loan_request.approve_status = '2'
                      OR (sc_lon_m_loan_request.approve_status = '1' AND EXISTS(
                          SELECT NULL FROM sc_lon_m_contract
                           WHERE sc_lon_m_contract.loan_requestment_no = sc_lon_m_loan_request.loan_requestment_no
                             AND (sc_lon_m_contract.rec_rep_status = '2' OR sc_lon_m_contract.rec_rep_status = '1')
                             AND sc_lon_m_contract.create_loan_status = '2'))
                  )
                  AND NOT EXISTS(
                      SELECT NULL FROM sc_lon_m_contract, sc_lon_m_loan_card
                       WHERE sc_lon_m_contract.loan_contract_no   = sc_lon_m_loan_card.loan_contract_no
                         AND sc_lon_m_contract.loan_requestment_no = sc_lon_m_loan_request.loan_requestment_no)
            ) td, sc_lon_m_rule
            WHERE td.loan_type = sc_lon_m_rule.loan_type
              AND td.coll_current <> 'F'
            ORDER BY td.loan_group DESC,  -- 0-ปกติ/ภาระแทน, 2-คำขอ
                     td.loan_style,
                     td.loan_contract_no", membershipNo);

        // เลียน loop ใน getCalcCollUsed: coll_evaluate_balance = balance หาร จำนวนคนค้ำ (0 → balance ตรงๆ)
        foreach (var r in rows)
            r.CollEvaluateBalance = (r.CollUseAmount ?? 0) == 0
                ? r.PrincipalBalance
                : (r.PrincipalBalance ?? 0) / r.CollUseAmount;

        return rows;
    }

    // ── G3 Tab 5: ข้อความสรุปสิทธิค้ำใต้ grid — pkb_ktm.fp_get_msg_collused_teldet ──
    //  KTM-only (ห่อด้วย pka.iscoop('KTM')); สอ. PEAN → คืนค่าว่างเสมอ (เลียน onDataBinding)
    public async Task<string> GetCollUsedMsgAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return sc.value.toString(await scDb.pkFunctionAsync("pkb_ktm.fp_get_msg_collused_teldet", membershipNo));
    }

    // ════════════════════════════════════════════════════════════════════════
    //  popup กองทุนผู้ค้ำ (popShareCollDetail) 3 sub-tabs — key = loan_contract_no
    //  port ตรงจาก scteldet/tabs/u_tabpg_share_coll_detail(.cs) / _state / _fund
    // ════════════════════════════════════════════════════════════════════════

    // ── sub 1: รายละเอียดกองทุน (u_tabpg_share_coll_detail.flHead_DataBinding) ──
    public async Task<ShareCollDetailMainDto?> GetShareCollMainAsync(string loanContractNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getOneAsync<ShareCollDetailMainDto>(@"
            SELECT sc_fund_mem.loan_contract_no,
                   sc_fund_mem.open_day,
                   sc_fund_mem.pricipal_balance,
                   sc_fund_mem.total_balance,
                   CASE WHEN sc_fund_mem.close_status = '1' THEN 'C'
                        ELSE sc_fund_mem.close_status END AS close_status,
                   sc_fund_mem.paid_return_method,
                   sc_fund_mem.return_date,
                   (SELECT fund_name FROM sc_fund_loan
                     WHERE sc_fund_loan.fund_loan_no = sc_fund_mem.fund_loan_no) AS fund_loan_no
            FROM sc_fund_mem
            WHERE sc_fund_mem.loan_contract_no = {0}", loanContractNo);
    }

    // ── sub 2: รายการเคลื่อนไหว (u_tabpg_share_coll_detail_state.gvDetail_DataBinding) ──
    public async Task<List<ShareCollStateDto>> GetShareCollStateAsync(string loanContractNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<ShareCollStateDto>(@"
            SELECT sc_fund_mem_detail.membership_no,
                   sc_fund_mem_detail.loan_contract_no,
                   sc_fund_mem_detail.seq_no,
                   sc_fund_mem_detail.operate_date,
                   sc_fund_mem_detail.item_type,
                   sc_fund_mem_detail.ref_doc_no,
                   sc_fund_mem_detail.loan_type,
                   CASE WHEN sc_fund_ucf_item_type.sign_flag =  1 THEN sc_fund_mem_detail.amount ELSE 0 END AS principal_amount_i,
                   CASE WHEN sc_fund_ucf_item_type.sign_flag = -1 THEN sc_fund_mem_detail.amount ELSE 0 END AS principal_amount_p,
                   sc_fund_mem_detail.balance,
                   sc_fund_mem_detail.user_id
            FROM sc_fund_mem_detail, sc_fund_ucf_item_type
            WHERE sc_fund_mem_detail.item_type       = sc_fund_ucf_item_type.item_type
              AND sc_fund_mem_detail.loan_contract_no = {0}
            ORDER BY sc_fund_mem_detail.seq_no", loanContractNo);
    }

    // ── sub 3a: จ่ายคืน (u_tabpg_share_coll_fund.gvFundRet_DataBinding) ──
    public async Task<List<ShareCollFundRetDto>> GetShareCollFundRetAsync(string loanContractNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<ShareCollFundRetDto>(@"
            SELECT sc_lon_m_req_fund_ret.loan_requestment_no,
                   sc_lon_m_req_fund_ret.seq_no,
                   sc_lon_m_req_fund_ret.loan_contract_no,
                   sc_lon_m_req_fund_ret.fund_ret,
                   sc_lon_m_req_fund_ret.approve_amount
            FROM sc_lon_m_req_fund_ret, sc_lon_m_contract
            WHERE sc_lon_m_contract.loan_requestment_no = sc_lon_m_req_fund_ret.loan_requestment_no
              AND sc_lon_m_contract.loan_contract_no = {0}
            ORDER BY sc_lon_m_req_fund_ret.seq_no", loanContractNo);
    }

    // ── sub 3b: เก็บเพิ่ม (u_tabpg_share_coll_fund.gvFundNew_DataBinding) ──
    public async Task<List<ShareCollFundNewDto>> GetShareCollFundNewAsync(string loanContractNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<ShareCollFundNewDto>(@"
            SELECT sc_lon_m_req_fund_new.loan_requestment_no,
                   sc_lon_m_req_fund_new.seq_no,
                   sc_lon_m_req_fund_new.loan_contract_no,
                   sc_lon_m_req_fund_new.fund_cur,
                   sc_lon_m_req_fund_new.fund_new,
                   sc_lon_m_req_fund_new.fund_add,
                   sc_lon_m_req_fund_new.fund_extra,
                   approve_amount
            FROM sc_lon_m_req_fund_new, sc_lon_m_contract
            WHERE sc_lon_m_contract.loan_requestment_no = sc_lon_m_req_fund_new.loan_requestment_no
              AND sc_lon_m_contract.loan_contract_no = {0}
            ORDER BY seq_no", loanContractNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  popup รายละเอียดเงินกู้ (popLoan_detail) 9 sub-tabs — key = loan_contract_no
    //  port ตรงจาก scteldet/tabs/u_tabpg_loan_detail_*(.cs)
    //  Oracle→PG: decode→CASE, nvl→COALESCE, package fn ที่ migrate แล้วเรียก inline
    // ════════════════════════════════════════════════════════════════════════

    // ── sub 0: รายละเอียดเงินกู้ (u_tabpg_loan_detail_loan_detail_main) form ──
    //  paid_able = pka_mem_det.fp_cal_loan_paidable (คงเหลือรับเงินงวด) — migrate แล้ว
    public async Task<LoanDetailMainDto?> GetLoanDetailMainAsync(string loanContractNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getOneAsync<LoanDetailMainDto>(@"
            SELECT sc_lon_m_contract.loan_request_amount,
                   sc_lon_m_contract.begining_of_contract,
                   COALESCE(sc_lon_m_contract.contract_interest_rate,0) AS contract_interest_rate,
                   sc_lon_m_contract.loan_payment_type_code,
                   sc_lon_m_contract.period_payment_amount,
                   sc_lon_m_loan_card.last_access_date,
                   sc_lon_m_loan_card.total_interest,
                   sc_lon_m_loan_card.drop_payment_status,
                   sc_lon_m_loan_card.fixed_payment,
                   sc_lon_m_loan_card.last_period,
                   COALESCE(sc_lon_m_loan_card.interest_arrear,0) AS interest_arrear,
                   sc_lon_m_loan_card.last_calcint_date,
                   sc_lon_m_loan_card.period_compomise,
                   sc_lon_m_loan_card.date_compomise,
                   COALESCE(sc_lon_m_loan_card.accu_compomise,0) AS accu_compomise,
                   sc_lon_m_contract.start_keep_date,
                   pka_lon_intsrv.fp_intrate_conno(sc_lon_m_contract.loan_contract_no)*100 AS interest_rate,
                   sc_lon_m_loan_card.principal_arr_all,
                   sc_lon_m_loan_card.pending_month_arr,
                   sc_lon_m_contract.remark,
                   sc_lon_m_loan_card.loan_code,
                   NULL AS c_colldetail,
                   CASE WHEN sc_lon_m_loan_card.close_status = 'T' THEN 'โอนไปให้ผู้ค้ำ'
                        WHEN sc_lon_m_loan_card.close_status = '1' THEN 'ปิดบัญชี'
                        ELSE 'สัญญาปกติ' END AS close_status,
                   (SELECT loan_objective_code||' - '||loan_objective_description
                      FROM sc_lon_m_ucf_loan_obj
                     WHERE loan_objective_code = sc_lon_m_contract.loan_objective_code
                       AND loan_type = sc_lon_m_contract.loan_type) AS loan_objective_desc,
                   pka_mem_det.fp_cal_loan_paidable(sc_lon_m_contract.loan_contract_no) AS paid_able,
                   sc_lon_m_loan_card.pending_amount,
                   sc_lon_m_loan_card.pending_interest,
                   sc_lon_m_loan_card.last_process_date,
                   sc_lon_m_loan_card.principal_balance,
                   CASE WHEN sc_lon_m_contract.welfare_status::text = '1' THEN 'ผ่านสวัสดิการ' ELSE '-' END AS welfare_status,
                   CASE WHEN sc_lon_m_loan_card.fixed_interest_rate > 0 THEN '1' ELSE '0' END AS fixed_interest
            FROM sc_lon_m_contract, sc_lon_m_loan_card, sc_lon_m_rule
            WHERE sc_lon_m_loan_card.loan_contract_no = sc_lon_m_contract.loan_contract_no
              AND sc_lon_m_contract.loan_contract_no = {0}
              AND sc_lon_m_rule.loan_type = sc_lon_m_contract.loan_type", loanContractNo);
    }

    // ── sub 1: เคลื่อนไหวสัญญา (u_tabpg_loan_detail_loan_detail.gv_detail_DataBinding) ──
    //  outer decode(sign_status) → recieve_return / paid; sign_status subquery จาก ucf
    public async Task<List<LoanDetailMoveDto>> GetLoanDetailMoveAsync(string loanContractNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<LoanDetailMoveDto>(@"
            SELECT CASE WHEN tab.sign_status = -1 THEN 0 ELSE tab.payment_amount END AS recieve_return,
                   CASE WHEN tab.sign_status = -1 THEN tab.payment_amount ELSE 0 END AS paid,
                   tab.*
            FROM (
                SELECT sc_lon_m_loan_card_detail.seq_no AS seq_no,
                       sc_lon_m_loan_card_detail.loan_contract_no,
                       FPB_GET_LOAN_PAYMENT_DATE(sc_lon_m_loan_card_detail.loan_contract_no, sc_lon_m_loan_card_detail.seq_no) AS loan_payment_date,
                       sc_lon_m_loan_card_detail.ref_loan_doc_no AS ref_loan_doc_no,
                       sc_lon_m_loan_card_detail.item_type_code,
                       sc_lon_m_loan_card_detail.period,
                       sc_lon_m_loan_card_detail.payment_amount,
                       COALESCE(sc_lon_m_loan_card_detail.interest_amout,0) AS interest_amout,
                       COALESCE(sc_lon_m_loan_card_detail.interest_arrear_bal,0) AS interest_arrear_bal,
                       (sc_lon_m_loan_card_detail.payment_amount + sc_lon_m_loan_card_detail.interest_amout) AS total_amount,
                       sc_lon_m_loan_card_detail.principal_balance AS principal_balance,
                       sc_lon_m_loan_card_detail.membership_no,
                       sc_lon_m_loan_card_detail.interest_to,
                       (SELECT sign_status FROM sc_lon_m_ucf_loan_card_item
                         WHERE sc_lon_m_loan_card_detail.item_type_code = sc_lon_m_ucf_loan_card_item.item_type_code) AS sign_status
                FROM sc_lon_m_loan_card_detail, sc_lon_m_ucf_loan_card_item, sc_lon_m_contract, sc_lon_m_rule
                WHERE (sc_lon_m_contract.loan_contract_no = {0})
                  AND (sc_lon_m_loan_card_detail.item_type_code = sc_lon_m_ucf_loan_card_item.item_type_code)
                  AND (sc_lon_m_loan_card_detail.loan_contract_no = sc_lon_m_contract.loan_contract_no)
                  AND (sc_lon_m_rule.loan_type = sc_lon_m_contract.loan_type)
                ORDER BY sc_lon_m_loan_card_detail.seq_no
            ) tab", loanContractNo);
    }

    // ── sub 2: เงินกู้เอทีเอ็ม (u_tabpg_loan_detail_atmdet) grid ──
    public async Task<List<LoanDetailAtmDto>> GetLoanDetailAtmAsync(string loanContractNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<LoanDetailAtmDto>(@"
            SELECT sc_atm_lon_detail.loan_contract_no,
                   sc_atm_lon_detail.seq_no,
                   sc_atm_lon_detail.prin_amount,
                   sc_atm_lon_detail.fee_amount,
                   sc_atm_lon_detail.operate_date,
                   sc_atm_lon_detail.item_type,
                   (SELECT item_desc FROM sc_lon_atm_ucf_item_type
                     WHERE item_type = sc_atm_lon_detail.item_type) AS item_desc,
                   sc_atm_lon_detail.transaction_no,
                   sc_atm_lon_detail.entry_date,
                   sc_atm_lon_detail.entry_id,
                   sc_atm_lon_detail.approve_amount,
                   sc_atm_lon_detail.loan_balance,
                   sc_atm_lon_detail.remark
            FROM sc_atm_lon_card, sc_atm_lon_detail, sc_lon_m_contract, sc_lon_m_rule
            WHERE sc_atm_lon_card.loan_contract_no = sc_atm_lon_detail.loan_contract_no
              AND sc_lon_m_contract.loan_contract_no = sc_atm_lon_detail.loan_contract_no
              AND sc_lon_m_contract.loan_type = sc_lon_m_rule.loan_type
              AND sc_lon_m_rule.atm_status = '1'
              AND sc_atm_lon_detail.loan_contract_no = {0}
            ORDER BY sc_atm_lon_detail.seq_no", loanContractNo);
    }

    // ── sub 3: รายการค้ำประกัน (u_tabpg_loan_detail_coll_detail gvLoanColl) grid ──
    //  หมายเหตุ: grid รอง gvCollOther ""ค้ำประกันบุคคลอื่น"" legacy ใช้ sctel.getCalcCollUsed
    //           (computed, ไม่ใช่ table read) → ยัง defer (finance-tier); grid หลักพอร์ตครบ
    public async Task<List<LoanDetailCollDto>> GetLoanDetailCollAsync(string loanContractNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<LoanDetailCollDto>(@"
            SELECT sc_lon_m_contract_coll.collateral_type_code,
                   sc_lon_m_contract_coll.ref_own_no,
                   COALESCE(
                       CASE sc_lon_m_contract_coll.collateral_type_code
                            WHEN '01' THEN pka_com_function.fp_get_member_name(sc_lon_m_contract_coll.ref_own_no)
                            WHEN '02' THEN 'หุ้นค้ำประกัน'
                            WHEN '03' THEN 'เงินค้ำประกัน '||sc_lon_m_contract_coll.ref_own_no
                            ELSE sc_lon_m_contract_coll.collateral_description END,
                       sc_lon_m_contract_coll.ref_own_no) AS collateral_description,
                   sc_lon_m_contract_coll.keep_coll_status,
                   sc_lon_m_contract_coll.keep_coll_amount,
                   sc_lon_m_contract_coll.remark,
                   sc_lon_m_contract_coll.used_amount
            FROM sc_lon_m_contract_coll, sc_lon_m_contract
            WHERE 1=1
              AND sc_lon_m_contract.loan_contract_no = {0}
              AND sc_lon_m_contract_coll.loan_contract_no = sc_lon_m_contract.loan_contract_no
              AND sc_lon_m_contract_coll.status = '0'
            ORDER BY sc_lon_m_contract_coll.collateral_type_code, sc_lon_m_contract_coll.ref_own_no", loanContractNo);
    }

    // ── sub 4: โอนหนี้ให้ผู้ค้ำ (u_tabpg_loan_detail_coll_trans) grid ──
    public async Task<List<LoanDetailCollTransDto>> GetLoanDetailCollTransAsync(string loanContractNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<LoanDetailCollTransDto>(@"
            SELECT sc_lon_m_contract.loan_contract_no,
                   sc_lon_m_contract.membership_no,
                   pka_com_function.fp_get_member_name(sc_lon_m_contract.membership_no) AS member_name,
                   sc_lon_m_contract.begining_of_contract,
                   sc_lon_m_contract.loan_approve_amount,
                   sc_lon_m_contract.period_payment_amount,
                   sc_lon_m_loan_card.last_access_date,
                   sc_lon_m_loan_card.last_period,
                   sc_lon_m_loan_card.principal_balance,
                   sc_lon_m_loan_card.entry_id,
                   sc_lon_m_loan_card.entry_date
            FROM sc_lon_m_contract, sc_lon_m_loan_card
            WHERE (sc_lon_m_loan_card.loan_contract_no = sc_lon_m_contract.loan_contract_no)
              AND (sc_lon_m_contract.old_contract_no = {0})", loanContractNo);
    }

    // ── sub 5: การจ่ายเงิน (u_tabpg_loan_detail_payment) form ──
    public async Task<LoanDetailPaymentDto?> GetLoanDetailPaymentAsync(string loanContractNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getOneAsync<LoanDetailPaymentDto>(@"
            SELECT CASE WHEN sc_lon_m_contract_multi_paid.type_pay_money = '0' THEN '-'
                        ELSE sc_lon_m_contract_multi_paid.type_pay_money END AS type_pay_money,
                   sc_lon_m_contract_multi_paid.bank_code,
                   sc_lon_m_contract_multi_paid.branch_code,
                   sc_lon_m_contract_multi_paid.bank_acc_no,
                   sc_lon_m_loan_request.acc_paid_type
            FROM sc_lon_m_contract, sc_lon_m_loan_request, sc_lon_m_contract_multi_paid
            WHERE sc_lon_m_contract.loan_requestment_no = sc_lon_m_loan_request.loan_requestment_no
              AND sc_lon_m_contract.loan_contract_no = sc_lon_m_contract_multi_paid.loan_contract_no
              AND sc_lon_m_contract_multi_paid.seq_no = '1'
              AND sc_lon_m_contract.loan_contract_no = {0}", loanContractNo);
    }

    // ── sub 6a: รายการหักกลบ head (u_tabpg_loan_detail_recclear) form ──
    public async Task<LoanDetailRecclearHeadDto?> GetLoanDetailRecclearHeadAsync(string loanContractNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getOneAsync<LoanDetailRecclearHeadDto>(@"
            SELECT sc_com_m_receipt.receipt_no,
                   sc_com_m_receipt.receipt_date,
                   sc_com_m_receipt.calcint_date,
                   sc_com_m_receipt.entry_id
            FROM sc_com_m_receipt
            WHERE sc_com_m_receipt.money_type_id IN ('CLR','TRL')
              AND sc_com_m_receipt.receipt_status = '0'
              AND sc_com_m_receipt.loan_contract_no = {0}", loanContractNo);
    }

    // ── sub 6b: รายการหักกลบ item (u_tabpg_loan_detail_recclear grid) grid ──
    public async Task<List<LoanDetailRecclearItemDto>> GetLoanDetailRecclearItemAsync(string loanContractNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<LoanDetailRecclearItemDto>(@"
            SELECT sc_com_m_receipt.receipt_no,
                   sc_com_m_receipt_item.seq_no,
                   sc_com_m_receipt_item.item_type_id AS item_type,
                   sc_com_m_receipt_item.description,
                   sc_com_m_receipt_item.period,
                   sc_com_m_receipt_item.principal_amount,
                   sc_com_m_receipt_item.interest_amount,
                   sc_com_m_receipt_item.item_amount,
                   sc_com_m_receipt_item.balance,
                   COALESCE(sc_com_m_receipt_item.interest_return,0) AS interest_return
            FROM sc_com_m_receipt_item, sc_com_m_receipt
            WHERE sc_com_m_receipt_item.receipt_no = sc_com_m_receipt.receipt_no
              AND sc_com_m_receipt.money_type_id IN ('CLR','TRL')
              AND sc_com_m_receipt.receipt_status = '0'
              AND sc_com_m_receipt.loan_contract_no = {0}", loanContractNo);
    }

    // ── sub 7: หลายวัตถุประสงค์ (u_tabpg_loan_detail_multiobject) grid ──
    public async Task<List<LoanDetailMultiobjectDto>> GetLoanDetailMultiobjectAsync(string loanContractNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<LoanDetailMultiobjectDto>(@"
            SELECT sc_lon_m_contract.loan_contract_no,
                   sc_lon_m_req_object_code.seq_no,
                   (SELECT loan_objective_code||' - '||loan_objective_description
                      FROM sc_lon_m_ucf_loan_obj
                     WHERE loan_objective_code = sc_lon_m_req_object_code.loan_object_code
                       AND loan_type = sc_lon_m_contract.loan_type) AS loan_object_code,
                   sc_lon_m_req_object_code.loan_object_amount,
                   sc_lon_m_req_object_code.remark
            FROM sc_lon_m_req_object_code, sc_lon_m_contract
            WHERE sc_lon_m_req_object_code.loan_requestment_no = sc_lon_m_contract.loan_requestment_no
              AND sc_lon_m_contract.loan_contract_no = {0}
            ORDER BY sc_lon_m_req_object_code.seq_no", loanContractNo);
    }

    // ── sub 8: ค่างวดรายเดือน (u_tabpg_loan_detail_step_pay — dsStepPay) grid ──
    public async Task<List<LoanDetailStepPayDto>> GetLoanDetailStepPayAsync(string loanContractNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<LoanDetailStepPayDto>(@"
            SELECT sc_lon_m_loan_request_step_pay.loan_requestment_no,
                   COALESCE(LAG(sc_lon_m_loan_request_step_pay.period_step + 1)
                            OVER (PARTITION BY sc_lon_m_loan_request_step_pay.loan_requestment_no
                                  ORDER BY sc_lon_m_loan_request_step_pay.period_step), 1) AS period_step_bf,
                   sc_lon_m_loan_request_step_pay.period_step,
                   sc_lon_m_loan_request_step_pay.period_payment,
                   sc_lon_m_loan_request_step_pay.effective_date
            FROM sc_lon_m_loan_request_step_pay, sc_lon_m_loan_request, sc_lon_m_rule
            WHERE 1=1
              AND sc_lon_m_loan_request.loan_requestment_no = sc_lon_m_loan_request_step_pay.loan_requestment_no
              AND sc_lon_m_loan_request.loan_type = sc_lon_m_rule.loan_type
              AND sc_lon_m_loan_request_step_pay.loan_requestment_no =
                  (SELECT loan_requestment_no FROM sc_lon_m_contract WHERE loan_contract_no = {0})
            ORDER BY sc_lon_m_loan_request_step_pay.period_step", loanContractNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G4 "เรียกเก็บ" (3 tabs) — port dsDetail/dsLoad/dsYearDetail/dsDetMonthDetail
    //  Oracle→PG: decode→CASE, NVL→COALESCE, Substr→substr, window funcs เหมือนเดิม
    // ════════════════════════════════════════════════════════════════════════

    // ── G4 Tab 1: การจ่ายเงิน (u_tabpg_mem_detail_money_payment.dsDetail) ──
    //  ฟิลด์ระดับใบเสร็จโชว์เฉพาะแถวแรกของใบเสร็จ (getrow=1) — แถวถัดไป null (เลียน decode)
    public async Task<List<MoneyPaymentDto>> GetMoneyPaymentAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<MoneyPaymentDto>(@"
            SELECT sc_com_m_receipt.receipt_no AS receipt_no,
                   sc_com_m_receipt.receipt_date AS receipt_date,
                   sc_com_m_receipt.cheque_date AS trans_date,
                   CASE WHEN td.getrow = 1 THEN
                       (SELECT money_type_name FROM sc_com_m_ucf_money_type ucf
                         WHERE ucf.money_type_id = sc_com_m_receipt.money_type_id) END AS money_name,
                   CASE WHEN td.getrow = 1 THEN
                       COALESCE((SELECT ab.name_resize FROM sc_acc_m_ucf_bank ab, sc_fin_m_bank fb
                                  WHERE fb.bank_id = ab.bank_id AND sc_com_m_receipt.fin_bank = fb.bank_fin), ' ') END AS bank_name,
                   CASE WHEN td.getrow = 1 THEN sc_com_m_receipt.money_trans_amount END AS money_trans,
                   CASE WHEN td.getrow = 1 THEN
                       COALESCE((SELECT sum(item_amount) FROM sc_com_m_receipt_item rd
                                  WHERE rd.receipt_no = sc_com_m_receipt.receipt_no AND rd.loan_type = 'SH'), 0) END AS buy_share,
                   td.getrow,
                   td.loan_contract_no,
                   td.principal_amount,
                   td.interest_amount,
                   td.item_amount,
                   CASE WHEN td.getrow = 1 THEN
                       COALESCE((SELECT sum(item_amount) FROM sc_com_m_receipt_item rd
                                  WHERE rd.receipt_no = sc_com_m_receipt.receipt_no), 0) END AS total_payment,
                   CASE WHEN td.getrow = 1 THEN sc_com_m_receipt.money_trans_return END AS money_return
            FROM sc_com_m_receipt,
                 ( SELECT sc_com_m_receipt_item.receipt_no,
                          sum(1) OVER (PARTITION BY sc_com_m_receipt_item.receipt_no ORDER BY sc_com_m_receipt_item.seq_no) AS getrow,
                          substr(trim(sc_com_m_receipt_item.description), 1, 15) AS loan_contract_no,
                          sc_com_m_receipt_item.principal_amount,
                          sc_com_m_receipt_item.interest_amount,
                          sc_com_m_receipt_item.item_amount
                   FROM sc_com_m_receipt_item, sc_com_m_receipt
                   WHERE sc_com_m_receipt_item.receipt_no = sc_com_m_receipt.receipt_no
                     AND sc_com_m_receipt_item.loan_type <> 'SH'
                     AND sc_com_m_receipt.receipt_status = '0'
                 ) td
            WHERE sc_com_m_receipt.receipt_no = td.receipt_no
              AND sc_com_m_receipt.membership_no = {0}
            ORDER BY sc_com_m_receipt.receipt_date DESC, sc_com_m_receipt.receipt_no", membershipNo);
    }

    // ── G4 Tab 2: เรียกเก็บรายเดือน (u_tabpg_mem_detail_monthly_return.dsLoad) ──
    //  receive_year +543 (พ.ศ.); unkeep_amount = money_amount − money_amount_not (filter > 0)
    //  unkeep_real = max(unkeep_amount − ppm_amout, 0) (ติดลบ → 0, เลียน CASE)
    public async Task<List<MonthlyReturnDto>> GetMonthlyReturnAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<MonthlyReturnDto>(@"
            SELECT tx.* FROM (
              SELECT tm.*,
                     COALESCE(money_amount, 0) - COALESCE(money_amount_not, 0) AS unkeep_amount,
                     CASE WHEN (COALESCE(money_amount, 0) - COALESCE(money_amount_not, 0) - ppm_amout) > 0
                          THEN (COALESCE(money_amount, 0) - COALESCE(money_amount_not, 0) - ppm_amout)
                          ELSE 0 END AS unkeep_real
              FROM (
                SELECT sc_kep_t_monthly_receive.receive_year + 543 AS receive_year,
                       sc_kep_t_monthly_receive.receive_month,
                       sc_kep_t_monthly_receive.membership_no,
                       sc_kep_t_monthly_receive.seq_no,
                       sum(sc_kep_t_monthly_receive_det.money_amount) AS money_amount,
                       sum(sc_kep_t_monthly_receive_det.money_amount_not) AS money_amount_not,
                       ( SELECT max(receipt_date) FROM sc_com_m_receipt
                          WHERE receipt_mode = 'R' AND receipt_status = '0'
                            AND month_receipt_no = sc_kep_t_monthly_receive.receipt_no ) AS ppm_date,
                       ( SELECT COALESCE(sum(recept_amount), 0) FROM sc_com_m_receipt
                          WHERE receipt_mode = 'R' AND receipt_status = '0'
                            AND month_receipt_no = sc_kep_t_monthly_receive.receipt_no ) AS ppm_amout,
                       sc_kep_t_monthly_receive.reason_return,
                       sc_kep_t_monthly_receive.ppm_status
                FROM sc_kep_t_monthly_receive, sc_kep_t_monthly_receive_det
                WHERE sc_kep_t_monthly_receive.membership_no = sc_kep_t_monthly_receive_det.membership_no
                  AND sc_kep_t_monthly_receive.receive_year = sc_kep_t_monthly_receive_det.receive_year
                  AND sc_kep_t_monthly_receive.receive_month = sc_kep_t_monthly_receive_det.receive_month
                  AND sc_kep_t_monthly_receive.seq_no = sc_kep_t_monthly_receive_det.seq_no
                  AND sc_kep_t_monthly_receive.receipt_status = '2'
                  AND sc_kep_t_monthly_receive.membership_no = {0}
                GROUP BY sc_kep_t_monthly_receive.receive_year, sc_kep_t_monthly_receive.receive_month,
                         sc_kep_t_monthly_receive.membership_no, sc_kep_t_monthly_receive.seq_no,
                         sc_kep_t_monthly_receive.receipt_no, sc_kep_t_monthly_receive.reason_return,
                         sc_kep_t_monthly_receive.ppm_status
              ) tm
            ) tx
            WHERE unkeep_amount > 0
            ORDER BY tx.receive_year DESC, tx.receive_month DESC", membershipNo);
    }

    // ── G4 Tab 2 popup: รายละเอียดใบเสร็จคืน (popMonthlyReturn.dsLoad + ofLoad WHERE) ──
    //  receiveYear รับเป็น พ.ศ. → ลบ 543 เป็น ค.ศ. ก่อน query (เลียน ofLoad: toInteger(valx[0]) - 543)
    public async Task<List<MonthlyReturnDetailDto>> GetMonthlyReturnDetailAsync(string membershipNo, int receiveYear, int receiveMonth, decimal seqNo)
    {
        await using var scDb = dbFactory.create();
        var yearCE = receiveYear - 543;
        return await scDb.getListAsync<MonthlyReturnDetailDto>(@"
            SELECT sc_kep_t_monthly_receive_det.receive_seq,
                   sc_kep_t_monthly_receive_det.keeping_type_code,
                   sc_kep_t_monthly_receive_det.receive_description,
                   sc_kep_t_monthly_receive_det.period,
                   COALESCE(sc_kep_t_monthly_receive_det.principal_of_loan, 0) AS keeping_p,
                   COALESCE(sc_kep_t_monthly_receive_det.interest, 0) AS keeping_i,
                   COALESCE(sc_kep_t_monthly_receive_det.money_amount, 0) AS keeping_a,
                   COALESCE(sc_kep_t_monthly_receive_det.principal_not, 0) AS income_p,
                   COALESCE(sc_kep_t_monthly_receive_det.interest_not, 0) AS income_i,
                   COALESCE(sc_kep_t_monthly_receive_det.money_amount_not, 0) AS income_a,
                   COALESCE(sc_kep_t_monthly_receive_det.principal_of_loan, 0) - COALESCE(sc_kep_t_monthly_receive_det.principal_not, 0) AS unkeep_p,
                   COALESCE(sc_kep_t_monthly_receive_det.interest, 0) - COALESCE(sc_kep_t_monthly_receive_det.interest_not, 0) AS unkeep_i,
                   COALESCE(sc_kep_t_monthly_receive_det.money_amount, 0) - COALESCE(sc_kep_t_monthly_receive_det.money_amount_not, 0) AS unkeep_a
            FROM sc_kep_t_monthly_receive, sc_kep_t_monthly_receive_det, sc_kep_m_ucf_keeping_item_type
            WHERE sc_kep_t_monthly_receive.membership_no = sc_kep_t_monthly_receive_det.membership_no
              AND sc_kep_t_monthly_receive.receive_year = sc_kep_t_monthly_receive_det.receive_year
              AND sc_kep_t_monthly_receive.receive_month = sc_kep_t_monthly_receive_det.receive_month
              AND sc_kep_t_monthly_receive.seq_no = sc_kep_t_monthly_receive_det.seq_no
              AND sc_kep_t_monthly_receive_det.keeping_type_code = sc_kep_m_ucf_keeping_item_type.keeping_type_code
              AND sc_kep_t_monthly_receive.membership_no = {0}
              AND sc_kep_t_monthly_receive.receive_year = {1}
              AND sc_kep_t_monthly_receive.receive_month = {2}
              AND sc_kep_t_monthly_receive.seq_no = {3}
            ORDER BY CASE sc_kep_m_ucf_keeping_item_type.keeping_type_group WHEN 'SHR' THEN 1 WHEN 'LON' THEN 2 ELSE 3 END,
                     sc_kep_t_monthly_receive_det.keeping_type_code,
                     sc_kep_t_monthly_receive_det.receive_description",
            membershipNo, yearCE, receiveMonth, seqNo);
    }

    // ── G4 Tab 3: หักผ่านธนาคาร — รายการปี (dsYearDetail) — receive_year +543 (พ.ศ.) ──
    public async Task<List<GiroYearDto>> GetGiroYearsAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<GiroYearDto>(@"
            SELECT DISTINCT sc_kep_monthly_giro_file.receive_year + 543 AS receive_year
            FROM sc_kep_monthly_giro_file
            WHERE sc_kep_monthly_giro_file.membership_no = {0}
            ORDER BY receive_year DESC", membershipNo);
    }

    // ── G4 Tab 3: เดือนล่าสุดของปีที่ระบุ (default focus — เลียน eDataBinding max(receive_month)) ──
    //  receiveYear รับเป็น พ.ศ. → ลบ 543 (ตาราง receive_year เก็บ ค.ศ.)
    public async Task<int?> GetGiroLatestMonthAsync(string membershipNo, int receiveYear)
    {
        await using var scDb = dbFactory.create();
        var yearCE = receiveYear - 543;
        var v = await scDb.getValueAsync(@"
            SELECT max(receive_month) FROM sc_kep_monthly_giro_file
            WHERE membership_no = {0} AND receive_year = {1}", membershipNo, yearCE);
        var m = sc.value.toInteger(v);
        return m > 0 ? m : null;
    }

    // ── G4 Tab 3: รายละเอียดเดือน (dsDetMonthDetail) — seq ล่าสุดของปี/เดือน/สมาชิก ──
    //  receiveYear รับเป็น พ.ศ. → ลบ 543 (เลียน page.js: GetValue() - 543 ก่อนส่ง RECEIVE_YEAR)
    public async Task<List<GiroDetailDto>> GetGiroDetailAsync(string membershipNo, int receiveYear, int receiveMonth)
    {
        await using var scDb = dbFactory.create();
        var yearCE = receiveYear - 543;
        return await scDb.getListAsync<GiroDetailDto>(@"
            SELECT user_id, money_amount, paid_amount, giro_amount, balance, receipt_status,
                   membership_no, receive_year, receive_month, seq_no
            FROM sc_kep_monthly_giro_file
            WHERE sc_kep_monthly_giro_file.membership_no = {0}
              AND sc_kep_monthly_giro_file.receive_year = {1}
              AND sc_kep_monthly_giro_file.receive_month = {2}
              AND sc_kep_monthly_giro_file.seq_no = (
                    SELECT max(kg.seq_no) FROM sc_kep_monthly_giro_file kg
                     WHERE kg.receive_year = sc_kep_monthly_giro_file.receive_year
                       AND kg.receive_month = sc_kep_monthly_giro_file.receive_month
                       AND kg.membership_no = sc_kep_monthly_giro_file.membership_no )",
            membershipNo, yearCE, receiveMonth);
    }

    // ════════════════════════════════════════════════════════════════════════════
    //  G5 การเงิน/เงินฝาก (3 tabs) + popup popDeptDetail (3 sub-tabs)
    // ════════════════════════════════════════════════════════════════════════════

    // ── G5 Tab 1: รายละเอียดเงินฝาก (dsDeptDetail) — sc_dep_m_creditor + _rule ──
    //  Oracle→PG: nvl→COALESCE, decode→CASE. fp_form_depno ใช้ได้ใน PG แล้ว
    public async Task<List<DepositListDto>> GetDepositListAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<DepositListDto>(@"
            SELECT sc_dep_m_creditor.deposit_account_no,
                   pka_com_function.fp_form_depno(sc_dep_m_creditor.deposit_account_no) AS deposit_account_no2,
                   sc_dep_m_creditor.deposit_account_name,
                   sc_dep_m_creditor.deposit_type_code,
                   sc_dep_m_creditor.deposit_opened_date,
                   COALESCE((sc_dep_m_creditor.deposit_type_code || '-' || sc_dep_m_rule.deposit_name), '-') AS deposit_type,
                   CASE WHEN sc_dep_m_creditor.monthly_deposit_status = '1'
                        THEN sc_dep_m_creditor.monthly_deposit_amount ELSE 0 END AS monthly_deposit_amount,
                   sc_dep_m_creditor.deposit_balance,
                   sc_dep_m_creditor.withdrawable_amount,
                   sc_dep_m_creditor.cheque_pending_amount,
                   CASE WHEN sc_dep_m_creditor.sequester_status = '1'
                        THEN sc_dep_m_creditor.deposit_standsecurity_amount ELSE 0 END AS deposit_standsecurity_amount,
                   sc_dep_m_creditor.loan_holding_amount,
                   sc_dep_m_creditor.deposit_balance AS deposit_balance_t,
                   sc_dep_m_creditor.last_calcint_date,
                   sc_dep_m_creditor.accumulate_interest,
                   sc_dep_m_creditor.close_status,
                   sc_dep_m_creditor.officer_id
            FROM sc_dep_m_creditor, sc_dep_m_rule
            WHERE sc_dep_m_creditor.deposit_type_code = sc_dep_m_rule.deposit_type_code
              AND sc_dep_m_creditor.membership_no = {0}
            ORDER BY sc_dep_m_creditor.close_status, sc_dep_m_creditor.deposit_type_code, sc_dep_m_creditor.deposit_account_no",
            membershipNo);
    }

    // ── G5 Tab 2: ข้อมูลเครดิต (dsCredit) — sc_mem_m_member_credit ──
    public async Task<List<CreditDto>> GetCreditAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<CreditDto>(@"
            SELECT sc_mem_m_member_credit.membership_no,
                   sc_mem_m_member_credit.seq_no,
                   sc_mem_m_member_credit.credit_code,
                   sc_mem_m_member_credit.credit_desc,
                   (SELECT credit_desc FROM sc_mem_m_ucf_credit_management
                     WHERE sc_mem_m_ucf_credit_management.credit_code = sc_mem_m_member_credit.credit_code) AS credit_detail
            FROM sc_mem_m_membership_registered, sc_mem_m_member_credit
            WHERE (sc_mem_m_membership_registered.membership_no = sc_mem_m_member_credit.membership_no)
              AND sc_mem_m_member_credit.membership_no = {0}
            ORDER BY sc_mem_m_member_credit.membership_no, sc_mem_m_member_credit.credit_code",
            membershipNo);
    }

    // ── G5 Tab 3: เงินรอจ่ายคืน (dsDatail) — sc_fin_money_return ──
    //  หมายเหตุ: ตาราง sc_fin_ucf_money_retrun สะกดผิดใน legacy — คงไว้ตามจริง
    public async Task<List<MoneyReturnDto>> GetMoneyReturnAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<MoneyReturnDto>(@"
            SELECT sc_fin_money_return.membership_no,
                   sc_fin_money_return.item_no,
                   sc_fin_money_return.operate_date,
                   sc_fin_money_return.money_return,
                   sc_fin_money_return.return_method,
                   sc_fin_money_return.request_method,
                   sc_fin_money_return.refno1,
                   sc_fin_money_return.remark,
                   sc_fin_money_return.request_bankid,
                   sc_fin_money_return.request_bankac,
                   sc_fin_money_return.return_status,
                   sc_fin_money_return.request_status,
                   sc_fin_money_return.cancel_status,
                   sc_fin_money_return.paid_id,
                   (SELECT sc_com_m_receipt.cheque_date FROM sc_com_m_receipt
                     WHERE sc_com_m_receipt.receipt_no = sc_fin_money_return.refno1) AS trans_date,
                   (SELECT sc_fin_m_bank.bank_name FROM sc_com_m_receipt, sc_fin_m_bank
                     WHERE sc_com_m_receipt.receipt_no = sc_fin_money_return.refno1
                       AND sc_com_m_receipt.fin_bank = sc_fin_m_bank.bank_fin) AS trans_bank,
                   (SELECT sc_fin_ucf_money_retrun.return_desc FROM sc_fin_ucf_money_retrun
                     WHERE sc_fin_ucf_money_retrun.return_method = sc_fin_money_return.return_method) AS return_desc,
                   fpb_fin_get_money_return_date(sc_fin_money_return.membership_no, sc_fin_money_return.item_no) AS return_date
            FROM sc_fin_money_return
            WHERE 1 = 1
              AND (sc_fin_money_return.cancel_status = '0')
              AND (sc_fin_money_return.membership_no = {0})
            ORDER BY item_no",
            membershipNo);
    }

    // ── G5 popup Tab 1: ข้อมูลเงินฝาก — sc_dep_m_creditor (key = deposit_account_no ดิบ) ──
    public async Task<DepositMainDto?> GetDepositMainAsync(string depositAccountNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getOneAsync<DepositMainDto>(@"
            SELECT sc_dep_m_creditor.membership_no,
                   pka_com_function.fp_get_member_name(sc_dep_m_creditor.membership_no) AS member_name,
                   sc_dep_m_creditor.deposit_type_code || ' ' || sc_dep_m_rule.deposit_name AS deposit_type_code,
                   sc_dep_m_creditor.deposit_account_no,
                   sc_dep_m_creditor.deposit_account_name,
                   sc_dep_m_creditor.passbook_no,
                   sc_dep_m_creditor.deposit_opened_date,
                   sc_dep_m_creditor.deposit_objective,
                   sc_dep_m_creditor.deposit_balance,
                   sc_dep_m_creditor.withdrawable_amount,
                   sc_dep_m_creditor.withdraw_count,
                   sc_dep_m_creditor.accumulate_interest,
                   sc_dep_m_creditor.remark,
                   sc_dep_m_creditor.monthly_int_status,
                   sc_dep_m_creditor.monthly_deposit_status,
                   sc_dep_m_creditor.monthly_deposit_amount,
                   sc_dep_m_creditor.froce_close_date
            FROM sc_dep_m_creditor, sc_dep_m_rule, sc_mem_m_membership_registered
            WHERE (sc_dep_m_rule.deposit_type_code = sc_dep_m_creditor.deposit_type_code)
              AND (sc_dep_m_creditor.membership_no = sc_mem_m_membership_registered.membership_no)
              AND (sc_dep_m_creditor.deposit_account_no = {0})",
            depositAccountNo);
    }

    // ── G5 popup Tab 2: การเคลื่อนไหว — sc_dep_m_creditor_item (decode→CASE) ──
    public async Task<List<DepositMovementDto>> GetDepositMovementAsync(string depositAccountNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<DepositMovementDto>(@"
            SELECT sc_dep_m_creditor_item.seq_no,
                   sc_dep_m_creditor_item.operate_date,
                   sc_dep_m_creditor_item.refer_to_deposit_doc_no,
                   sc_dep_m_creditor_item.item_type,
                   sc_dep_m_creditor_item.officer_id,
                   sc_dep_m_creditor_item.last_access_date,
                   sc_dep_m_ucf_dep_item_type.print_code,
                   sc_dep_m_ucf_dep_item_type.print_code || ' - ' || sc_dep_m_ucf_dep_item_type.deposit_item_description AS print_code_desc,
                   sc_dep_m_ucf_dep_item_type.deposit_item_description,
                   CASE WHEN sc_dep_m_ucf_dep_item_type.sign_flag = -1
                        THEN sc_dep_m_creditor_item.deposit_balance ELSE 0 END AS c_wamount,
                   CASE WHEN sc_dep_m_ucf_dep_item_type.sign_flag = 1
                        THEN sc_dep_m_creditor_item.deposit_balance ELSE 0 END AS c_damount,
                   sc_dep_m_creditor_item.total_balance
            FROM sc_dep_m_creditor_item, sc_dep_m_ucf_dep_item_type
            WHERE (sc_dep_m_creditor_item.item_type = sc_dep_m_ucf_dep_item_type.deposit_item_type)
              AND (sc_dep_m_creditor_item.deposit_account_no = {0})
            ORDER BY sc_dep_m_creditor_item.seq_no",
            depositAccountNo);
    }

    // ── G5 popup Tab 3: ภาระค้ำประกัน — sc_lon_m_contract_coll (nvl→COALESCE) ──
    public async Task<List<DepositCollDto>> GetDepositCollAsync(string depositAccountNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<DepositCollDto>(@"
            SELECT sc_lon_m_contract.loan_contract_no,
                   sc_mem_m_membership_registered.membership_no,
                   sc_mem_m_membership_registered.membership_no || ' - ' ||
                     (SELECT prename FROM sc_mem_m_ucf_prename WHERE prename_code = sc_mem_m_membership_registered.prename_code) ||
                     sc_mem_m_membership_registered.member_name || '  ' || sc_mem_m_membership_registered.member_surname AS member_name,
                   sc_lon_m_contract.loan_approve_amount,
                   sc_lon_m_loan_card.principal_balance,
                   sc_lon_m_contract_coll.used_amount
            FROM sc_lon_m_contract_coll, sc_lon_m_contract, sc_lon_m_loan_card, sc_lon_m_rule, sc_mem_m_membership_registered
            WHERE sc_lon_m_contract.loan_contract_no = sc_lon_m_contract_coll.loan_contract_no
              AND sc_lon_m_contract.loan_contract_no = sc_lon_m_loan_card.loan_contract_no
              AND sc_lon_m_contract.loan_type = sc_lon_m_rule.loan_type
              AND sc_lon_m_contract.membership_no = sc_mem_m_membership_registered.membership_no
              AND sc_lon_m_contract_coll.collateral_type_code = '03'
              AND sc_lon_m_contract_coll.status = '0'
              AND (sc_lon_m_loan_card.principal_balance > 0
                   OR ((sc_lon_m_rule.atm_status = '1' OR sc_lon_m_rule.loan_looping = '1') AND sc_lon_m_loan_card.close_status = '0')
                      AND COALESCE((SELECT modify_status FROM sc_atm_lon_card WHERE loan_contract_no = sc_lon_m_loan_card.loan_contract_no), '0') != 'C')
              AND NOT EXISTS (SELECT NULL FROM sc_lon_m_rule td WHERE td.loan_tran_type = sc_lon_m_rule.loan_type)
              AND sc_lon_m_contract_coll.ref_own_no = {0}
            ORDER BY sc_lon_m_contract.loan_contract_no",
            depositAccountNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G6 "รายละเอียดอื่น" 6 tabs
    // ════════════════════════════════════════════════════════════════════════

    // ── G6 Tab 1: สถานะสมาชิก — sc_mem_m_member_special (DECODE→CASE ใน ORDER BY) ──
    public async Task<List<StatusDetailDto>> GetStatusDetailAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<StatusDetailDto>(@"
            SELECT sc_mem_m_member_special.debtor_code,
                   (SELECT debtor_desc FROM sc_mem_m_ucf_debtor
                     WHERE sc_mem_m_member_special.debtor_code = sc_mem_m_ucf_debtor.debtor_code) AS debtor_desc,
                   sc_mem_m_member_special.deptor_detail,
                   seq_no
            FROM sc_mem_m_member_special
            WHERE sc_mem_m_member_special.membership_no = {0}
            ORDER BY (CASE sc_mem_m_member_special.debtor_code WHEN '39' THEN 1 WHEN '๓๙' THEN 2 ELSE 99 END),
                     sc_mem_m_member_special.debtor_code",
            membershipNo);
    }

    // ── G6 Tab 2: สถานะธุรการ — sc_mem_m_membership_registered (single row)
    //   mirror legacy dsData เป๊ะ: nvl→COALESCE; pkb_ktm.fp_get_msg_level_loan → '' AS msg (KTM-only)
    //   NB: legacy UI comment ปิด checkbox ส่วนใหญ่ไว้ → SELECT ตรงตาม legacy (adj_payroll/att_loan_permit ดึงแต่ UI ซ่อน)
    public async Task<AdmstatusDto?> GetAdmstatusAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getOneAsync<AdmstatusDto>(@"
            SELECT drop_loanemer_status, drop_loanspec_status, drop_loannormal_status, collactelral_status,
                   force_keeping, adj_payroll, att_loan_permit,
                   COALESCE((SELECT doc_place FROM sc_mem_m_ucf_doc_place
                              WHERE item_code = sc_mem_m_membership_registered.doc_place_status), '[ไม่ระบุ]') AS doc_place_status,
                   COALESCE((SELECT branch_name FROM sc_com_m_branch
                              WHERE branch_id = sc_mem_m_membership_registered.branch_id), '[ไม่ระบุ]') AS branch_id,
                   COALESCE((SELECT debtor_desc FROM sc_mem_m_ucf_debtor
                              WHERE debtor_code = sc_mem_m_membership_registered.debtor_code), '[ไม่ระบุ]') AS debtor_code,
                   COALESCE((SELECT saving_name FROM sc_mem_m_ucf_othersaving
                              WHERE other_saving_member = sc_mem_m_membership_registered.other_saving_member), '[ไม่ระบุ]') AS other_saving_member,
                   COALESCE((SELECT description FROM sc_mem_m_ucf_shareloan_status
                              WHERE shareloan_code = sc_mem_m_membership_registered.shareloan_code), '[ไม่ระบุ]') AS shareloan_code,
                   COALESCE((SELECT description FROM sc_mem_m_ucf_group_position
                              WHERE group_position = sc_mem_m_membership_registered.other_code), '[ไม่ระบุ]') AS other_code,
                   COALESCE((SELECT mem_type_desc FROM sc_mem_m_ucf_other_code
                              WHERE mem_type_code = sc_mem_m_membership_registered.other_status), '[ไม่ระบุ]') AS other_status,
                   crem_status, represent_status, committee_status, official_status, agent_status, inspector_status,
                   refer_keep, coll_resign, share_remain, internal_auditor, advisor_president, representive_position,
                   advisor_coop, lon_restruc, '' AS msg
            FROM sc_mem_m_membership_registered
            WHERE membership_no = {0}",
            membershipNo);
    }

    // ── G6 Tab 3: บันทึกหมายเหตุ — sc_mem_m_member_memo ──
    public async Task<List<CommentLogDto>> GetCommentLogAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<CommentLogDto>(@"
            SELECT membership_no, seq_no, memo_code, memo_detail, entry_date, entry_id, entry_br, entry_pc,
                   operate_date, drop_emer, drop_norm, drop_spec, drop_coll, lon_restruc
            FROM sc_mem_m_member_memo
            WHERE membership_no = {0} AND cancel_status = '0'
            ORDER BY seq_no",
            membershipNo);
    }

    // ── G6 Tab 4: ทุนการศึกษา — sc_sch_mem_regis + sc_sch_rule_type
    //   +543 พ.ศ.; DECODE→CASE; SUBSTR base-0 fix (Oracle SUBSTR(x,0,n)=first n → PG substr(x,1,n))
    public async Task<List<SchDetailDto>> GetSchDetailAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<SchDetailDto>(@"
            SELECT (sc_sch_mem_regis.receive_year + 543) AS receive_year, requestment_no, receiver_type,
                   sc_sch_rule_type.sch_desc, id_card,
                   (SELECT prename FROM sc_mem_m_ucf_prename
                     WHERE sc_sch_mem_regis.prename_code = sc_mem_m_ucf_prename.prename_code) || receiver_name || ' ' || receiver_surname AS sch_name,
                   sc_sch_mem_regis.sch_receive, approve_status,
                   (CASE payment_type_code WHEN 'DEP' THEN 'เงินฝาก' WHEN 'BNK' THEN 'ธนาคาร' WHEN 'CSH' THEN 'เงินสด' END) AS payment_type_code,
                   (CASE payment_type_code
                       WHEN 'DEP' THEN substr(deposit_accno,1,2) || '-' || substr(deposit_accno,3,8)
                       WHEN 'BNK' THEN substr(bank_accno,1,3) || '-' || substr(bank_accno,4,6) || '-' || substr(bank_accno,10,1)
                       WHEN 'CSH' THEN ' - ' END) AS payment_name
            FROM sc_sch_mem_regis, sc_sch_rule_type
            WHERE (school_class = sch_class) AND (cancel_status != '1') AND membership_no = {0}
            ORDER BY receive_year, receiver_type",
            membershipNo);
    }

    // ── G6 Tab 5: อายัด — sc_mem_m_membership_sequester ──
    public async Task<List<SequesterDto>> GetSequesterAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<SequesterDto>(@"
            SELECT membership_no, seq_no, sqter_status, sqter_share, sqter_div, sqter_aver, sqter_other,
                   begin_date, end_date, department, number_of_case, plaintiff, defendant, condition, remark,
                   address_desc, prename_group, fee_amount, cheque_no, court, money_type_id, deed_status
            FROM sc_mem_m_membership_sequester
            WHERE membership_no = {0}
            ORDER BY seq_no",
            membershipNo);
    }

    // ── G6 Tab 6: ดำเนินคดี — sc_law_prosecutions + sc_mem_m_membership_registered
    //   pka_com_function.fp_get_member_name → เรียกตรง (มีใน DEV DB)
    public async Task<List<LawProsecDto>> GetLawProsecAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<LawProsecDto>(@"
            SELECT sc_law_prosecutions.prosec_no, cancel_status, operate_date, member_main, prosec_date,
                   pka_com_function.fp_get_member_name(member_main) AS membermain_name,
                   all_principal_balance, all_interest_arrear,
                   all_principal_balance + all_interest_arrear AS all_asset_amount,
                   lawyer, court_name, sc_mem_m_membership_registered.resign_code
            FROM sc_law_prosecutions, sc_mem_m_membership_registered
            WHERE member_main = membership_no AND member_main = {0}",
            membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  popup ดำเนินคดี (popLaw) 11 sub-tabs (key = prosec_no)
    // ════════════════════════════════════════════════════════════════════════

    // ── sub 1: ค่าธรรมเนียม/ประกัน — sc_law_tadnen_kadee_fee
    //   pka_law.fp_proc_bal_fee(prosec_no,seq) → inline subquery (principal_balance ของ loan_card ที่ insurance_no)
    public async Task<List<LawDepositCollectionDto>> GetLawDepositCollectionAsync(string prosecNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<LawDepositCollectionDto>(@"
            SELECT prosec_no, seq_no, insurance_type, insurance_date, fee_amount, remark, cancel_status, insurance_no,
                   (SELECT COALESCE(lc.principal_balance, 0) FROM sc_lon_m_loan_card lc
                     WHERE lc.loan_contract_no = sc_law_tadnen_kadee_fee.insurance_no) AS total
            FROM sc_law_tadnen_kadee_fee
            WHERE prosec_no = {0}
            ORDER BY seq_no",
            prosecNo);
    }

    // ── sub 2: จำเลย (สรุป) — sc_law_prosec_defendants ──
    public async Task<List<LawCollateralDetailDto>> GetLawCollateralDetailAsync(string prosecNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<LawCollateralDetailDto>(@"
            SELECT prosec_no, seq_no, item_order, membership_no, defendant_name, defendant_type
            FROM sc_law_prosec_defendants
            WHERE prosec_no = {0}
            ORDER BY seq_no",
            prosecNo);
    }

    // ── sub 3: ภาระหนี้คงเหลือตามคำพิพากษา — sc_law_prosec_loan (PROC_ALL_ASSET_AMOUNT = NULL) ──
    public async Task<List<LawLoanDetailStatusDto>> GetLawLoanDetailStatusAsync(string prosecNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<LawLoanDetailStatusDto>(@"
            SELECT prosec_no, loan_contract_no, proc_principal_balance, proc_interest_arrear, last_calcint_date,
                   NULL AS proc_all_asset_amount, interest_arrear
            FROM sc_law_prosec_loan
            WHERE prosec_no = {0}
            ORDER BY loan_contract_no",
            prosecNo);
    }

    // ── sub 4: ดำเนินคดี (default tab) — sc_law_tad_nenkadee_operate ──
    public async Task<List<LawDumNernKadeeDto>> GetLawDumNernKadeeAsync(string prosecNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<LawDumNernKadeeDto>(@"
            SELECT prosec_no, seq_no, operate_date, operate_time, description, remark
            FROM sc_law_tad_nenkadee_operate
            WHERE prosec_no = {0}
            ORDER BY seq_no",
            prosecNo);
    }

    // ── sub 5/7/9: หัวเรื่องคดี — sc_law_tad_nenkadee_head (form single row) ──
    public async Task<LawKadeeHeadDto?> GetLawKadeeHeadAsync(string prosecNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getOneAsync<LawKadeeHeadDto>(@"
            SELECT *
            FROM sc_law_tad_nenkadee_head
            WHERE prosec_no = {0}",
            prosecNo);
    }

    // ── sub 6: หนังสือแจ้งการชำระ — sc_law_tadnen_kadee_notice ──
    public async Task<List<LawBookAlertpayDto>> GetLawBookAlertpayAsync(string prosecNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<LawBookAlertpayDto>(@"
            SELECT prosec_no, seq_no, letter_date, owner_name, result_book, header, prin_amount,
                   doc_no, loan_at_date, entry_id, entry_date
            FROM sc_law_tadnen_kadee_notice
            WHERE prosec_no = {0}
            ORDER BY seq_no",
            prosecNo);
    }

    // ── sub 8: จำเลย (รายละเอียด) — sc_law_prosec_defendants ──
    public async Task<List<LawJumleyDetailDto>> GetLawJumleyDetailAsync(string prosecNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<LawJumleyDetailDto>(@"
            SELECT prosec_no, seq_no, item_order, defendant_name, status, card_id, job, address_no,
                   moo, road, soi, tambol, province_code, distinct_code, post_code, telephone
            FROM sc_law_prosec_defendants
            WHERE prosec_no = {0}
            ORDER BY item_order",
            prosecNo);
    }

    // ── sub 10: ประเมินราคาที่ดิน (cascade) — head combo / head form / detail grid ──
    public async Task<List<sc.ComboItem>> GetLawLandItemCodesAsync(string prosecNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getComboAsync(@"
            SELECT item_code AS item_code, item_code AS item_desc
            FROM sc_law_land_appraisal_head WHERE prosec_no = {0} ORDER BY item_code",
            prosecNo);
    }

    public async Task<LawLandAppraisalHeadDto?> GetLawLandHeadAsync(string prosecNo, string itemCode)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getOneAsync<LawLandAppraisalHeadDto>(@"
            SELECT prosec_no, item_code, tidin, building
            FROM sc_law_land_appraisal_head
            WHERE prosec_no = {0} AND item_code = {1}",
            prosecNo, itemCode);
    }

    public async Task<List<LawLandAppraisalDetailDto>> GetLawLandDetailAsync(string prosecNo, string itemCode)
    {
        await using var scDb = dbFactory.create();
        var rows = await scDb.getListAsync<LawLandAppraisalDetailDto>(@"
            SELECT prosec_no, item_type_code, seq_no, area, space, price_per_unit, price_per_meter, item_code
            FROM sc_law_land_appraisal
            WHERE prosec_no = {0} AND item_code = {1}
            ORDER BY seq_no",
            prosecNo, itemCode);

        // ofDetailCal (เลียน legacy — คำนวณใน C#)
        foreach (var r in rows)
        {
            var area  = r.Area ?? 0m;
            var space = r.Space ?? 0m;
            var ppu   = r.PricePerUnit ?? 0m;
            var ppm   = r.PricePerMeter ?? 0m;
            r.LandParcelAmount       = area * ppu;
            r.TotalPriceSpace        = space * ppm;
            r.TidinAndBuildingAmount = (area * ppu) + (space * ppm);
        }
        return rows;
    }

    // ── sub 11: ขายทอดตลาด (cascade) — head combo / head form / detail grid ──
    public async Task<List<sc.ComboItem>> GetLawBungKubSeqAsync(string prosecNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getComboAsync(@"
            SELECT seq_no_yed AS item_code, seq_no_yed AS item_desc
            FROM sc_law_bung_kub_kadee_result WHERE prosec_no = {0} ORDER BY seq_no_yed",
            prosecNo);
    }

    public async Task<LawBungKubKadeeHeadDto?> GetLawBungKubHeadAsync(string prosecNo, string seqNoYed)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getOneAsync<LawBungKubKadeeHeadDto>(@"
            SELECT *
            FROM sc_law_bung_kub_kadee_result
            WHERE prosec_no = {0} AND seq_no_yed = {1}",
            prosecNo, seqNoYed);
    }

    public async Task<List<LawBungKubKadeeDetailDto>> GetLawBungKubDetailAsync(string prosecNo, string seqNoYed)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<LawBungKubKadeeDetailDto>(@"
            SELECT prosec_no, seq_no, seq_no_yed, operate_date, sale_amount
            FROM sc_law_bang_kup_detail
            WHERE prosec_no = {0} AND seq_no_yed = {1}
            ORDER BY seq_no",
            prosecNo, seqNoYed);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G7 "รายการแก้ไข" (14 tabs) — change-log queries (read-only)
    // ════════════════════════════════════════════════════════════════════════

    // ── tab 1: ประวัติเปลี่ยนหลักประกัน — sc_lon_m_coll_change_head/det (join registered + contract) ──
    // legacy: FP_GET_THAIDATE ตัดออก (display column คือ approve_date raw → format ที่ razor),
    // NEW_*/OPERATE_TYPE cell coloring ทำที่ frontend (CustomizeElement). filter change_status='1' (อนุมัติ)
    public async Task<List<CollChangeHistoryDto>> GetCollChangeHistoryAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<CollChangeHistoryDto>(@"
            SELECT h.change_doc_no, h.membership_no, h.approve_date,
                   (SELECT prename FROM sc_mem_m_ucf_prename WHERE prename_code = r.prename_code)
                       || COALESCE(r.member_name, '') || '  ' || COALESCE(r.member_surname, '') AS member_name,
                   h.loan_contract_no, c.begining_of_contract,
                   (SELECT principal_balance FROM sc_lon_m_loan_card WHERE loan_contract_no = h.loan_contract_no) AS principal_balance,
                   d.old_collateral_refno, d.old_collateral_description,
                   d.new_collateral_refno, d.new_collateral_description, d.new_collateral_amount,
                   h.remark, h.change_status,
                   (CASE h.change_status WHEN '0' THEN 'ไม่อนุมัติ' WHEN '1' THEN 'อนุมัติ'
                        WHEN '2' THEN 'รออนุมัติ' WHEN '3' THEN 'ยกเลิก' END) AS change_status_name,
                   d.operate_type, h.approve_id, h.entry_id, h.entry_date
            FROM sc_lon_m_coll_change_head h
                 JOIN sc_lon_m_coll_change_det d ON h.change_doc_no = d.change_doc_no
                 JOIN sc_mem_m_membership_registered r ON h.membership_no = r.membership_no
                 JOIN sc_lon_m_contract c ON c.loan_contract_no = h.loan_contract_no
            WHERE h.change_status = '1' AND h.membership_no = {0}
            ORDER BY h.change_doc_no",
            membershipNo);
    }

    // ── tab 2: เปลี่ยนรหัสโนติส — sc_mem_edit_debtor_code (subquery sc_mem_m_ucf_debtor) ──
    public async Task<List<DebtorCodeChgDto>> GetDebtorCodeChgAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<DebtorCodeChgDto>(@"
            SELECT e.seq_no, e.operate_date,
                   (SELECT debtor_code || ' - ' || debtor_desc FROM sc_mem_m_ucf_debtor u WHERE u.debtor_code = e.pre_debtor_code) AS pre_debtor_desc,
                   (SELECT debtor_code || ' - ' || debtor_desc FROM sc_mem_m_ucf_debtor u WHERE u.debtor_code = e.debtor_code) AS debtor_desc,
                   e.entry_id, e.remark
            FROM sc_mem_edit_debtor_code e
            WHERE e.membership_no = {0}
            ORDER BY e.seq_no",
            membershipNo);
    }

    // ── tab 3: เปลี่ยนยอดชำระเงินกู้รายเดือน — view_tel_det_chg (<> 'SHR') ──
    public async Task<List<SendMonthChgDto>> GetLoanSendMonthChgAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<SendMonthChgDto>(@"
            SELECT approve_date, loan_contract_no, period_old, period_new, reason_desc
            FROM view_tel_det_chg
            WHERE membership_no = {0} AND loan_contract_no <> 'SHR'",
            membershipNo);
    }

    // ── tab 4: เปลี่ยนยอดส่งหุ้นรายเดือน — view_tel_det_chg (= 'SHR') ──
    public async Task<List<SendMonthChgDto>> GetShareSendMonthChgAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<SendMonthChgDto>(@"
            SELECT approve_date, loan_contract_no, period_old, period_new, reason_desc
            FROM view_tel_det_chg
            WHERE membership_no = {0} AND loan_contract_no = 'SHR'",
            membershipNo);
    }

    // ── tab 5: เปลี่ยนสถานะ/บันทึกช่วยจำ — sc_mem_m_member_permit_changed ──
    // legacy: PKA_SRV_DBATTRIB.GETCOLTEXT('SC_MEM_M_MEMBERSHIP_REGISTERED',TRIM(PERMIT_NAME)) as PERMIT_DESC
    //   → อ่านคำอธิบายสิทธิ์จาก column comment (migrate เป็น pka_srv_dbattrib.getcoltext)
    public async Task<List<MemoStatusChgDto>> GetMemoStatusChgAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<MemoStatusChgDto>(@"
            SELECT entry_date, permit_name,
                   pka_srv_dbattrib.getcoltext('sc_mem_m_membership_registered', trim(permit_name)) AS permit_desc,
                   entry_id, remark_desc
            FROM sc_mem_m_member_permit_changed
            WHERE membership_no = {0}
            ORDER BY permit_name, entry_date DESC",
            membershipNo);
    }

    // ── tab 6: เปลี่ยนโครงการหุ้น-กู้ — sc_mem_edit_shareloan_code (subquery sc_mem_m_ucf_shareloan_status) ──
    public async Task<List<ShareloanCodeChgDto>> GetShareloanCodeChgAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<ShareloanCodeChgDto>(@"
            SELECT e.seq_no, e.operate_date,
                   (SELECT shareloan_code || ' - ' || description FROM sc_mem_m_ucf_shareloan_status u WHERE u.shareloan_code = e.pre_shareloan_code) AS pre_shareloan_desc,
                   (SELECT shareloan_code || ' - ' || description FROM sc_mem_m_ucf_shareloan_status u WHERE u.shareloan_code = e.shareloan_code) AS shareloan_desc,
                   e.entry_id, e.remark
            FROM sc_mem_edit_shareloan_code e
            WHERE e.membership_no = {0}
            ORDER BY e.seq_no",
            membershipNo);
    }

    // ── tab 7: ประวัติเปลี่ยนเกรด — sc_mem_edit_other_code (subquery sc_mem_m_ucf_group_position) ──
    public async Task<List<GradeHistoryChgDto>> GetGradeHistoryChgAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<GradeHistoryChgDto>(@"
            SELECT e.seq_no, e.operate_date,
                   (SELECT description FROM sc_mem_m_ucf_group_position u WHERE u.group_position = e.preother_code) AS preother_desc,
                   (SELECT description FROM sc_mem_m_ucf_group_position u WHERE u.group_position = e.other_code) AS other_desc,
                   e.entry_id, e.remark
            FROM sc_mem_edit_other_code e
            WHERE e.membership_no = {0}
            ORDER BY e.seq_no",
            membershipNo);
    }

    // ── tab 8: เปลี่ยนสถานะอื่น — sc_mem_edit_other_status (subquery sc_mem_m_ucf_other_code) ──
    public async Task<List<OtherStatusChgDto>> GetOtherStatusChgAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<OtherStatusChgDto>(@"
            SELECT e.seq_no, e.operate_date,
                   (SELECT mem_type_desc FROM sc_mem_m_ucf_other_code u WHERE u.mem_type_code = e.preother_status) AS preother_status_desc,
                   (SELECT mem_type_desc FROM sc_mem_m_ucf_other_code u WHERE u.mem_type_code = e.other_status) AS other_status_desc,
                   e.entry_id, e.remark
            FROM sc_mem_edit_other_status e
            WHERE e.membership_no = {0}
            ORDER BY e.seq_no",
            membershipNo);
    }

    // ── tab 9: เปลี่ยนการออมอื่น — sc_mem_edit_other_saving_member (subquery sc_mem_m_ucf_othersaving) ──
    public async Task<List<OtSavingMemberChgDto>> GetOtSavingMemberChgAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<OtSavingMemberChgDto>(@"
            SELECT e.seq_no, e.operate_date,
                   (SELECT saving_name FROM sc_mem_m_ucf_othersaving u WHERE u.other_saving_member = e.pre_other_saving_member) AS pre_saving_desc,
                   (SELECT saving_name FROM sc_mem_m_ucf_othersaving u WHERE u.other_saving_member = e.other_saving_member) AS saving_desc,
                   e.entry_id, e.remark
            FROM sc_mem_edit_other_saving_member e
            WHERE e.membership_no = {0}
            ORDER BY e.seq_no",
            membershipNo);
    }

    // ── tab 10: ประวัติเปลี่ยนที่อยู่ — sc_mem_edit_address (Oracle DECODE → PG CASE, จ.กทม.='10' ใช้ แขวง/เขต) ──
    public async Task<List<AddressHistoryDto>> GetAddressHistoryAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<AddressHistoryDto>(@"
            SELECT a.operate_date, a.address_type,
                   'เลขที่  ' || COALESCE(a.pre_address_no, '')
                   || '  ' || (CASE WHEN a.pre_moo    IS NULL THEN '' ELSE ' หมู่ '     || a.pre_moo    END)
                   ||         (CASE WHEN a.pre_soi    IS NULL THEN '' ELSE ' ซ.'        || a.pre_soi    END)
                   || '  ' || (CASE WHEN a.pre_mooban IS NULL THEN '' ELSE ' หมู่บ้าน ' || a.pre_mooban END)
                   || '  ' || (CASE WHEN a.pre_road   IS NULL THEN '' ELSE ' ถ.'        || a.pre_road   END)
                   ||         (CASE WHEN a.pre_tambol IS NULL THEN '' ELSE (CASE WHEN a.pre_province_code = '10' THEN ' แขวง ' ELSE ' ต. ' END) || a.pre_tambol END)
                   || '  ' || (CASE WHEN a.pre_province_code = '10' THEN ' เขต ' ELSE ' อ. ' END)
                   || COALESCE((SELECT district_name FROM sc_mem_m_ucf_district d WHERE d.district_code = a.pre_district_code AND d.province_code = a.pre_province_code), '')
                   ||         (CASE WHEN a.pre_province_code = '10' THEN '' ELSE ' จ. ' END)
                   || COALESCE((SELECT province_name FROM sc_mem_m_ucf_province p WHERE p.province_code = a.pre_province_code), '')
                   || '  ' || COALESCE(a.pre_postcode, '')
                   || ' โทร ' || COALESCE(a.pre_telephone, '') AS pre_edit,
                   'เลขที่  ' || COALESCE(a.address_no, '')
                   || '  ' || (CASE WHEN a.moo    IS NULL THEN '' ELSE ' หมู่ '     || a.moo    END)
                   ||         (CASE WHEN a.soi    IS NULL THEN '' ELSE ' ซ.'        || a.soi    END)
                   || '  ' || (CASE WHEN a.mooban IS NULL THEN '' ELSE ' หมู่บ้าน ' || a.mooban END)
                   || '  ' || (CASE WHEN a.road   IS NULL THEN '' ELSE ' ถ.'        || a.road   END)
                   ||         (CASE WHEN a.tambol IS NULL THEN '' ELSE (CASE WHEN a.province_code = '10' THEN ' แขวง ' ELSE ' ต. ' END) || a.tambol END)
                   || '  ' || (CASE WHEN a.province_code = '10' THEN ' เขต ' ELSE ' อ. ' END)
                   || COALESCE((SELECT district_name FROM sc_mem_m_ucf_district d WHERE d.district_code = a.district_code AND d.province_code = a.province_code), '')
                   ||         (CASE WHEN a.province_code = '10' THEN '' ELSE ' จ. ' END)
                   || COALESCE((SELECT province_name FROM sc_mem_m_ucf_province p WHERE p.province_code = a.province_code), '')
                   || '  ' || COALESCE(a.postcode, '')
                   || ' โทร ' || COALESCE(a.telephone, '') AS post_edit,
                   a.entry_id, a.entry_date
            FROM sc_mem_edit_address a
            WHERE a.membership_no = {0}
            ORDER BY a.entry_date DESC, a.address_type",
            membershipNo);
    }

    // ── tab 11: ประวัติเปลี่ยนชื่อ-สกุล — sc_mem_edit_name (subquery prename) ──
    public async Task<List<NameHistoryDto>> GetNameHistoryAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<NameHistoryDto>(@"
            SELECT sn.operate_date, sn.doc_edit,
                   (SELECT prename FROM sc_mem_m_ucf_prename WHERE prename_code = sn.pre_prename_code)
                       || ' ' || COALESCE(sn.pre_member_name, '') || ' ' || COALESCE(sn.pre_member_surname, '') AS c_name_pre,
                   (SELECT prename FROM sc_mem_m_ucf_prename WHERE prename_code = sn.prename_code)
                       || ' ' || COALESCE(sn.member_name, '') || ' ' || COALESCE(sn.member_surname, '') AS c_name_edit,
                   sn.entry_id, sn.entry_date
            FROM sc_mem_edit_name sn
            WHERE sn.membership_no = {0}
            ORDER BY sn.entry_date DESC",
            membershipNo);
    }

    // ── tab 12: ประวัติย้ายหน่วยงาน — sc_mem_edit_group (subquery member_group_name) ──
    // legacy DOC_EDIT = subquery MAX(doc_no) จาก sc_mem_m_tran_group; ตาราง migrate มี column doc_edit เก็บไว้แล้ว → ใช้ตรง
    public async Task<List<MoveJobHistoryDto>> GetMoveJobHistoryAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<MoveJobHistoryDto>(@"
            SELECT g.operate_date, g.doc_edit, g.pre_member_group_no, g.member_group_no,
                   (SELECT member_group_name FROM sc_mem_m_ucf_member_group u WHERE u.member_group_no = g.pre_member_group_no) AS pre_member_group_name,
                   (SELECT member_group_name FROM sc_mem_m_ucf_member_group u WHERE u.member_group_no = g.member_group_no) AS member_group_name,
                   g.entry_date, g.entry_id
            FROM sc_mem_edit_group g
            WHERE g.membership_no = {0}
            ORDER BY g.entry_date DESC",
            membershipNo);
    }

    // ── tab 13: ประวัติเปลี่ยนเงินเดือน — sc_mem_edit_salary ──
    public async Task<List<HistorySalaryDto>> GetHistorySalaryAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<HistorySalaryDto>(@"
            SELECT operate_date, pre_salary_amount, salary_amount,
                   pre_academic_salary, academic_salary,
                   pre_remuneration_amount, remuneration_amount,
                   pre_salary_real, salary_real,
                   entry_id, entry_date, entry_br
            FROM sc_mem_edit_salary
            WHERE membership_no = {0}
            ORDER BY entry_date DESC",
            membershipNo);
    }

    // ── tab 14: ประวัติเปลี่ยนสิทธิ์ — sc_mem_m_member_permit_changed ──
    public async Task<List<PermitChangedDto>> GetPermitChangedAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<PermitChangedDto>(@"
            SELECT seq_no, operate_date, old_status, new_status, permit_name, entry_id, entry_date, remark_desc
            FROM sc_mem_m_member_permit_changed
            WHERE membership_no = {0}
            ORDER BY seq_no",
            membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G8 E-Document — ทะเบียนสมาชิก (legacy u_tabpg_edc_memregis)
    // ════════════════════════════════════════════════════════════════════════

    // grid: sc_edoc_mem + doc_type desc จาก sc_edoc_m_ucf_mem
    // legacy dsDetail: with mem as(select .. from SC_EDOC_MEM where membership_no={0}) select * order by doc_type,page_no
    // (legacy bind combo DOC_TYPE แยก → viewer resolve desc ด้วย LEFT JOIN, equivalent)
    public async Task<List<EdocMemDto>> GetEdocMemAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<EdocMemDto>(@"
            SELECT m.application_form_no, m.doc_type,
                   u.mem_doc_desc AS doc_type_name,
                   m.remark, m.entry_date, m.entry_id, m.page_no, m.filename
            FROM sc_edoc_mem m
            LEFT JOIN sc_edoc_m_ucf_mem u ON u.mem_doc_type = m.doc_type
            WHERE m.membership_no = {0}
            ORDER BY m.doc_type, m.page_no",
            membershipNo);
    }

    // popup เปิดเอกสาร (legacy popPDF.popEdocument, case "u_tabpg_edc_memregis"):
    //   table=sc_edoc_mem, folder field=MEMBER_NEW_FOLDER, doc_no=APPLICATION_FORM_NO
    //   path = FILE_INI_ADDRESS||MEMBER_NEW_FOLDER (SC_EDOC_CONSTANT seq_no=1,use_pdf=1) แทน \ ด้วย //
    //   filename ว่าง→ไม่มีไฟล์ ; "DELETED"→ข้อความแจ้งถูกลบ ; อื่น→UrlServerEdocument+path//filename?page=hsn#toolbar=0
    public async Task<EdocPdfResult> GetEdocMemPdfAsync(string membershipNo, string applicationFormNo, string docType, decimal pageNo)
    {
        await using var scDb = dbFactory.create();

        var row = await scDb.getOneAsync<EdocMemDto>(@"
            SELECT filename, entry_id, entry_date
            FROM sc_edoc_mem
            WHERE membership_no = {0} AND doc_type = {1} AND page_no = {2} AND application_form_no = {3}",
            membershipNo, docType, pageNo, applicationFormNo);

        var filename = row?.Filename;
        if (string.IsNullOrWhiteSpace(filename))
            return new EdocPdfResult();                       // ไม่มีไฟล์ → src=null

        if (filename == "DELETED")
            return new EdocPdfResult
            {
                IsDeleted = true,
                DeletedMessage = $"ข้อมูลถูกลบไปแล้วโดย [ {row!.EntryId} ] เวลา : {sc.value.toStringTH(row.EntryDate, true)}"
            };

        var path = (await scDb.getValueAsync(@"
            SELECT file_ini_address || member_new_folder
            FROM sc_edoc_constant WHERE seq_no = 1 AND use_pdf = '1'"))?.ToString() ?? "";
        path = path.Replace("\\", "//");

        var url = sc.app.getAppSettings("UrlServerEdocument") + path + "//" + filename + "?page=hsn#toolbar=0";
        return new EdocPdfResult { Url = url };
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G3: ประวัติการกู้ (u_tabpg_mem_detail_loan_detail_history) — view_tel_det_lon_zero
    //    เลียน dsData: SELECT ... FROM view_tel_det_lon_zero WHERE membership_no = {0}
    //    (view นี้ = สัญญาปิด/ยอด 0 ด้วย ต่างจาก view_tel_det_lon ของ G3 Tab1)
    //    สีแถว (code-behind): loan_group='2' → พื้นขาว font แดง (จัดที่ frontend)
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<LoanDetailHistoryDto>> GetLoanDetailHistoryAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<LoanDetailHistoryDto>(@"
            SELECT view_tel_det_lon_zero.membership_no,
                   view_tel_det_lon_zero.loan_contract_no,
                   view_tel_det_lon_zero.begining_of_contract,
                   view_tel_det_lon_zero.loan_approve_amount,
                   view_tel_det_lon_zero.loan_installment_amount,
                   view_tel_det_lon_zero.period_payment_amount,
                   view_tel_det_lon_zero.last_calcint_date,
                   view_tel_det_lon_zero.last_period,
                   view_tel_det_lon_zero.principal_balance,
                   view_tel_det_lon_zero.year_total_interest,
                   view_tel_det_lon_zero.loan_status,
                   view_tel_det_lon_zero.interest_arrear,
                   view_tel_det_lon_zero.modify_status,
                   view_tel_det_lon_zero.loan_group,
                   view_tel_det_lon_zero.drop_payment_status
            FROM view_tel_det_lon_zero
            WHERE view_tel_det_lon_zero.membership_no = {0}", membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G3: หลักประกัน (u_tabpg_mem_detail_memcoll_detail)
    //    Oracle→PG: nvl→COALESCE, decode→CASE. F_GET_COLLATERAL_DESC ใช้ได้ใน PG
    //    con_order = sum(1) over(partition by loan_contract_no order by collateral_no)
    //    member_status_code='3' → row สีส้ม (บางคอลัมน์) — จัดที่ frontend
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<MemcollDetailDto>> GetMemcollDetailAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<MemcollDetailDto>(@"
            select tab.loan_contract_no,
                   tab.principal_balance,
                   tab.con_order,
                   tab.collateral_desc,
                   tab.ref_own_no,
                   tab.used_amount,
                   tab.loan_type,
                   COALESCE((select member_status_code from sc_mem_m_membership_registered
                             where membership_no = tab.ref_own_no),'0') as member_status_code,
                   tab.salary_amount,
                   tab.close_status
            from (
                select sc_lon_m_contract.loan_contract_no as loan_contract_no,
                       sc_lon_m_contract_coll.collateral_no,
                       sum(1) over(partition by sc_lon_m_contract_coll.loan_contract_no
                                   order by sc_lon_m_contract_coll.collateral_no) as con_order,
                       sc_lon_m_loan_card.principal_balance as principal_balance,
                       sc_lon_m_contract.loan_type,
                       sc_lon_m_contract_coll.ref_own_no,
                       CASE sc_lon_m_contract_coll.collateral_type_code
                            WHEN '01' THEN F_GET_COLLATERAL_DESC(sc_lon_m_contract_coll.loan_contract_no, sc_lon_m_contract_coll.collateral_no, sc_lon_m_contract_coll.collateral_type_code, sc_lon_m_contract_coll.ref_own_no)
                                         ||' [ '||(select member_group_no from sc_mem_m_membership_registered where membership_no = sc_lon_m_contract_coll.ref_own_no)||' ]'
                            WHEN '02' THEN ''
                            WHEN '03' THEN ' '||sc_lon_m_contract_coll.ref_own_no
                            WHEN '04' THEN sc_lon_m_ucf_collateral_type.collateral_description
                                         ||(select ' .'||tambol||' .'||district_des||' .'||province_des from sc_lon_req_coll_law_land where sc_lon_req_coll_law_land.doc_no = sc_lon_m_contract_coll.ref_own_no)
                            ELSE sc_lon_m_contract_coll.collateral_description
                       END as collateral_desc,
                       sc_lon_m_contract_coll.used_amount,
                       COALESCE(sc_lon_m_contract_coll.mem_coll,'0') as mem_coll,
                       COALESCE((select sc_mem_m_member_work_info.salary_amount
                                 from sc_mem_m_member_work_info
                                 where sc_mem_m_member_work_info.membership_no = sc_lon_m_contract_coll.ref_own_no),0) as salary_amount,
                       (select close_status from sc_atm_lon_card where loan_contract_no = sc_lon_m_loan_card.loan_contract_no) as close_status
                from sc_lon_m_contract_coll,
                     sc_lon_m_loan_card,
                     sc_lon_m_contract,
                     sc_lon_m_ucf_collateral_type,
                     sc_mem_m_membership_registered,
                     sc_lon_m_rule
                where sc_lon_m_contract.membership_no = {0}
                  and sc_lon_m_loan_card.loan_type = sc_lon_m_rule.loan_type
                  and (sc_lon_m_loan_card.principal_balance > 0 or (sc_lon_m_rule.atm_status = '1' and sc_lon_m_loan_card.close_status = '0'))
                  and sc_mem_m_membership_registered.membership_no = sc_lon_m_contract.membership_no
                  and sc_lon_m_contract_coll.loan_contract_no = sc_lon_m_contract.loan_contract_no
                  and sc_lon_m_loan_card.loan_contract_no = sc_lon_m_contract.loan_contract_no
                  and sc_lon_m_contract_coll.collateral_type_code = sc_lon_m_ucf_collateral_type.collateral_type_code
                  and (sc_lon_m_contract_coll.status = '0' or sc_lon_m_contract_coll.status is null)
                order by sc_lon_m_loan_card.principal_balance desc,
                         sc_lon_m_contract_coll.loan_contract_no,
                         sc_lon_m_contract_coll.collateral_no
            ) tab
            where (tab.close_status is null or tab.close_status = '0' or tab.principal_balance > 0)",
            membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G6: วิธีชำระเงิน สมาคมฌาปนกิจ (u_tabpg_mem_cremation_paid_det) — sc_mem_m_member_cremation
    //    crem_type = combo sc_mem_m_ucf_member_cremation, crem_paid = combo sc_mem_m_ucf_crem_paid
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<CremationPaidDetDto>> GetCremationPaidDetAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<CremationPaidDetDto>(@"
            select sc_mem_m_member_cremation.membership_no,
                   sc_mem_m_member_cremation.crem_type,
                   sc_mem_m_member_cremation.seq_no,
                   sc_mem_m_member_cremation.crem_number,
                   sc_mem_m_member_cremation.crem_remark,
                   sc_mem_m_member_cremation.crem_memno,
                   sc_mem_m_member_cremation.crem_paid,
                   sc_mem_m_member_cremation.bank_acc_no,
                   sc_mem_m_member_cremation.bank_name,
                   sc_mem_m_member_cremation.deposit_status,
                   sc_mem_m_member_cremation.deposit_account_no
            from sc_mem_m_member_cremation
            where membership_no = {0}", membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G6: สมาคมฌาปนกิจ (u_tabpg_mem_cremation_det) — view_tel_get_creamation
    //  ⚠️ DEFERRED: view_tel_get_creamation ยังไม่มีใน PG (federate 3 Oracle DB
    //     ผ่าน dblink — ยังไม่ตัดสินใจ federation strategy ตาม CLAUDE.md)
    //     → คืน list ว่างไว้ก่อน (frontend แสดง note "รอ federation")
    // ════════════════════════════════════════════════════════════════════════
    public Task<List<CremationDetDto>> GetCremationDetAsync(string membershipNo)
    {
        // TODO: เมื่อ federation ของ view_tel_get_creamation พร้อม → query จริง
        //   legacy: SELECT ... FROM view_tel_get_creamation WHERE membership_no = {0}
        return Task.FromResult(new List<CremationDetDto>());
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G6: สมาชิกสมทบ (u_tabpg_mem_userefer) — สมาชิกที่ผู้นี้เป็นผู้อ้างอิงให้
    //    WHERE membership_no_ref = {0} (ตรงข้ามกับ G2 member_refer ที่ WHERE membership_no)
    //    refer_status='1' หรือ member_status_code='3' → row แดง (จัดที่ frontend)
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<UsereferDto>> GetUsereferAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<UsereferDto>(@"
            SELECT sc_mem_m_member_member_refer.membership_no,
                   sc_mem_m_member_member_refer.seq_no,
                   sc_mem_m_member_member_refer.membership_no_ref,
                   pka_com_function.fp_get_member_name(sc_mem_m_member_member_refer.membership_no) AS member_name,
                   (SELECT member_status_code FROM sc_mem_m_membership_registered
                     WHERE sc_mem_m_membership_registered.membership_no = sc_mem_m_member_member_refer.membership_no) AS member_status_code,
                   sc_mem_m_member_member_refer.conceern_code,
                   sc_mem_m_member_member_refer.entry_id,
                   sc_mem_m_member_member_refer.cancel_id,
                   sc_mem_m_member_member_refer.refer_status
            FROM sc_mem_m_member_member_refer
            WHERE sc_mem_m_member_member_refer.membership_no_ref = {0}
            ORDER BY member_status_code, sc_mem_m_member_member_refer.membership_no", membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G7: ประวัติเปลี่ยนวิธีจ่ายปันผล (u_tabpg_mem_detail_chg_recieve_dividend)
    //    sc_mem_edit_recieve_dividend + ชื่อวิธีจาก sc_com_m_ucf_money_type (subquery)
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<ChgRecieveDividendDto>> GetChgRecieveDividendAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<ChgRecieveDividendDto>(@"
            select operate_date,
                   pre_method_recieve_dividend,
                   (select sc_com_m_ucf_money_type.money_type_name from sc_com_m_ucf_money_type
                     where sc_com_m_ucf_money_type.money_type_id = sc_mem_edit_recieve_dividend.pre_method_recieve_dividend) as pre_method_recieve_dividend_name,
                   method_recieve_dividend,
                   (select sc_com_m_ucf_money_type.money_type_name from sc_com_m_ucf_money_type
                     where sc_com_m_ucf_money_type.money_type_id = sc_mem_edit_recieve_dividend.method_recieve_dividend) as method_recieve_dividend_name,
                   entry_id
            from sc_mem_edit_recieve_dividend
            where membership_no = {0}
            order by entry_date", membershipNo);
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G8: สัญญาเงินกู้ E-Document (u_tabpg_edc_loancontract) — sc_edoc_loan_contract
    //    ประเภทเอกสาร desc จาก sc_edoc_m_ucf_loan_contract (LEFT JOIN — เลียน combo bind)
    //    filename='DELETED' → row แดง ; count เอกสาร (DOC_TYPE) — จัดที่ frontend
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<EdocLoanContractDto>> GetEdocLoanContractAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<EdocLoanContractDto>(@"
            SELECT m.loan_contract_no, m.doc_type,
                   u.loan_con_doc_desc AS doc_type_name,
                   m.remark, m.entry_date, m.entry_id, m.page_no, m.filename
            FROM sc_edoc_loan_contract m
            LEFT JOIN sc_edoc_m_ucf_loan_contract u ON u.loan_con_doc_type = m.doc_type
            WHERE m.membership_no = {0}
            ORDER BY m.doc_type, m.page_no", membershipNo);
    }

    // popup เปิดเอกสารสัญญาเงินกู้ (legacy popPDF.popEdocument, case "u_tabpg_edc_loancontract"):
    //   table=sc_edoc_loan_contract, folder field=LOAN_CONTRACT_FOLDER, doc_no=LOAN_CONTRACT_NO
    public Task<EdocPdfResult> GetEdocLoanContractPdfAsync(string loanContractNo, string docType, decimal pageNo)
        => GetEdocPdfAsync(loanContractNo, docType, pageNo,
                           table: "sc_edoc_loan_contract",
                           folderField: "loan_contract_folder",
                           docNoField: "loan_contract_no");

    // ── E-Document PDF resolver กลาง (generalize จาก GetEdocMemPdfAsync) ──
    //   docNoField = คีย์เอกสารของแต่ละ table (application_form_no / loan_contract_no ...)
    //   folderField = คอลัมน์ folder ใน sc_edoc_constant (member_new_folder / loan_contract_folder ...)
    private async Task<EdocPdfResult> GetEdocPdfAsync(
        string docNo, string docType, decimal pageNo,
        string table, string folderField, string docNoField)
    {
        await using var scDb = dbFactory.create();

        var row = await scDb.getOneAsync<EdocPdfResolveRow>($@"
            SELECT filename, entry_id, entry_date
            FROM {table}
            WHERE {docNoField} = {{0}} AND doc_type = {{1}} AND page_no = {{2}}",
            docNo, docType, pageNo);

        var filename = row?.Filename;
        if (string.IsNullOrWhiteSpace(filename))
            return new EdocPdfResult();

        if (filename == "DELETED")
            return new EdocPdfResult
            {
                IsDeleted = true,
                DeletedMessage = $"ข้อมูลถูกลบไปแล้วโดย [ {row!.EntryId} ] เวลา : {sc.value.toStringTH(row.EntryDate, true)}"
            };

        var path = (await scDb.getValueAsync($@"
            SELECT file_ini_address || {folderField}
            FROM sc_edoc_constant WHERE seq_no = 1 AND use_pdf = '1'"))?.ToString() ?? "";
        path = path.Replace("\\", "//");

        var url = sc.app.getAppSettings("UrlServerEdocument") + path + "//" + filename + "?page=hsn#toolbar=0";
        return new EdocPdfResult { Url = url };
    }

    private sealed class EdocPdfResolveRow
    {
        public string? Filename { get; set; }
        public string? EntryId { get; set; }
        public DateTime? EntryDate { get; set; }
    }

    // ════════════════════════════════════════════════════════════════════════
    //  G4: เรียกเก็บรายเดือน (u_tabpg_mem_detail_month_detail) — SC_KEP_T_MONTHLY_RECEIVE
    //    3 datasource: dsYearDetail (ปี พ.ศ.) / dsReceiptNo (header) / dsDetMonthDetail (grid)
    //    receive_year เก็บ ค.ศ. → display +543 (พ.ศ.), query -543
    //    header keeping_amount = pkb_labour.fp_get_keeping_amount(...,'NET') — migrate แล้ว
    // ════════════════════════════════════════════════════════════════════════
    public async Task<List<int>> GetMonthDetailYearsAsync(string membershipNo)
    {
        await using var scDb = dbFactory.create();
        return await scDb.getListAsync<int>(@"
            SELECT DISTINCT sc_kep_t_monthly_receive.receive_year + 543 AS receive_year
            FROM sc_kep_t_monthly_receive
            WHERE sc_kep_t_monthly_receive.membership_no = {0}
            ORDER BY receive_year DESC", membershipNo);
    }

    public async Task<int?> GetMonthDetailLatestMonthAsync(string membershipNo, int receiveYear)
    {
        await using var scDb = dbFactory.create();
        var yearCE = receiveYear - 543;
        var v = await scDb.getValueAsync(@"
            SELECT max(receive_month) FROM sc_kep_t_monthly_receive
            WHERE membership_no = {0} AND receive_year = {1}", membershipNo, yearCE);
        var m = sc.value.toInteger(v);
        return m > 0 ? m : null;
    }

    public async Task<MonthDetailHeadDto?> GetMonthDetailHeadAsync(string membershipNo, int receiveYear, int receiveMonth)
    {
        await using var scDb = dbFactory.create();
        var yearCE = receiveYear - 543;
        // dsReceiptNo — ถ้ามีหลาย seq/เดือน เอา seq ล่าสุด (legacy bind row แรก; PG deterministic ด้วย ORDER BY)
        return await scDb.getOneAsync<MonthDetailHeadDto>(@"
            SELECT r.kep_limit,
                   (r.kep_amount - r.kep_limit) AS kep_compute,
                   r.receipt_no,
                   r.receipt_date,
                   pkb_labour.fp_get_keeping_amount(r.membership_no, r.receive_year, r.receive_month, r.seq_no, 'NET') AS keeping_amount,
                   r.amount_form_file,
                   (r.kep_method_amount - r.amount_form_file) AS amount_form,
                   r.kep_method_amount,
                   r.amount_form_dep,
                   r.total_keep_notinput,
                   r.receipt_status,
                   r.receipt_effectdate,
                   COALESCE((select member_group_no||' - '||member_group_name from sc_mem_m_ucf_member_group g
                             where g.member_group_no = r.member_group_no), r.member_group_no) AS member_group_no,
                   r.ppm_date,
                   (select g.salary_group from sc_mem_m_ucf_member_group g, sc_mem_m_membership_registered m
                     where g.member_group_no = m.member_group_no
                       and m.membership_no = r.membership_no) AS salary_group,
                   COALESCE((select member_group_keeping||' - '||member_group_name from sc_fin_ucf_keeping_group kg
                             where kg.member_group_keeping = r.agent_no), r.agent_no) AS agent_no
            FROM sc_kep_t_monthly_receive r
            WHERE r.membership_no = {0} AND r.receive_month = {1} AND r.receive_year = {2}
            ORDER BY r.seq_no DESC", membershipNo, receiveMonth, yearCE);
    }

    public async Task<List<MonthDetailRowDto>> GetMonthDetailRowsAsync(string membershipNo, int receiveYear, int receiveMonth)
    {
        await using var scDb = dbFactory.create();
        var yearCE = receiveYear - 543;
        return await scDb.getListAsync<MonthDetailRowDto>(@"
            SELECT d.keeping_type_code,
                   (SELECT keeping_type_name FROM sc_kep_m_ucf_keeping_item_type k2
                     WHERE k2.keeping_type_code = d.keeping_type_code)
                     || CASE WHEN r.membership_no = d.membership_ownitem THEN ' '
                             ELSE ' ('||d.membership_ownitem||')' END AS keeping_type_desc,
                   d.receive_description,
                   d.period,
                   d.principal_of_loan,
                   d.interest,
                   CASE (SELECT k.sing_flag FROM sc_kep_m_ucf_keeping_item_type k WHERE k.keeping_type_code = d.keeping_type_code)
                        WHEN '-1' THEN -d.money_amount
                        ELSE d.money_amount END AS c_money_amount,
                   d.principal_not,
                   d.interest_not,
                   CASE (SELECT k.sing_flag FROM sc_kep_m_ucf_keeping_item_type k WHERE k.keeping_type_code = d.keeping_type_code)
                        WHEN '-1' THEN -d.money_amount
                        ELSE d.money_amount_not END AS c_money_amount_not,
                   d.unkeep_principal_of_loan,
                   d.unkeep_interest,
                   d.unkeep_money_amount,
                   d.return_principal,
                   d.return_interest,
                   d.money_return,
                   d.ukpaid_after_p,
                   d.ukpaid_after_i,
                   d.ukpaid_after_a,
                   CASE WHEN r.posted_run = '0' THEN d.principal_balance_of_loan
                        ELSE (CASE (SELECT k.keeping_type_group FROM sc_kep_m_ucf_keeping_item_type k WHERE k.keeping_type_code = d.keeping_type_code)
                                   WHEN 'LON' THEN d.mpost_principal_balance + d.unkeep_principal_of_loan
                                   ELSE d.mpost_principal_balance - d.unkeep_money_amount END)
                   END AS c_amount,
                   d.mpost_principal_of_loan,
                   d.mpost_interest,
                   d.mpost_money_amount,
                   d.mproc_principal_arr,
                   d.intarr_pay
            FROM sc_kep_t_monthly_receive_det d, sc_kep_t_monthly_receive r
            WHERE r.membership_no = d.membership_no
              AND r.receive_year = d.receive_year
              AND r.receive_month = d.receive_month
              AND r.seq_no = d.seq_no
              AND r.receive_year = {0}
              AND r.receive_month = {1}
              AND d.membership_no = {2}
            ORDER BY d.receive_seq", yearCE, receiveMonth, membershipNo);
    }
}
