namespace sc
{
    /// <summary>Generic code+name pair — return type ของ sc.db.getComboAsync</summary>
    public record ComboItem(string Code, string Name);

    public class combo
    {
        public const string _ITEM_CODE = "ITEM_CODE";
        public const string _ITEM_DESC = "ITEM_DESC";

        public static string getQuery(string comboName)
        {
            try
            {
                return (typeof(combo).GetField(comboName)!.GetValue(null) ?? string.Empty).ToString()!;
            }
            catch { return string.Empty; }
        }

        // ─── Month / static lists ─────────────────────────────────────────────────

        public const string monthThShot = "1=ม.ค./2=ก.พ./3=มี.ค./4=เม.ย./5=พ.ค./6=มิ.ย./7=ก.ค./8=ส.ค./9=ก.ย./10=ต.ค./11=พ.ย./12=ธ.ค.";
        public const string monthThLong = "1=มกราคม/2=กุมภาพันธ์/3=มีนาคม/4=เมษายน/5=พฤษภาคม/6=มิถุนายน/7=กรกฎาคม/8=สิงหาคม/9=กันยายน/10=ตุลาคม/11=พฤศจิกายน/12=ธันวาคม";
        public const string monthThLong2 = "1=01-มกราคม/2=02-กุมภาพันธ์/3=03-มีนาคม/4=04-เมษายน/5=05-พฤษภาคม/6=06-มิถุนายน/7=07-กรกฎาคม/8=08-สิงหาคม/9=09-กันยายน/10=10-ตุลาคม/11=11-พฤศจิกายน/12=12-ธันวาคม";
        public const string monthEnShot = "1=Jan/2=Feb/3=Mar/4=Apr/5=May/6=Jun/7=Jul/8=Aug/9=Sep/10=Oct/11=Nov/12=Dec";
        public const string monthEnLong = "1=January/2=February/3=March/4=April/5=May/6=June/7=July/8=August/9=September/10=October/11=November/12=December";
        public const string sc_cnt_m_month = "select month_no as item_code ,month_name_thai as item_desc from sc_cnt_m_month order by month_no";

        // ─── Status constants (key=value pairs) ───────────────────────────────────

        public const string sex = "M=ชาย/F=หญิง";
        public const string approve_status = "2=รออนุมัติ/1=อนุมัติแล้ว/0=ไม่อนุมัติ";
        // approve_status + ยกเลิก (cancel_status='1' map เป็น 3) — ใช้กับ filter ค้นหาใบสมัคร (popOpen)
        public const string application_form_status = "2=รออนุมัติ/1=อนุมัติแล้ว/0=ไม่อนุมัติ/3=ยกเลิก";
        public const string atm_edit_type = "0=ไม่แก้ไข/1=แก้ไขเลขที่บัญชี/2=แก้ไขวงเงินกู้";
        public const string cancel_status = "0=ปกติ/1=ยกเลิก";
        public const string fund_close_status = "0=ปกติ/C=ปิดแล้ว/1=ปิดสัญญา";
        public const string coll_status = "0=ค้ำอยู่/1=หลุดค้ำ";
        public const string contract_status = "0=ปกติ/1=พ้นสภาพ";
        public const string decrease_status = "0=ได้ลดหย่อน/1=ไม่ได้ลดหย่อน";
        public const string deposit_close_status = "0=ปกติ/C=ปิดบัญชี";
        public const string loan_drop_status = "0=ส่งปกติ/1=งดทั้งหมด/2=งดต้น/3=งดดอก";
        public const string loan_drop_status2 = "0=-/1=งดทั้งหมด/2=งดต้น/3=งดดอก/4=ส่งปกติ";
        public const string share_drop_status = "0=-/1=งดส่ง/2=ส่งปกติ";
        public const string employee_status = "0=ไม่มีสัญญาจ้าง/1=มีสัญญาจ้าง";
        public const string emer_contact_status = "0=ปกติ/1=พ้นสภาพ";
        public const string interest_calmethod = "01=คิดจากยอดคงเหลือ/02=คิดจากยอดชำระ";
        public const string keep_from_deposit = "0=ไม่เก็บ/1=เก็บจากเงินฝาก";
        public const string keep_receipt_status = "0=ปกติ/2=คืนใบเสร็จ/R=คืนใบเสร็จ*";
        public const string keep_return_status = "0=ยังไม่ชำระ/1=ชำระแล้ว/2=ชำระบางส่วน";
        public const string keeping_status = "0=ไม่ได้ประมวลผล/1=ประมวลผลแล้ว";
        public const string keeping_type = "0=จำนวนเงิน/1=เปอร์เซนต์";
        public const string loan_payment_type = "01=คงต้น/02=คงยอด";
        public const string member_status_code = "0=เป็นสมาชิก/3=พ้นสภาพ";
        public const string send_status = "0=ยังไม่ส่ง/1=ส่งแล้ว";
        public const string receiver_type = "01=บุตร/02=สมาชิก";
        public const string retire_status = "0=-/1=เกษียณแล้ว";
        public const string secure_status = "A=Active/D=Disable/E=Enable/I=Invisible";
        public const string loan_status = "0=ปกติ/1=ห้ามกู้/2=เตือน";
        public const string coll_loan_status = "0=ปกติ/1=ห้ามค้ำ/2=เตือน";
        public const string rec_rep_status = "2=รอจ่าย/1=จ่ายแล้ว/0=ไม่จ่าย";
        public const string create_loan_status = "2=รอตั้งหนี้/1=ตั้งหนี้แล้ว/0=ไม่ตั้งหนี้";
        public const string mem_type_control = "01=สมาชิกสามัญ/02=สมาชิกสมทบ";
        public const string receipt_status = "0=ปกติ/2=คืนใบเสร็จ";
        public const string warranty_status = "0=ไม่มีประกัน/1=อยู่ในประกัน/2=หมดประกัน";
        public const string cut_paid_status = "0=ปกติ/1=ตัดเป็นค่าใช้จ่าย/2=ขายทอดตลาด/3=ชำรุด/4=บริจาค";
        public const string incude_status = "01=ใช้ค้ำสัญญาเดียว/02=ค้ำประกันร่วม(หลัก)/03=ค้ำประกันร่วม(ย่อย)";
        public const string owner_co = "0=คนเดียว/1=เจ้าของร่วม/2=อื่นๆ";
        public const string structure_loof = "W=ไม้/I=เหล็ก";
        public const string floor_float = "0=ไม่มี/1=มี";
        public const string floor_float2 = "0=ชั้นปกติ/1=ชั้นลอย";
        public const string floor_desc = "คอนกรีต=คอนกรีต/ไม้=ไม้";
        public const string type_of_meet = "S=นัดสำรวจหลักทรัพย์/J=นัดจำนอง";
        public const string used_car = "0=ไม่ใช้/1=ใช้";
        public const string keep_car_fee_status = "0=ยัง/1=เก็บแล้ว";
        public const string paid_status = "0=ปกติ/1=ค้างชำระ/2=รอเรียกเก็บ";
        public const string type_of_jumnum = "1=โอนกรรมสิทธิ/2=รับโอนกรรมสิทธิ/3=ขายคืนพันธบัตร/4=รับจำนวนสิทธิ์ในพันธบัตร";
        public const string near_road_status = "0=ไม่ใกล้/1=ใกล้";
        public const string unit_distance = "M=M/KM=KM";
        public const string right_use_road = "ทางสาธารณะประโยชน์=ทางสาธารณะประโยชน์/ถนนส่วนบุคคล=ถนนส่วนบุคคล/อื่นๆ=อื่นๆ";
        public const string group_estimate = "L=ที่ดิน/B=สิ่งปลูกสร้าง/O=อื่นๆ/T=พันธบัตร";
        public const string int_or_principal_status = "0=เปอร์เซ็นต์/1=จำนวนเงิน";
        public const string sc_cls_confirm_data_month = @"sc_cls_confirm_data_01=มกราคม/sc_cls_confirm_data_02=กุมภาพันธ์/sc_cls_confirm_data_03=มีนาคม/
                                                  sc_cls_confirm_data_04=เมษายน/sc_cls_confirm_data_05=พฤษภาคม/sc_cls_confirm_data_06=มิถุนายน/
                                                  sc_cls_confirm_data_07=กรกฎาคม/sc_cls_confirm_data_08=สิงหาคม/sc_cls_confirm_data_09=กันยายน/
                                                  sc_cls_confirm_data_10=ตุลาคม/sc_cls_confirm_data_11=พฤศจิกายน/sc_cls_confirm_data_12=ธันวาคม";

        // ─── Committee ────────────────────────────────────────────────────────────

        public const string sc_cnt_m_committee_list  = "#sc_cnt_m_committee_list|seq_no|cmt_fullname";
        public const string sc_cnt_m_committee_list2 = "#sc_cnt_m_committee_list|seq_no|cmt_fullname|2";
        public const string sc_cnt_m_committee_list3 = @"select sc_cnt_m_committee_list.cmt_fullname as item_code
,sc_cnt_m_committee_list.cmt_fullname as item_desc
from sc_cnt_m_committee_list
where sc_cnt_m_committee_list.cmt_group = '11'
order by sc_cnt_m_committee_list.seq_no";
        public const string sc_cnt_m_ucf_committee_group = "#sc_cnt_m_ucf_committee_group|cmt_group|cmt_group_des|2";

        // ─── Finance / Bank ───────────────────────────────────────────────────────

        public const string sc_bank_reconsign_remark  = @"select seq_no as item_code,item_remark as item_desc from sc_fin_ucf_bank_pay_remark order by sort_order";
        public const string sc_bank_reconsign_remark2 = @"select seq_no as item_code,seq_no||' - '||item_remark as item_desc from sc_fin_ucf_bank_pay_remark order by sort_order";
        public const string sc_fin_m_bank  = "#sc_fin_m_bank|bank_fin|bank_name|1|close_status='0'";
        public const string sc_fin_m_bank2 = "#sc_fin_m_bank|bank_fin|bank_name|2|close_status='0'";
        public const string sc_fin_m_bank3 = @"select bank_fin as item_code,bank_fin||' - '||bank_name as item_desc
from sc_fin_m_bank
where close_status = '0'
and account_type = '01'";
        public const string sc_fin_m_bank4 = @"select bank_fin as item_code,bank_fin||' - '||bank_name as item_desc
from sc_fin_m_bank
where close_status = '0'
and billpayment_status = '1'";
        public const string sc_fin_m_bank5 = @"select bank_fin as item_code,bank_fin||' - '||bank_name as item_desc
from sc_fin_m_bank
where spp_able = '1'
order by sort_order";
        public const string sc_fin_ucf_company  = "#sc_fin_ucf_company|company_id|company_name";
        public const string sc_fin_ucf_company2 = "#sc_fin_ucf_company|company_id|company_name|2";
        public const string sc_fin_ucf_company_type02 = @"select company_id as item_code,company_id||' - '||company_name as item_desc
from sc_fin_ucf_company
where company_type = '02'";
        public const string sc_fin_ucf_cheque_desc2 = @"select desc_type as item_code,
desc_type||' - '||desc_name as item_desc
from sc_fin_ucf_cheque_desc
where active_status = '1'
order by sort_order";
        public const string sc_fin_ucf_vourcher_group      = "#sc_fin_ucf_vourcher_group|vourcher_group|vourcher_desc|1|";
        public const string sc_fin_ucf_vourcher_group2     = "#sc_fin_ucf_vourcher_group|vourcher_group|vourcher_desc|2|";
        public const string sc_fin_ucf_vourcher_group_rec  = "#sc_fin_ucf_vourcher_group|vourcher_group|vourcher_desc|2|sign_flag=1";
        public const string sc_fin_ucf_vourcher_group_paid = "#sc_fin_ucf_vourcher_group|vourcher_group|vourcher_desc|2|sign_flag=-1";
        public const string sc_fin_ucf_vourcher_group3 = @"select vourcher_group as item_code,
vourcher_group||' - '||vourcher_desc as item_desc
from sc_fin_ucf_vourcher_group
where vourcher_group like 'R%' or vourcher_group like 'P%'";
        public const string sc_fin_ucf_item_type  = "#sc_fin_ucf_item_type|item_type|item_description";
        public const string sc_fin_ucf_item_type2 = "#sc_fin_ucf_item_type|item_type|item_description|2";
        public const string sc_fin_ucf_draft_vourcher = "#sc_fin_ucf_draft_vourcher|draft_code|draft_desc";
        public const string sc_fin_ucf_cheque_used  = "#sc_fin_ucf_cheque_used|used_code|used_desc";
        public const string sc_fin_ucf_cheque_used2 = "#sc_fin_ucf_cheque_used|used_code|used_desc|2";
        public const string sc_fin_ucf_cheque_status  = "#sc_fin_ucf_cheque_status|cheque_status|description";
        public const string sc_fin_ucf_cheque_status2 = "#sc_fin_ucf_cheque_status|cheque_status|description|2";
        public const string sc_fin_ucf_keeping_group = @"select sc_fin_ucf_keeping_group.member_group_keeping as item_code
,sc_fin_ucf_keeping_group.member_group_name as item_desc
from sc_fin_ucf_keeping_group
order by sc_fin_ucf_keeping_group.sort_order,sc_fin_ucf_keeping_group.member_group_keeping";
        public const string sc_fin_ucf_keeping_group2 = @"select sc_fin_ucf_keeping_group.member_group_keeping as item_code
,sc_fin_ucf_keeping_group.member_group_keeping||' - '||sc_fin_ucf_keeping_group.member_group_name as item_desc
from sc_fin_ucf_keeping_group
order by sc_fin_ucf_keeping_group.sort_order,sc_fin_ucf_keeping_group.member_group_keeping";
        public const string sc_fin_ucf_give_group_id = "#sc_fin_ucf_give_group|give_group|give_group";
        public const string sc_fin_ucf_give_group    = "#sc_fin_ucf_give_group|give_group|give_name";
        public const string sc_fin_ucf_give_group2   = "#sc_fin_ucf_give_group|give_group|give_name|2";
        public const string sc_fin_ucf_give_report   = "#sc_fin_ucf_give_report|give_rep|give_rep_desc";
        public const string sc_fin_ucf_give_report2  = "#sc_fin_ucf_give_report|give_rep|give_rep_desc|2";
        public const string sc_fin_ucf_gero_group    = "#sc_fin_ucf_gero_group|member_group_gr|member_group_gr_name";

        // CHANGED: FROM DUAL → removed; ORDER BY DECODE → CASE WHEN
        public const string sc_fin_ucf_money_retrun = @"select * from (
 select 'AAA' as item_code, 'เงินรอจ่ายคืนทั่วไป' as item_desc from sc_fin_m_constant
    union all
    select return_method as item_code, return_desc as item_desc
    from sc_fin_ucf_money_retrun
    where active_status = '1'
    and exists(
        select null from sc_acc_m_account_master
        where account_id = sc_fin_ucf_money_retrun.account_id
        and account_type_id = '3'
    )
) tm
order by CASE WHEN tm.item_code='AAA' THEN 0 ELSE 1 END, tm.item_desc";
        public const string sc_fin_ucf_money_retrun2 = "#sc_fin_ucf_money_retrun|return_method|return_desc|2";
        public const string sc_fin_ucf_money_retrun3 = "#sc_fin_ucf_money_retrun|return_method|return_desc|2";
        public const string sc_fin_ucf_money_retrun_public_capital = @"select return_method as item_code,
return_desc as item_desc
from sc_fin_ucf_money_retrun
where public_capital = '1'
order by return_method";
        public const string sc_fund_ucf_return_method = "#sc_fund_ucf_return_method|return_method|item_desc";
        public const string sc_fund_ucf_item_type     = "#sc_fund_ucf_item_type|item_type|description";

        // ─── Account ──────────────────────────────────────────────────────────────

        public const string sc_acc_m_ucf_asset    = "#sc_acc_m_ucf_asset|asset_group|asset_des";
        public const string sc_acc_m_ucf_asset2   = "#sc_acc_m_ucf_asset|asset_group|asset_des|2";
        public const string sc_acc_m_ucf_asset_old  = "#sc_acc_m_ucf_asset_old|asset_old_group|asset_des";
        public const string sc_acc_m_ucf_asset_old2 = "#sc_acc_m_ucf_asset_old|asset_old_group|asset_des|2";
        public const string sc_acc_m_ucf_balsheet_group  = "#sc_acc_m_ucf_balsheet_group|balsheet_group|balsheet_name";
        public const string sc_acc_m_ucf_balsheet_group2 = "#sc_acc_m_ucf_balsheet_group|balsheet_group|balsheet_name|2";
        public const string sc_acc_m_ucf_bank  = @"select bank_id as item_code,bank_name as item_desc from sc_acc_m_ucf_bank where contract_bank_status = '1' order by bank_id";
        public const string sc_acc_m_ucf_bank2 = @"select bank_id as item_code,bank_id||' - '||bank_name as item_desc from sc_acc_m_ucf_bank where contract_bank_status = '1' order by bank_id";
        public const string sc_acc_m_ucf_bank3 = @"select bank_id as item_code,short_name as item_desc from sc_acc_m_ucf_bank where contract_bank_status = '1' order by bank_id";
        public const string sc_acc_m_ucf_bank4 = @"select bank_id as item_code,short_name as item_desc from sc_acc_m_ucf_bank where contract_bank_status = '1' order by sort_order";
        public const string sc_acc_m_ucf_bank_branch  = "#sc_acc_m_ucf_bank_branch|bank_branch_id|bank_name|1|bank_id={0}";
        public const string sc_acc_m_ucf_bank_branch2 = "#sc_acc_m_ucf_bank_branch|bank_branch_id|bank_name|2|bank_id={0}";
        public const string sc_acc_m_ucf_bank_branch3 = "#sc_acc_m_ucf_bank_branch|bank_branch_id|bank_name";
        public const string sc_acc_m_ucf_bank_lrq   = @"select bank_name as item_code,bank_name as item_desc from sc_acc_m_ucf_bank order by sort_order";
        public const string sc_acc_m_ucf_bank_short = @"select bank_id as item_code,short_name as item_desc from sc_acc_m_ucf_bank where contract_bank_status = '1' order by bank_id";
        public const string sc_acc_m_ucf_bank_atm   = @"#sc_acc_m_ucf_bank|bank_id|bank_name|1|atm_status='1'";
        public const string sc_acc_m_ucf_bank_atm2  = @"#sc_acc_m_ucf_bank|bank_id|bank_name|2|atm_status='1'";
        public const string sc_acc_m_ucf_bank_mobile = @"SELECT sc_acc_m_ucf_bank.bank_id as item_code
,  sc_acc_m_ucf_bank.bank_name as item_desc
FROM sc_fin_m_bank,
sc_acc_m_ucf_bank
WHERE ( sc_fin_m_bank.bank_id = sc_acc_m_ucf_bank.bank_id
and  sc_fin_m_bank.close_status = '0'
and sc_fin_m_bank.mobile_status = '1' )
union all
SELECT  sc_acc_m_ucf_bank.bank_id
,  sc_acc_m_ucf_bank.bank_name
FROM    sc_acc_m_ucf_bank
WHERE  sc_acc_m_ucf_bank.bank_id = '000'";
        public const string sc_acc_m_account_master  = @"select account_id as item_code,account_name as item_desc from sc_acc_m_account_master where cancel_status = '0'";
        public const string sc_acc_m_account_master2 = @"select account_id as item_code,account_id||' - '||account_name as item_desc from sc_acc_m_account_master where cancel_status = '0'";
        public const string sc_acc_m_account_master3 = @"select account_id as item_code,account_id||' - '||account_name as item_desc from sc_acc_m_account_master where cancel_status = '0' and account_type_id='3' order by account_id";
        public const string sc_acc_m_account_master3_sort = @"select account_id as item_code,account_id||' - '||account_name as item_desc from sc_acc_m_account_master where cancel_status = '0' and account_type_id='3' order by account_id";
        // CHANGED: removed FROM DUAL; use VALUES for static row
        public const string sc_acc_m_account_master4 = @"select * from(
          select '00' as item_code, 'ไม่ระบุ' as item_desc
         union
          select account_id as item_code, account_id || ' - ' || account_name as item_desc from sc_acc_m_account_master where cancel_status = '0' and account_type_id = '3'
        )
        order by item_code";
        public const string sc_acc_m_ucf_expire_cut   = "#sc_acc_m_ucf_expire_cut|cut_paid_status|description";
        public const string sc_acc_m_ucf_expire_cut2  = "#sc_acc_m_ucf_expire_cut|cut_paid_status|description|2";
        public const string sc_acc_m_ucf_type_exp     = "#sc_acc_m_ucf_type_exp|type_exp|type_name";
        public const string sc_acc_m_ucf_shelf_exp    = "#sc_acc_m_ucf_shelf_exp|shelf_id|shelf_name";
        public const string sc_acc_m_ucf_asset_2565   = "#sc_acc_m_ucf_asset_2565|asset_group|asset_des|2";
        public const string sc_acc_m_account_group_krom2 = "#sc_acc_m_account_group_krom|group_krom|group_krom_desc|2";

        // ─── Common / Branch ──────────────────────────────────────────────────────

        public const string sc_com_m_branch  = "#sc_com_m_branch|branch_id|branch_name";
        public const string sc_com_m_branch2 = "#sc_com_m_branch|branch_id|branch_name|2";
        public const string sc_com_m_ucf_money_type  = "#sc_com_m_ucf_money_type|money_type_id|money_type_name";
        public const string sc_com_m_ucf_money_type2 = "#sc_com_m_ucf_money_type|money_type_id|money_type_name|2";
        public const string sc_com_m_ucf_money_type3 = @"select money_type_id as item_code
,money_type_id||' - '||money_type_name as item_desc
from sc_com_m_ucf_money_type
where money_return_able = '1'
order by sort_order";
        public const string sc_com_m_ucf_money_type4 = @"select money_type_id as item_code
,money_type_id||' - '||money_type_name as item_desc
from sc_com_m_ucf_money_type
where spp_able = '1'
order by sort_order";
        public const string sc_com_m_ucf_money_type_pay = @"select money_type_id as item_code,
money_type_id||' - '||money_type_name as item_desc
from sc_com_m_ucf_money_type
where payment_status = '1'
order by sort_order";
        public const string sc_com_m_ucf_money_type_dividen = "#sc_com_m_ucf_money_type|money_type_id|money_type_name|1|dividen_status=1";
        public const string sc_com_m_ucf_money_type_method_div = @"select money_type_id as item_code,
money_type_id||' - '||money_type_name as item_desc
from sc_com_m_ucf_money_type
where payment_status = '1'
and   dividen_status='1'
order by sort_order";
        public const string sc_com_m_ucf_money_type_dividen2     = "select money_type_id as item_code,money_type_id||' - '||money_type_name as item_desc from sc_com_m_ucf_money_type where dividen_status=1 order by sort_order, money_type_id";
        public const string sc_com_m_ucf_money_type_dividen_fix2 = "select money_type_id as item_code,money_type_id||' - '||money_type_name as item_desc from sc_com_m_ucf_money_type where dividen_status=1 and money_type_id in ('CSH','CHQ','TRB','TRD','STB') order by sort_order";
        public const string sc_com_m_ucf_money_type_share_withdraw_able = "#sc_com_m_ucf_money_type|money_type_id|money_type_name|2|share_withdraw_able=1";
        public const string sc_com_m_ucf_receipt_item_type = "#sc_com_m_ucf_receipt_item_type|item_type_id|item_type_name";
        public const string sc_com_m_ucf_money_type_sccoor = @"select money_type_id as item_code,
money_type_id||' - '||money_type_name as item_desc
from sc_com_m_ucf_money_type
where crem_status = '1'
order by sort_order";
        public const string sc_com_m_ucf_money_type_welfare = "#sc_com_m_ucf_money_type|money_type_id|money_type_name|2|welfare_active=1";
        public const string sc_com_m_ucf_money_type_new = "table=sc_com_m_ucf_money_type|key=money_type_id|value=money_type_name";
        public const string sc_com_m_file_sys_config_new = "table=sc_com_m_file_sys_config|key=file_sys|value=file_desc";
        public const string sc_com_m_file_sys_config_new2 = @"select file_sys as item_code, file_sys||' - '||file_desc as item_desc
from sc_com_m_file_sys_config
where 1=1
and active_status = '1'
order by sort_order";

        // ─── Deposit ──────────────────────────────────────────────────────────────

        public const string sc_dep_m_rule  = "#sc_dep_m_rule|deposit_type_code|deposit_name";
        public const string sc_dep_m_rule2 = "#sc_dep_m_rule|deposit_type_code|deposit_name|2";
        public const string sc_dep_m_ucf_dep_item_type  = "#sc_dep_m_ucf_dep_item_type|deposit_item_type|deposit_item_description";
        public const string sc_dep_m_ucf_dep_item_type2 = "#sc_dep_m_ucf_dep_item_type|deposit_item_type|deposit_item_description|2";
        public const string sc_dep_ucf_book_remark        = "select item_remark as item_code,item_remark as item_desc from sc_dep_ucf_book_remark order by sort_order";
        public const string sc_dep_ucf_book_remark_seq_no = "select seq_no as item_code,item_remark as item_desc from sc_dep_ucf_book_remark order by sort_order";

        // ─── Document ─────────────────────────────────────────────────────────────

        public const string sc_doc_ucf_regis_type  = "#sc_doc_ucf_regis_type|regis_type|regis_type_des";
        public const string sc_doc_ucf_regis_type2 = "#sc_doc_ucf_regis_type|regis_type|regis_type_des|2";

        // ─── Loan ─────────────────────────────────────────────────────────────────

        public const string sc_lon_m_rule  = "#sc_lon_m_rule|loan_type|loan_type_description";
        public const string sc_lon_m_rule2 = "#sc_lon_m_rule|loan_type|loan_type_description|2";
        public const string sc_lon_m_rule3 = @"select loan_type as item_code, loan_type||' - '||loan_type_description as item_desc from sc_lon_m_rule order by loan_type";
        public const string sc_lon_m_rule_user_current = @"select loan_type as item_code,
    loan_type||' - '||loan_type_description as item_desc
from sc_lon_m_rule
where user_current = '1' order by sort_order";
        public const string sc_lon_m_rule_ref_contract_no = @"SELECT DISTINCT sc_lon_m_rule_b.loan_type as item_code,
     sc_lon_m_rule_b.loan_type_description as item_desc
FROM sc_lon_m_rule sc_lon_m_rule_a,
     sc_lon_m_rule sc_lon_m_rule_b
WHERE ( sc_lon_m_rule_a.ref_contract_no = sc_lon_m_rule_b.loan_type ) and
     ( ( sc_lon_m_rule_a.user_current = '1' ) AND
     ( sc_lon_m_rule_a.invest_status = '0' )
     )
ORDER BY sc_lon_m_rule_b.loan_type ASC";
        public const string sc_lon_m_rule_invest = @"SELECT sc_lon_m_rule.loan_type as item_code,
     sc_lon_m_rule.loan_type_description as item_desc
FROM sc_lon_m_rule
WHERE ( user_current = '1' ) AND ( invest_status = '1' )
ORDER BY loan_type ASC";
        public const string sc_lon_m_ucf_collateral_type  = "#sc_lon_m_ucf_collateral_type|collateral_type_code|collateral_description";
        public const string sc_lon_m_ucf_collateral_type2 = "#sc_lon_m_ucf_collateral_type|collateral_type_code|collateral_description|2";
        public const string sc_lon_m_ucf_collateral_type3 = @"select COLLATERAL_TYPE_CODE as item_code,
    COLLATERAL_TYPE_CODE||'-'||COLLATERAL_DESCRIPTION||' '||ESTIMATE_VALUE*100||'%' as item_desc
from SC_LON_M_UCF_COLLATERAL_TYPE";
        public const string sc_lon_m_ucf_fee       = "#sc_lon_m_ucf_fee|fee_type|fee_name";
        public const string sc_lon_m_ucf_fee2      = @"select fee_type as item_code, fee_type||' - '||fee_name as item_desc from sc_lon_m_ucf_fee";
        public const string sc_lon_m_ucf_fee_active = "#sc_lon_m_ucf_fee|fee_type|fee_name|2|active_status = '1'";
        public const string sc_lon_m_ucf_install_method = "#sc_lon_m_ucf_install_method|item_type|item_desc";
        public const string sc_lon_m_ucf_loan_approver = @"select approver_code as item_code,
    approver_code||' - '||approver_desc as item_desc
from sc_lon_m_ucf_loan_approver
order by approver_code asc";
        public const string sc_lon_m_ucf_loan_card_item  = "#sc_lon_m_ucf_loan_card_item|item_type_code|item_type_description";
        public const string sc_lon_m_ucf_loan_card_item2 = "#sc_lon_m_ucf_loan_card_item|item_type_code|item_type_description|2";
        public const string sc_lon_m_ucf_loan_code  = "#sc_lon_m_ucf_loan_code|loan_code|loan_code_desc";
        public const string sc_lon_m_ucf_loan_code2 = "#sc_lon_m_ucf_loan_code|loan_code|loan_code_desc|2";
        public const string sc_lon_m_ucf_loan_obj   = "#sc_lon_m_ucf_loan_obj|loan_objective_code|loan_objective_description|1|loan_type={0}";
        public const string sc_lon_m_ucf_loan_obj2  = "#sc_lon_m_ucf_loan_obj|loan_objective_code|loan_objective_description|2|loan_type={0}";
        public const string sc_lon_m_ucf_loan_payment_type = "#sc_lon_m_ucf_loan_payment_type|loan_payment_type_code|loan_payment_type_desc";
        public const string sc_lon_m_ucf_loan_document = "#sc_lon_m_ucf_loan_document|document_code|description";
        public const string sc_lon_m_ucf_building   = "#sc_lon_m_ucf_building|building_type|building_desc";
        public const string sc_lon_m_ucf_material   = "#sc_lon_m_ucf_material|material_type|materialg_desc";
        public const string sc_lon_ucf_fee          = "#sc_lon_ucf_fee|fee_type|fee_name";
        public const string sc_lon_m_ucf_req_salnet_type_exp = "#sc_lon_m_ucf_req_salnet_type|item_code|item_code_desc|2|item_salnet_type ='exp'";
        public const string sc_lon_m_ucf_req_salnet_type_inc = "#sc_lon_m_ucf_req_salnet_type|item_code|item_code_desc|2|item_salnet_type ='inc'";
        public const string sc_lon_m_ucf_req_doc    = "#sc_lon_m_ucf_req_doc|doc_code|doc_desc";
        public const string sc_lon_m_ucf_req_doc2   = "#sc_lon_m_ucf_req_doc|doc_code|doc_desc|2";
        public const string sc_lon_property_loof_type     = "#sc_lon_property_loof_type|loof_type|loof_desc";
        public const string sc_lon_property_bulding_type  = "#sc_lon_property_bulding_type|building_type|building_desc";
        public const string sc_lon_property_ground_type   = "#sc_lon_property_ground_type|ground_type|ground_desc";
        public const string sc_lon_property_company       = "#sc_lon_property_company|company_code|company_name";
        public const string sc_lon_property_ucf_inskeep   = "#sc_lon_property_ucf_inskeep|keep_type|keep_desc";
        public const string sc_lon_property_ucf_bond      = "#sc_lon_property_ucf_bond|bond_type|bond_desc";
        public const string sc_lon_property_road_type     = "#sc_lon_property_road_type|road_type|road_desc";
        public const string sc_lon_m_ucf_land             = "#sc_lon_m_ucf_land|land_type|land_desc";
        public const string sc_lon_property_ucf_load      = "#sc_lon_property_ucf_load|load_code|load_desc";
        public const string sc_lon_spec_type_coll         = "#sc_lon_spec_type_coll|mark_status|mark_descrip";
        public const string sc_lon_ucf_redemption         = "#sc_lon_ucf_redemption|redemption_type|redemption_desc";
        public const string sc_lon_ucf_redemption2        = @"select redemption_type as item_code, redemption_desc as item_desc from sc_lon_ucf_redemption order by redemption_type asc";
        public const string sc_lon_m_ucf_drop_payment1    = "#sc_lon_m_ucf_drop_payment|drop_payment_status|drop_payment_desc";
        public const string sc_lon_m_ucf_drop_payment     = @"select drop_payment_status as item_code,
    drop_payment_desc as item_desc
from sc_lon_m_ucf_drop_payment
where 1=1
/*WHERE*/
order by drop_payment_status";
        public const string sc_lon_m_ucf_coll_type     = "#sc_lon_m_ucf_coll_type|coll_type|coll_description|2";
        public const string sc_lon_m_ucf_coll_ref_type = "#sc_lon_m_ucf_coll_ref_type|COLL_REF_TYPE|COLL_REF_DESCRIPTION|2";
        public const string sc_lon_m_ucf_doc_process   = "#sc_lon_m_ucf_doc_process|process_id|process_name|2";
        public const string sc_lon_m_ucf_req_other_loan2 = @"select other_loan_type as item_code, other_loan_type||' - '||loan_desc as item_desc from sc_lon_m_ucf_req_other_loan order by sort_order";
        public const string sc_lon_m_rule_insure = @"select loan_type as item_code, loan_type||' - '||loan_type_description as item_desc from sc_lon_m_rule where insure_status = '1' order by loan_type";
        public const string sc_lon_atm_ucf_item_type = "#sc_lon_atm_ucf_item_type|item_type|item_desc";

        // CHANGED: Oracle date format → PostgreSQL
        public const string memno_lonreqno = @"select loan_requestment_no as item_code,
  loan_requestment_no||'(ขอกู้ '||TO_CHAR(requestment_date,'DD-MM-')||RIGHT(CAST(EXTRACT(YEAR FROM requestment_date) + 543 AS TEXT), 2)||')' as item_desc
from sc_lon_m_loan_request
where membership_no = {0} /*WHERE*/
order by requestment_date desc,loan_requestment_no";

        // ─── Member ───────────────────────────────────────────────────────────────

        public const string sc_mem_m_membership_registered = @"select application_form_no as item_code,
    application_form_no as item_desc
from sc_mem_m_membership_registered
where 1=1
/*WHERE*/
order by application_form_no";
        public const string sc_mem_m_ucf_app_book      = "#sc_mem_m_ucf_app_book|book_code|book_desc";
        public const string sc_mem_m_ucf_app_book_crem = "#sc_mem_m_ucf_app_book_crem|book_code|book_desc";
        public const string sc_mem_m_ucf_application_type  = "#sc_mem_m_ucf_application_type|appl_type_code|appl_type_name|1|appl_type_code <> '0'";
        public const string sc_mem_m_ucf_application_type2 = "#sc_mem_m_ucf_application_type|appl_type_code|appl_type_name|2|appl_type_code <> '0'";
        public const string sc_mem_m_ucf_blood        = "#sc_mem_m_ucf_blood|blood_code|blood_desc";
        public const string sc_mem_m_ucf_cancel_newform = "#sc_mem_m_ucf_cancel_newform|cancel_code|cancel_desc";
        public const string sc_mem_m_ucf_change_payment = "#sc_mem_m_ucf_change_payment|reason_code|description_detail";
        public const string sc_mem_m_ucf_concern = @"select sc_mem_m_ucf_concern.conceern_code as item_code,
    sc_mem_m_ucf_concern.related_na as item_desc
FROM sc_mem_m_ucf_concern
order by sort_order";
        public const string sc_mem_m_ucf_concern2     = "#sc_mem_m_ucf_concern|conceern_code|related_na|2";
        public const string sc_mem_m_ucf_crem_paid    = "#sc_mem_m_ucf_crem_paid|paid_type|paid_name";
        public const string sc_mem_m_ucf_crem_paid2   = "#sc_mem_m_ucf_crem_paid|paid_type|paid_name|2";
        public const string sc_mem_m_ucf_debtor       = "#sc_mem_m_ucf_debtor|debtor_code|debtor_desc";
        public const string sc_mem_m_ucf_debtor2      = @"select debtor_code as item_code, debtor_code||' - '||debtor_desc as item_desc from sc_mem_m_ucf_debtor order by sort_order";
        public const string sc_mem_m_ucf_district     = "#sc_mem_m_ucf_district|district_code|district_name";
        public const string sc_mem_m_ucf_district2    = "#sc_mem_m_ucf_district|district_code|district_name|2";
        public const string sc_mem_m_ucf_doc_place    = "#sc_mem_m_ucf_doc_place|item_code|doc_place";
        public const string sc_mem_m_ucf_edu_level    = @"select edu_code as item_code,edu_name as item_desc from sc_mem_m_ucf_edu_level order by edu_code";
        public const string sc_mem_m_ucf_group_position  = @"select group_position as item_code,description as item_desc from sc_mem_m_ucf_group_position order by sort_order";
        public const string sc_mem_m_ucf_group_position2 = @"select group_position as item_code,group_position||' - '||description as item_desc from sc_mem_m_ucf_group_position order by sort_order";
        public const string sc_mem_m_ucf_marriage_status  = "#sc_mem_m_ucf_marriage_status|marriage_status_code|marriage_status";
        public const string sc_mem_m_ucf_marriage_status2 = @"select sc_mem_m_ucf_marriage_status.marriage_status_code as item_code,
    sc_mem_m_ucf_marriage_status.marriage_status as item_desc
from sc_mem_m_ucf_marriage_status
order by sc_mem_m_ucf_marriage_status.marriage_status_code";
        public const string sc_mem_m_ucf_member_cremation  = "#sc_mem_m_ucf_member_cremation|crem_type|crem_name";
        public const string sc_mem_m_ucf_member_cremation2 = "#sc_mem_m_ucf_member_cremation|crem_type|crem_name|2";
        public const string sc_mem_m_ucf_member_group  = "#sc_mem_m_ucf_member_group|member_group_no|member_group_name";
        public const string sc_mem_m_ucf_member_group2 = "#sc_mem_m_ucf_member_group|member_group_no|member_group_name|2";
        public const string sc_mem_m_ucf_member_group3 = @"select b.member_group_no as item_code, b.member_group_name as item_desc
from sc_mem_m_ucf_member_group a, sc_mem_m_ucf_member_group b
where a.member_group_control = b.member_group_no
/*WHERE*/
group by b.member_group_no ,b.member_group_name
order by b.member_group_no nulls first";
        public const string sc_mem_m_ucf_member_group4 = @"select b.member_group_no as item_code, b.member_group_no||' - '||b.member_group_name as item_desc
from sc_mem_m_ucf_member_group a, sc_mem_m_ucf_member_group b
where a.member_group_control = b.member_group_no
/*WHERE*/
group by b.member_group_no ,b.member_group_name
order by b.member_group_no nulls first";
        public const string sc_mem_m_ucf_member_group5 = @"select b.member_group_no as item_code, b.member_group_name as item_desc
from sc_mem_m_ucf_member_group a, sc_mem_m_ucf_member_group b
where a.member_group_control = b.member_group_no
/*WHERE*/
group by b.member_group_no ,b.member_group_name
order by b.member_group_no nulls first";
        public const string sc_mem_m_ucf_member_group6 = "#sc_mem_m_ucf_member_group|member_group_no|member_group_name|2|group_loan=0";
        // NOTE: pka_com_function.fp_get_group_name is an Oracle package — migrate to PostgreSQL function
        public const string sc_mem_m_ucf_member_group7 = @"select member_group_control as item_code , member_group_control || ' - ' || pka_com_function.fp_get_group_name(sc_mem_m_ucf_member_group.member_group_control) as item_desc
from sc_mem_m_ucf_member_group
where 1=1
/*WHERE*/
group by member_group_control
order by member_group_control";
        public const string sc_mem_m_ucf_member_group_section  = "#sc_mem_m_ucf_member_group_section|group_section|group_section_name";
        public const string sc_mem_m_ucf_member_group_section2 = "#sc_mem_m_ucf_member_group_section|group_section|group_section_name|2";
        public const string sc_mem_m_ucf_member_type  = "#sc_mem_m_ucf_member_type|mem_type_code|mem_type_desc";
        public const string sc_mem_m_ucf_member_type2 = "#sc_mem_m_ucf_member_type|mem_type_code|mem_type_desc|2";
        public const string sc_mem_m_ucf_member_type3 = @"select mem_type_code as item_code,mem_type_code||' - '||mem_type_desc as item_desc from sc_mem_m_ucf_member_type order by mem_type_code";
        public const string sc_mem_m_ucf_nationality  = "#sc_mem_m_ucf_nationality|nationality_code|nationality_description";
        public const string sc_mem_m_ucf_ocupation    = "#sc_mem_m_ucf_ocupation|occupation_code|occupation_description";
        public const string sc_mem_m_ucf_other_code   = @"select mem_type_code as item_code,mem_type_desc as item_desc from sc_mem_m_ucf_other_code order by sort_order";
        public const string sc_mem_m_ucf_other_code2  = @"select mem_type_code as item_code,mem_type_code||' - '||mem_type_desc as item_desc from sc_mem_m_ucf_other_code order by sort_order";
        public const string sc_mem_m_ucf_othersaving  = "#sc_mem_m_ucf_othersaving|other_saving_member|saving_name";
        public const string sc_mem_m_ucf_othersaving2 = @"select other_saving_member as item_code,other_saving_member||' - '||saving_name as item_desc from sc_mem_m_ucf_othersaving order by sort_order";
        public const string sc_mem_m_ucf_position     = @"select position_code as item_code,position_name as item_desc from sc_mem_m_ucf_position order by sort_order";
        public const string sc_mem_m_ucf_position2    = @"select position_code as item_code,position_code||' - '||position_name as item_desc from sc_mem_m_ucf_position order by sort_order";
        public const string sc_mem_m_ucf_position_long = "#sc_mem_m_ucf_position|position_name|position_name";
        public const string sc_mem_m_ucf_prename      = @"select prename_code as item_code, prename as item_desc from sc_mem_m_ucf_prename order by prename_code,prename";
        public const string sc_mem_m_ucf_province     = "#sc_mem_m_ucf_province|province_code|province_name";
        public const string sc_mem_m_ucf_resign_cause  = "#sc_mem_m_ucf_resign_cause|resign_cause_code|resign_cause_name";
        public const string sc_mem_m_ucf_resign_cause2 = "#sc_mem_m_ucf_resign_cause|resign_cause_code|resign_cause_name|2";
        public const string sc_mem_m_ucf_salary_level  = "#sc_mem_m_ucf_salary_level|level_code|level_name";
        public const string sc_mem_m_ucf_salary_level2 = @"select level_code as item_code,level_name as item_desc from sc_mem_m_ucf_salary_level order by item_code";
        public const string sc_mem_m_ucf_salary_rate   = @"select salary_rate_code as item_code,
  (case when salary_rate_code > 0 then 'ขั้น '||rpad(salary_rate_code::text,6,' ')||'['||lpad(to_char(salary_amount,'9,999,999.99'),14,' ')||']' else null end) as item_desc
from sc_mem_m_ucf_salary_rate
where 1 = 1
/*WHERE*/
order by level_code, salary_rate_code";
        public const string sc_mem_m_ucf_share_item_type  = "#sc_mem_m_ucf_share_item_type|item_type|item_type_description";
        public const string sc_mem_m_ucf_share_item_type2 = "#sc_mem_m_ucf_share_item_type|item_type|item_type_description|2";
        public const string sc_mem_m_ucf_shareloan_status  = @"select shareloan_code as item_code,description as item_desc from sc_mem_m_ucf_shareloan_status order by sort_order";
        public const string sc_mem_m_ucf_shareloan_status2 = @"select shareloan_code as item_code,shareloan_code||' - '||description as item_desc from sc_mem_m_ucf_shareloan_status order by sort_order";
        public const string sc_mem_m_ucf_member_status = @"SELECT sc_mem_m_ucf_member_status.member_status_code as item_code,
       sc_mem_m_ucf_member_status.member_status_name as item_desc
FROM sc_mem_m_ucf_member_status
order by sc_mem_m_ucf_member_status.member_status_code";
        public const string sc_mem_m_ucf_expense_type  = "#sc_mem_m_ucf_expense_type|expense_type_code|expense_type_description";
        public const string sc_mem_m_ucf_expense_type2 = "#sc_mem_m_ucf_expense_type|expense_type_code|expense_type_description|2";
        public const string sc_mem_m_ucf_revenue_type  = "#sc_mem_m_ucf_revenue_type|revenue_type_code|revenue_type_description";
        public const string sc_mem_m_ucf_revenue_type2 = "#sc_mem_m_ucf_revenue_type|revenue_type_code|revenue_type_description||2";
        public const string sc_mem_m_ucf_coop_control  = "#sc_mem_m_ucf_coop_control|control_id|control_desc";
        public const string sc_mem_m_ucf_subdistrict   = "#sc_mem_m_ucf_subdistrict|subdistrict_code|subdistrict_name";
        public const string sc_mem_m_ucf_memo           = "#sc_mem_m_ucf_memo|memo_code|memo_desc";
        public const string sc_mem_m_ucf_memo2          = "#sc_mem_m_ucf_memo|memo_code|memo_desc|2";
        public const string sc_mem_m_ucf_groupmajor2    = "#sc_mem_m_ucf_groupmajor|MEMBER_GROUP_MAJOR|GROUP_MAJOR_NAME|2";
        public const string sc_mem_m_ucf_graduation     = "#sc_mem_m_ucf_graduation|graduate_code|graduate_description";
        public const string sc_mem_m_ucf_loan_group     = "#sc_mem_m_ucf_loan_group|group_loan|group_loan_name";
        public const string sc_mem_m_ucf_member_group_type  = "#sc_mem_m_ucf_member_group_type|member_group_type|member_group_type_name";
        public const string sc_mem_m_ucf_member_group_type2 = "#sc_mem_m_ucf_member_group_type|member_group_type|member_group_type_name|2";
        public const string sc_mem_m_ucf_revenue_type3  = @"select a.revenue_type_code as item_code
,a.revenue_type_code||' - '||a.revenue_type_description as item_desc
,a.group_code
,a.revenue_ref_code
from (select sc_mem_m_ucf_revenue_type.revenue_type_code,
         sc_mem_m_ucf_revenue_type.revenue_type_description,
         sc_mem_m_ucf_revenue_type.group_code,
         sc_mem_m_ucf_revenue_type.revenue_ref_code
from sc_mem_m_ucf_revenue_type
where revenue_type_code <> '00'
union all
select sc_mem_m_ucf_expense_type.expense_type_code,
       sc_mem_m_ucf_expense_type.expense_type_description,
       sc_mem_m_ucf_expense_type.group_code,
       sc_mem_m_ucf_expense_type.expense_ref_code
from sc_mem_m_ucf_expense_type
where expense_type_code <> '00') a /*WHERE*/";
        public const string sc_mem_m_ucf_insure_status = @"select company_status as item_code,company_status||' - '||company_desc||' - '||company_status_control as item_desc from sc_mem_m_ucf_insure_status order by company_status";

        // ─── Insurance ────────────────────────────────────────────────────────────

        public const string sc_mem_m_insure_ucf   = "select item_type as item_code,item_type_desc as item_desc from sc_mem_m_insure_ucf order by item_type";
        public const string sc_mem_m_insure_ucf2  = "select item_type as item_code,item_type||' - '||item_type_desc as item_desc from sc_mem_m_insure_ucf order by item_type";
        public const string sc_mem_m_insure_rule  = "select insurance_type as item_code,insurance_type||' - '||insurance_desc as item_desc from sc_mem_m_insure_rule order by insurance_type";
        public const string sc_mem_m_insure_rule2 = @"select insurance_type as item_code,insurance_type||' - '||insurance_desc as item_desc
from sc_mem_m_insure_rule where law_status = '1' order by sort_order";
        public const string sc_mem_m_insure_rule3 = "#sc_mem_m_insure_rule|insurance_type|insurance_desc|2|active_status = '1'";
        public const string sc_mem_m_insure_rule_insur2 = @"select insurance_type as item_code,insurance_type||' - '||insurance_desc as item_desc
from sc_mem_m_insure_rule where insure_status = '1' order by sort_order";
        public const string sc_mem_m_insure_rule_req = @"select insurance_type as item_code,insurance_type||' - '||insurance_desc as item_desc
from sc_mem_m_insure_rule
where yearly_keep = '1'
order by sort_order";
        public const string sc_mem_m_insure_2 = @"select insurance_type as item_code,insurance_type||' - '||insurance_desc as item_desc
from sc_mem_m_insure_rule where insure_loan = '1' and active_status = '1' order by sort_order";
        public const string sc_mem_m_ucf_resign_ins = @"select resign_code as item_code,
    resign_code||' - '||resign_name as item_desc
from sc_mem_m_ucf_resign_ins
order by resign_code";

        // ─── Cremation / Coordinate ───────────────────────────────────────────────

        public const string sc_mem_m_member_crem_type      = "#sc_mem_m_member_crem_type|crem_type|crem_name_shot";
        public const string sc_mem_m_member_crem_type_code = @"select crem_type as item_code, crem_type||' - '||crem_name_shot as item_desc from sc_mem_m_member_crem_type order by crem_type";
        // CHANGED: Oracle SUBSTR(str,0,n) → SUBSTR(str,1,n); DECODE → CASE WHEN
        public const string sc_mem_m_member_cremation_round = @"select seq_no as item_code,
(SUBSTR(crem_round,1,2)||'/'||SUBSTR(crem_round,3))||CASE WHEN crem_special=1 THEN '*' ELSE '' END as item_desc
from sc_mem_m_member_cremation_round
where crem_type = {0}
order by seq_no";
        public const string sc_mem_m_member_cremation_round_all = @"select seq_no as item_code,
(SUBSTR(crem_round,1,2)||'/'||SUBSTR(crem_round,3))||CASE WHEN crem_special=1 THEN '*' ELSE '' END as item_desc,
crem_type
from sc_mem_m_member_cremation_round order by seq_no";

        // ─── Address ──────────────────────────────────────────────────────────────

        public const string sc_mem_m_ucf_adress = @"select sc_mem_m_ucf_subdistrict.subdistrict_name||', '||
CASE WHEN sc_mem_m_ucf_province.province_code='0101' THEN 'เขต' ELSE 'อำเภอ' END||
sc_mem_m_ucf_district.district_name||', '||sc_mem_m_ucf_province.province_name||', '||sc_mem_m_ucf_district.post_code as item_desc,
sc_mem_m_ucf_province.province_code||sc_mem_m_ucf_subdistrict.subdistrict_code as item_code
from sc_mem_m_ucf_district,
sc_mem_m_ucf_province,
sc_mem_m_ucf_subdistrict
where sc_mem_m_ucf_subdistrict.district_code = sc_mem_m_ucf_district.district_code
and sc_mem_m_ucf_district.province_code = sc_mem_m_ucf_province.province_code";
        public const string sc_mem_m_ucf_district0 = @"SELECT DISTINCT district_name AS item_code, district_name AS item_desc FROM sc_mem_m_ucf_district where 1=1 /*WHERE*/";
        public const string sc_mem_m_ucf_province0 = @"SELECT DISTINCT province_name AS item_code, province_name AS item_desc FROM sc_mem_m_ucf_province where 1=1 /*WHERE*/";

        // ─── Scholarship ──────────────────────────────────────────────────────────

        public const string sc_sch_rule  = "#sc_sch_rule|scholarship_type|description";
        public const string sc_sch_rule2 = "#sc_sch_rule|scholarship_type|description|2";
        public const string sc_sch_ucf_class    = "#sc_sch_ucf_class|child_class_code|description";
        public const string sc_sch_ucf_class2   = "#sc_sch_ucf_class|child_class_code|description|2";
        public const string sc_sch_ucf_graduate  = @"select graduate_type as item_code,graduate_name as item_desc from sc_sch_ucf_graduate order by graduate_type";
        public const string sc_sch_ucf_graduate2 = "#sc_sch_ucf_graduate|graduate_type|graduate_name|2";

        // ─── Security ─────────────────────────────────────────────────────────────

        public const string si_security_group = "#si_security_group|group_id|group_desc";
        // CHANGED: nlssort Oracle Thai sort → plain ORDER BY
        public const string si_security_template = @"select page_name as item_code,control_desc as item_desc
from si_security_template where control_type = 'RibbonDropDownButtonItem'
group by control_desc, page_name
order by control_desc nulls first";
        public const string si_security_user         = "#si_security_user|user_id|user_name";
        public const string si_security_user2        = "#si_security_user|user_id|user_name|2";
        public const string si_security_user_active  = "#si_security_user|user_id|user_name|2|CLOSE_STATUS=0";
        public const string si_security_apps = @"select app_name as item_code
,app_name||' - '||app_text as item_desc
from si_security_apps
where i_level = '1'
and active = '1'
order by i_sequence";
        public const string sc_security_permit_ucf = @"select security_code as item_code,code_desc as item_desc from sc_security_permit_ucf order by security_code,autherize_mode";
        public const string si_server_sites = "#si_server_sites|app_name";

        // ─── ATM ──────────────────────────────────────────────────────────────────

        public const string sc_atm_m_ucf_send_item      = "#sc_atm_m_ucf_send_item|item_type|item_desc";
        public const string sc_atm_ucf_modify_status     = "#sc_atm_ucf_modify_status|modify_status|modify_desc|2";
        public const string sc_atm_ucf_modify_status_active = @"select modify_status as item_code, modify_status||' - '||modify_desc as item_desc from sc_atm_ucf_modify_status where active_status=1 order by sort_order";

        // ─── SM (shadow) ──────────────────────────────────────────────────────────

        public const string sm_mem_m_ucf_member_type     = "#sm_mem_m_ucf_member_type|mem_type_code|mem_type_desc";
        public const string sm_mem_m_ucf_blood           = "#sm_mem_m_ucf_blood|blood_code|blood_desc";
        public const string sm_com_m_ucf_receipt_item_type = "#sm_com_m_ucf_receipt_item_type|item_type_id|item_type_name";
        public const string sm_com_m_ucf_money_type      = "#sm_com_m_ucf_money_type|money_type_id|money_type_name";
        public const string sm_acc_m_ucf_bank            = "#sm_acc_m_ucf_bank|bank_id|bank_name";
        public const string sm_mem_m_ucf_share_item_type = "#sm_mem_m_ucf_share_item_type|item_type|item_type_description";
        public const string sm_mem_m_ucf_concern         = "#sm_mem_m_ucf_concern|conceern_code|related_na";

        // ─── Keeping ──────────────────────────────────────────────────────────────

        public const string sc_kep_m_ucf_keeping_item_type     = "#sc_kep_m_ucf_keeping_item_type|keeping_type_code|keeping_type_name";
        public const string sc_kep_m_ucf_keeping_item_type_isp = "#sc_kep_m_ucf_keeping_item_type|keeping_type_code|keeping_type_name|1|keeping_type_group='ISP'";
        public const string sc_kep_m_ucf_process = @"select SC_KEP_M_UCF_PROCESS.PROC_CODE as item_code
,SC_KEP_M_UCF_PROCESS.PROC_DETAIL as item_desc
from SC_KEP_M_UCF_PROCESS
where SC_KEP_M_UCF_PROCESS.invisible_status = '1'
order by SC_KEP_M_UCF_PROCESS.PROC_CODE";
        public const string sc_kep_m_ucf_reason_return  = "#sc_kep_m_ucf_reason_return|reason_return_code|reason_return_name";
        public const string sc_kep_m_ucf_reason_return2 = "#sc_kep_m_ucf_reason_return|reason_return_code|reason_return_name|2";

        // ─── HR ───────────────────────────────────────────────────────────────────

        public const string sc_hr_ucf_official_type      = "#sc_hr_ucf_official_type|official_type|official_type_desc";
        public const string sc_hr_ucf_income_code        = "select income_code as item_code,income_code||' - '||income_desc as item_desc from sc_hr_ucf_income_code order by income_code";
        public const string sc_hr_ucf_income_code_no_out = @"select income_code as item_code,income_code||' - '||income_desc as item_desc from sc_hr_ucf_income_code where income_status = '0'";
        public const string sc_hr_ucf_income_code_no_in  = @"select income_code as item_code,income_code||' - '||income_desc as item_desc from sc_hr_ucf_income_code where income_status = '1'";
        public const string sc_hr_ucf_uniform_type       = "#sc_hr_ucf_uniform_type|uniform_type|uniform_desc";
        public const string sc_hr_ucf_souvenir_type      = "#sc_hr_ucf_souvenir_type|souvenir_type|souvenir_desc";
        public const string sc_hr_ucf_vehicle_type       = "#sc_hr_ucf_vehicle_type|vehicle_type|vehicle_desc";
        public const string sc_hr_ucf_allowance_type     = "#sc_hr_ucf_allowance_type|allowance_type|allowance_desc";
        public const string sc_hr_ucf_work_type          = "#sc_hr_ucf_work_type|work_type|work_desc";
        public const string sc_hr_ucf_department         = "#sc_hr_ucf_department|department_id|department_desc";
        public const string sc_hr_ucf_department2        = "#sc_hr_ucf_department|department_id|department_desc|2";
        public const string sc_hr_ucf_official_position  = "#sc_hr_ucf_official_position|official_position|official_desc";
        public const string sc_hr_ucf_official_position2 = "#sc_hr_ucf_official_position|official_position|official_desc|2";
        public const string sc_hr_ucf_aid_type           = @"select aid_type as item_code,aid_desc as item_desc from sc_hr_ucf_aid_type order by aid_type";
        public const string sc_hr_ucf_spouse_code        = "#sc_hr_ucf_spouse_code|spouse_code|spouse_description";
        public const string sc_hr_ucf_work_coll_type     = "#sc_hr_ucf_work_coll_type|coll_type|coll_desc";
        public const string sc_hr_ucf_committee_position = "#sc_hr_ucf_committee_position|committee_position|committee_desc";
        public const string sc_hr_ucf_leave_type         = @"select leave_type as item_code,leave_desc as item_desc from sc_hr_ucf_leave_type order by leave_type";
        public const string sc_hr_ucf_doc_head_code_short = @"select doc_head_code_short_code as item_code,doc_head_code_short_desc as item_desc from sc_hr_ucf_doc_head_code_short order by doc_head_code_short_code";
        public const string sc_hr_ucf_group_fr           = @"select group_fr_code as item_code,group_fr_name as item_desc from sc_hr_ucf_group_fr order by group_fr_code";
        public const string sc_hr_ucf_resign_code        = "#sc_hr_ucf_resign_code|resign_code|resign_desc";
        public const string sc_hr_ucf_resign_code2       = "#sc_hr_ucf_resign_code|resign_code|resign_desc|2";
        public const string sc_hr_ucf_keep_placement     = "#sc_hr_ucf_keep_placement|keep_placement|keep_location";
        public const string sc_hr_ucf_keep_placement2    = "#sc_hr_ucf_keep_placement|keep_placement|keep_location|2";
        public const string sc_hr_ucf_doc_headcode       = @"select doc_headcode as item_code,doc_headcode||' - '||doc_desc as item_desc from sc_hr_ucf_doc_headcode where status_in='1' order by doc_status,doc_headcode";
        public const string sc_hr_ucf_salary_paid_other  = "#sc_hr_ucf_salary_paid_other|paid_other|paid_other_desc";
        public const string sc_hr_ucf_salary_paid_other2 = "#sc_hr_ucf_salary_paid_other|paid_other|paid_other_desc|2";
        public const string sc_hr_ucf_doc_status         = "#sc_hr_ucf_book_status|book_status|book_desc";
        public const string sc_hr_ucf_doc_status2        = "#sc_hr_ucf_book_status|book_status|book_desc|2";
        public const string sc_hr_ucf_hospital_social    = "#sc_adm_ucf_hotpital|hotpital_code|hotpital_name";
        public const string sc_hr_ucf_hospital_social2   = "#sc_hr_ucf_hospital_social|hopital_social_id|hopital_desc|2";
        public const string sc_hr_lup_province           = "#sc_hr_lup_province|c_province_code|c_province";
        public const string sc_hr_off_member_commitee = @"select official_no as item_code, prename||member_name||' '||member_surname as item_desc
from sc_hr_off_member,sc_mem_m_ucf_prename where 1=1
and sc_mem_m_ucf_prename.prename_code = sc_hr_off_member.prename_code
and official_type = '10'
order by official_no";
        public const string sc_hr_off_member_official = @"select official_no as item_code, prename||member_name||' '||member_surname as item_desc
from sc_hr_off_member,sc_mem_m_ucf_prename where 1=1
and sc_mem_m_ucf_prename.prename_code = sc_hr_off_member.prename_code
and official_type = '01'
order by official_no";

        // ─── Welfare ──────────────────────────────────────────────────────────────

        public const string sc_wef_ucf_hospital = @"select hospital_code||' - '||hospital_name as item_desc,
       hospital_code as item_code from sc_wef_ucf_hospital order by sort_order";
        public const string sc_wef_rule_ded  = "#sc_wef_rule_ded|ded_code|ded_desc|2";
        public const string sc_wef_rule_ded2 = @"select ded_code as item_code,
level_memage as item_date,
paid_rate as ded_item_desc,
ded_code||' - '||level_memage||' - '||paid_rate as item_desc from sc_wef_rule_ded";
        public const string sc_wef_rule_dag    = "#sc_wef_rule_dag|dag_type|dag_desc|2";
        public const string sc_wef_rule_evt    = "#sc_wef_rule_evt|evt_type|evt_desc|2";
        public const string sc_wef_rule_oth    = "#sc_wef_rule_oth|oth_code|oth_desc|2";
        public const string sc_wef_rule_sem    = "#sc_wef_rule_sem|sem_code|sem_desc|2";
        public const string sc_wef_rule_cmt    = "#sc_wef_rule_cmt|cmt_type|cmt_desc|2";
        public const string sc_wef_rule_ext    = "#sc_wef_rule_ext|ext_type|ext_desc|2";
        public const string sc_wef_rule_hrd    = "#sc_wef_rule_hrd|hrd_type|hrd_desc|2";
        public const string sc_wef_ucf_hrn_class = "#sc_wef_ucf_hrn_class|class_type|class_desc|2";
        public const string sc_wef_rule_hrn = @"select distinct HRN_TYPE as item_code,
HRN_DESC as hrn_item_desc,
HRN_TYPE||' - '||HRN_DESC as item_desc from sc_wef_rule_hrn order by hrn_type";
        public const string sc_wef_rule_hre = @"select HRE_TYPE as item_code,
HRE_TYPE||' - '||HRE_DESC as item_desc from sc_wef_rule_hre order by hre_type";
        public const string sc_wef_rule_cvd = @"select cvd_type as item_code,
cvd_date as item_date,
cvd_desc as cvd_item_desc,
cvd_type||' - '||cvd_date||' - '||cvd_desc as item_desc from sc_wef_rule_cvd";
        public const string sc_wef_rule_edu       = "#sc_wef_rule_edu|edu_type|edu_desc|2";
        public const string sc_wef_ucf_type       = "#sc_wef_ucf_type|wef_type|wef_desc|2|active_status=1";
        public const string sc_wef_ucf_type2      = @"select wef_type as item_code,wef_desc as item_desc from sc_wef_ucf_type where active_status=1 order by wef_desc";
        public const string sc_wef_ucf_type3      = @"select wef_type as item_code, wef_type||' - '||wef_desc as item_desc from sc_wef_ucf_type where active_status=1 order by order_by";
        public const string sc_wef_ucf_type_hr_only  = @"select wef_type as item_code, wef_type||' - '||wef_desc as item_desc from sc_wef_ucf_type where active_status=1 and hr_active_status=1 order by order_by";
        public const string sc_wef_ucf_type_wef_only = @"select wef_type as item_code, wef_type||' - '||wef_desc as item_desc from sc_wef_ucf_type where active_status=1 and hr_active_status=0 order by order_by";
        public const string sc_wef_ucf_edu_class  = "#sc_wef_ucf_edu_class|class_type|class_desc|2";
        public const string sc_wef_ucf_hre_class  = "#sc_wef_ucf_hre_class|class_type|class_desc|2";
        public const string sc_wef_ucf_ded_reason = "#sc_wef_ucf_ded_reason|reason_type|reason_desc|2";

        // ─── Election ─────────────────────────────────────────────────────────────

        public const string sc_mem_m_ucf_election_group = @"select election_group as item_code,
election_group||' : '||election_group_name||' - '||(select election_zone_name
 from sc_mem_m_ucf_election_zone
 where sc_mem_m_ucf_election_zone.election_zone = sc_mem_m_ucf_election_group.election_zone) as item_desc
from sc_mem_m_ucf_election_group
ORDER BY CAST(SUBSTRING(ELECTION_GROUP, 2) AS INTEGER) ASC";
        public const string sc_mem_m_ucf_election_position = "#sc_mem_m_ucf_election_position|POSITION_CODE|POSITION_DESC|2";
        public const string sc_mem_m_ucf_election_zone     = "#sc_mem_m_ucf_election_zone|ELECTION_ZONE|ELECTION_ZONE_NAME|2";
        public const string sc_mem_m_ucf_election_control  = "#sc_mem_m_ucf_election_control|control_no|control_name";
        public const string sc_mem_m_ucf_election_control2 = "#sc_mem_m_ucf_election_control|control_no|control_name|2";

        // ─── Work group ───────────────────────────────────────────────────────────

        public const string sc_mem_m_ucf_work_01000 = "#sc_mem_m_ucf_work_01000|work_01000|work_01000_desc";
        public const string sc_mem_m_ucf_work_01100 = "#sc_mem_m_ucf_work_01100|work_01100|work_01100_desc";
        public const string sc_mem_m_ucf_work_01110 = "#sc_mem_m_ucf_work_01110|work_01110|work_01110_desc";
        public const string sc_mem_m_ucf_work_01111 = "#sc_mem_m_ucf_work_01111|work_01111|work_01111_desc";

        // ─── Bill payment ─────────────────────────────────────────────────────────

        public const string sc_bill_ucf_payment_item_code = "#sc_bill_ucf_payment_item_code|payment_item_code|payment_item_decription|2";
        public const string sc_bill_ucf_system_code       = "#sc_bill_ucf_system_code|system_code|system_decription|2";

        // ─── Investment ───────────────────────────────────────────────────────────

        public const string sc_inv_bill_ins_type    = "#sc_inv_bill_ins_type|instrument_type_id|instrument_name";
        public const string sc_inv_bill_ins_type2   = "#sc_inv_bill_ins_type|instrument_type_id|instrument_name|2";
        public const string sc_inv_ucf_organize_type2 = "#sc_inv_ucf_organize_type|type_of_org|type_org_desc|2";
        public const string sc_inv_ln_customer      = @"select customer_no as item_code,customer_no||' - '||cus_name as item_desc from sc_inv_ln_customer order by customer_no";
        public const string sc_inv_bill_ucf_payment = @"select payment_id as item_code,payment_desc as item_desc from sc_inv_bill_ucf_payment order by payment_id";
        public const string sc_inv_bill             = "#sc_inv_bill|bill_no|bill_name";
        public const string sc_inv_bill2            = "#sc_inv_bill|bill_no|bill_name|2";
        public const string sc_inv_ucf_plan_data    = "#sc_inv_ucf_plan_data|plan_data|plan_desc";
        public const string sc_inv_ucf_plan_data2   = "#sc_inv_ucf_plan_data|plan_data|plan_desc|2";
        public const string sc_inv_ucf_plan_type    = "#sc_inv_ucf_plan_type|inv_type|inv_desc";
        public const string sc_inv_ucf_plan_type2   = "#sc_inv_ucf_plan_type|inv_type|inv_desc|2";
        public const string inv_sc_mem_m_ucf_prename = @"select prename_code as item_code, prename as item_desc
from sc_mem_m_ucf_prename where invest_status = '1' order by prename_code,prename";
        public const string inv_sc_mem_m_ucf_member_group = "#sc_mem_m_ucf_member_group|member_group_no|member_group_name|2|invest_status=1";
        public const string inv_sc_mem_m_ucf_member_type  = @"select mem_type_code as item_code,mem_type_code||' - '||mem_type_desc as item_desc
from sc_mem_m_ucf_member_type where invest_status = '1' order by mem_type_code";
        public const string inv_sc_lon_m_rule = @"select loan_type as item_code,
    loan_type||' - '||loan_type_description as item_desc
from sc_lon_m_rule
where user_current = '1' and invest_status = '1' order by sort_order";
        public const string inv_sc_acc_m_account_master = @"select account_id as item_code,account_id||' - '||account_name as item_desc from sc_acc_m_account_master where cancel_status = '0' and invest_status='1'";
        public const string inv_sc_com_m_ucf_money_type = @"select money_type_id as item_code
,money_type_id||' - '||money_type_name as item_desc
from sc_com_m_ucf_money_type
where invest_status = '1'
order by sort_order";
        public const string inv_sc_mem_m_ucf_member_name = @"select membership_no as item_code,
(select prename from sc_mem_m_ucf_prename where prename_code = sc_mem_m_membership_registered.prename_code)||' '||
sc_mem_m_membership_registered.member_name||'  '||
sc_mem_m_membership_registered.member_surname as item_desc
from sc_mem_m_membership_registered,sc_mem_m_ucf_member_group
where 1=1
and sc_mem_m_membership_registered.member_group_no = sc_mem_m_ucf_member_group.member_group_no
and sc_mem_m_ucf_member_group.invest_status = '1'
order by membership_no";
        public const string inv_sc_dep_m_rule  = "#sc_dep_m_rule|deposit_type_code|deposit_name|1|invest_status='1'";
        public const string inv_sc_dep_m_rule2 = "#sc_dep_m_rule|deposit_type_code|deposit_name|2|invest_status='1'";

        // ─── Stock ────────────────────────────────────────────────────────────────

        public const string sc_sto_company_profile  = "#sc_sto_company_profile|id_company|name_com";
        public const string sc_sto_company_profile2 = "#sc_sto_company_profile|id_company|name_com|2";
        public const string sc_sto_product_type     = @"select product_id as item_code,product_id||' - '||
trim((product_name))||trim(CASE WHEN product_class IS NOT NULL THEN ' / '||product_class ELSE '' END)
||trim(CASE WHEN product_color IS NOT NULL THEN ' / '||product_color ELSE '' END)
||trim(CASE WHEN product_brand IS NOT NULL THEN ' / '||product_brand ELSE '' END) as item_desc
from sc_sto_product_type order by product_id";
        public const string sc_sto_stock_manage     = @"select section_id as item_code ,section_desc as item_desc from sc_sto_stock_manage";
        public const string sc_sto_product_cag      = @"select cat_id as item_code ,product_categlory as item_desc from sc_sto_stock_pro_type";
        public const string sc_sto_product_type2    = "#sc_sto_stock_pro_type|cat_id|product_categlory|2";
        public const string sc_sto_place            = @"select place_id as item_code ,place_name as item_desc from sc_sto_stock_ucf_place";
        public const string sc_sto_stock_obj_pick   = "#sc_sto_stock_obj_pick|obj_pick_id|obj_pick_desc";
        public const string sc_sto_stock_obj_pick2  = @"select obj_pick_id as item_code ,obj_pick_desc as item_desc from sc_sto_stock_obj_pick";

        // ─── Estate ───────────────────────────────────────────────────────────────

        public const string sc_est_m_ucf_borrow_objective0 = @"select borrow_objective_desc as item_code,borrow_objective_desc as item_desc from sc_est_m_ucf_borrow_objective where 1=1 order by sort_order";
        public const string sc_est_m_ucf_borrow_objective  = @"select borrow_objective_code as item_code,borrow_objective_desc as item_desc from sc_est_m_ucf_borrow_objective where 1=1 order by sort_order";
        public const string sc_est_m_ucf_borrow_objective2 = @"select borrow_objective_code as item_code,borrow_objective_code||' - '||borrow_objective_desc as item_desc from sc_est_m_ucf_borrow_objective where 1=1 order by sort_order";

        // ─── E-Office ─────────────────────────────────────────────────────────────

        public const string sc_eoff_ucf_keep_placement  = "#sc_eoff_ucf_keep_placement|keep_placement|keep_location";
        public const string sc_eoff_ucf_keep_placement2 = "#sc_eoff_ucf_keep_placement|keep_placement|keep_location|2";
        public const string sc_eoff_ucf_doc_headcode    = @"select doc_headcode as item_code,doc_headcode||' - '||doc_desc as item_desc from sc_eoff_ucf_doc_headcode where status_in='1' order by doc_status,doc_headcode";
        public const string sc_eoff_ucf_department      = "#sc_eoff_ucf_department|department_id|department_desc";
        public const string sc_eoff_ucf_department2     = "#sc_eoff_ucf_department|department_id|department_desc|2";

        // ─── Letter ───────────────────────────────────────────────────────────────

        public const string sc_mem_m_ucf_letter  = "#sc_mem_m_ucf_letter|letter_type|letter_name";
        public const string sc_mem_m_ucf_letter2 = "#sc_mem_m_ucf_letter|letter_type|letter_name|2";

        // ─── AD sync ──────────────────────────────────────────────────────────────

        public const string sc_adsync_ucf_enable = "#sc_adsync_ucf_enable|ads_code|ads_desc";

        // ─── Report level ─────────────────────────────────────────────────────────

        public const string sc_rep_level_ucf  = "#sc_rep_level_ucf|level_status|level_desc";
        public const string sc_rep_level_ucf2 = "#sc_rep_level_ucf|level_status|level_desc|2";

        // ─── Amnat grade ──────────────────────────────────────────────────────────

        public const string sc_amnat_grade_ucf_chg  = "#sc_amnat_grade_ucf_chg|chg_code|chg_desc";
        public const string sc_amnat_grade_ucf_chg2 = "#sc_amnat_grade_ucf_chg|chg_code|chg_desc|2";

        // ─── Finance new-style refs ───────────────────────────────────────────────

        public const string sc_fin_m_bank_new     = "table=sc_fin_m_bank|key=bank_fin|value=bank_name";
        public const string sc_acc_m_ucf_bank_new = "table=sc_acc_m_ucf_bank|key=bank_id|value=bank_name";
    }
}
