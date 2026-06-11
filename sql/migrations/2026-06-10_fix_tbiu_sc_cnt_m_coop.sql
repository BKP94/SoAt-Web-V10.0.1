-- ─────────────────────────────────────────────────────────────────────────────
-- Fix: trigger_fct_tbiu_sc_cnt_m_coop compile error (migration typo)
--
-- อาการ: insert/update sc_cnt_m_coop ทุกครั้งระเบิด — PG ปฏิเสธตอน compile trigger body
--   เพราะ migrate Oracle→PG ทำ token เพี้ยน 1 บรรทัด:
--       coalesce(ifNEW.percent_share::text, '') = '' then ...   ← "if" หาย เชื่อมเป็น ifNEW
--   ที่ถูก:  if coalesce(NEW.percent_share::text, '') = '' then ...
--
-- ผลข้างเคียง: seeder ใส่ sc_cnt_m_coop ไม่ได้ → ตารางว่าง → scCenter chip "ฐานข้อมูล"(sys_name) ขึ้น "—"
--
-- การแก้: CREATE OR REPLACE ด้วย body เดิม 1:1 แก้เฉพาะบรรทัด percent_share
--   (คงส่วนอื่นทั้งหมด รวม comment Oracle เดิม + quirk count_resign_m ตาม legacy)
-- เกี่ยวกับ 2026-06-06_pka_trigger_infra.sql (spa_dberrcol ถูกสร้างไว้แล้ว)
-- ─────────────────────────────────────────────────────────────────────────────

CREATE OR REPLACE FUNCTION public.trigger_fct_tbiu_sc_cnt_m_coop()
 RETURNS trigger
 LANGUAGE plpgsql
 SECURITY DEFINER
AS $function$
BEGIN
  if coalesce(NEW.coop_name::text, '') = '' or NEW.coop_name = ' 'then
    CALL spa_dberrcol('sc_cnt_m_coop','coop_name',NEW.coop_name);
  end if;

  if coalesce(NEW.AUTO_APPROVE_NEWMEM::text, '') = '' then NEW.AUTO_APPROVE_NEWMEM :='0';end  if;
  if coalesce(NEW.BATFILE_PAYMENT_ABLE::text, '') = '' then NEW.BATFILE_PAYMENT_ABLE :='0';end if;
  if coalesce(NEW.BRANCH_SUPPORT::text, '') = '' then NEW.BRANCH_SUPPORT :='0';end if;
  if coalesce(NEW.CAL_RETIRE_METHOD::text, '') = ''  then NEW.CAL_RETIRE_METHOD :='0';end if;
  if coalesce(NEW.CALENDAR_ABLE::text, '') = '' then NEW.CALENDAR_ABLE :='0';end if;
  if coalesce(NEW.CHANGE_SHARE_MONTHCOUNT::text, '') = '' then NEW.CHANGE_SHARE_MONTHCOUNT :=0;end if;
  if coalesce(NEW.DAY_ALLOW_BUY_SHARE::text, '') = '' then NEW.DAY_ALLOW_BUY_SHARE :=0;end if;
  if coalesce(NEW.DEPOSIT_VISIBLE::text, '') = '' then NEW.DEPOSIT_VISIBLE:='0';end if;

  if coalesce(NEW.div_month_count::text, '') = ''  then
    NEW.div_month_count  := 11;
  else
    if coalesce(OLD.div_month_count::text, '') = '' or OLD.div_month_count <> NEW.div_month_count then
      if NEW.div_month_count not in ( 11,12 ) then
        CALL spa_dberrcol('sc_cnt_m_coop','div_month_count',trim(both NEW.div_month_count));
      end if;
    end if;
  end if;

  if coalesce(NEW.dividend_method::text, '') = '' then
    NEW.dividend_method := 3; -- รายวัน
  else
    if coalesce(OLD.dividend_method::text, '') = '' or OLD.dividend_method <> NEW.dividend_method then
      if NEW.dividend_method not in (1,2,3) then
        CALL spa_dberrcol('sc_cnt_m_coop','dividend_method',trim(both NEW.dividend_method));
      end if;
    end if;
  end if;
  if coalesce(NEW.DIVIDEND_PAY_RESIGN::text, '') = '' then NEW.DIVIDEND_PAY_RESIGN :='0';end if;
  if coalesce(NEW.EDIT_EMMDATA_MUTILROW::text, '') = '' then NEW.EDIT_EMMDATA_MUTILROW :='0';end if;
  if coalesce(NEW.ENDCODE_PASSWORD::text, '') = '' then NEW.ENDCODE_PASSWORD :='1';end if;
  if coalesce(NEW.FIN_REALTIME_CASH::text, '') = '' then NEW.FIN_REALTIME_CASH :='0';end if;
  if coalesce(NEW.IVR_STATUS::text, '') = '' then NEW.IVR_STATUS :='0';end if;
  if coalesce(NEW.KEEPING_REF_OTHER::text, '') = '' then NEW.KEEPING_REF_OTHER :='0';end if;
  if coalesce(NEW.number_client_active::text, '') = '' then    NEW.number_client_active :=0;end if;
  if coalesce(NEW.over_share_gain::text, '') = '' then    NEW.over_share_gain := 0;end if;
  if coalesce(NEW.password_expire_day::text, '') = '' then    NEW.password_expire_day :=0;end if;
  if coalesce(NEW.percent_share::text, '') = '' then    NEW.percent_share :=0;end if;
  if coalesce(NEW.PL_ASK_COUNTPERIOD::text, '') = '' then NEW.PL_ASK_COUNTPERIOD :='0';end if;
  if coalesce(NEW.retire_age::text, '') = '' then    NEW.retire_age :=0;end if;
  if coalesce(NEW.retire_age_type::text, '') = '' then
    NEW.retire_age_type :='0';
  else
    if coalesce(OLD.retire_age_type::text, '') = '' or OLD.retire_age_type <> NEW.retire_age_type then
      if NEW.retire_age_type not in ('0','1','2') then
        CALL spa_dberrcol('sc_cnt_m_coop','retire_age_type',NEW.retire_age_type);
      end if;
    end if;
  end if;
  if coalesce(NEW.RETIRE_BYMONTH_STATUS::text, '') = '' then NEW.RETIRE_BYMONTH_STATUS :='0';end if;
--  if :new.retire_month is null or :new.retire_month = ' ' then
--    :new.retire_month := '09'; -- ก.ย.
--  else
--    if :old.RETIRE_MONTH is null or :old.RETIRE_MONTH <> :new.RETIRE_MONTH then
--      if Not( to_number( :new.retire_month ) between 1 and  12 ) then
--        spa_dberrcol('sc_cnt_m_coop','retire_month',trim(:new.retire_month));
--      end if;
--    end if;
--  end if;
  if coalesce(trim(both NEW.send_share_status)::text, '') = '' then
    NEW.send_share_status := '0';
  /*else S.Nikom เอาออก
    if :old.send_share_status is null or :old.send_share_status <> :new.send_share_status then
      if :new.send_share_status not in ('0','1','9') then
        spa_dberrcol('sc_cnt_m_coop','send_share_status',:new.send_share_status);
      end if;
    end if;*/
  end if;
  if coalesce(NEW.date_type::text, '') = '' then
    NEW.date_type := 'พศ';
  else
    if coalesce(OLD.date_type::text, '') = '' or OLD.date_type <> NEW.date_type then
      if NEW.date_type not in ('พศ','คศ') then
        CALL spa_dberrcol('sc_cnt_m_coop','date_type',NEW.date_type);
      end if;
    end if;
  end if;
  if coalesce(NEW.TRANS_MEMNO_ABLE::text, '') = '' then NEW.TRANS_MEMNO_ABLE :='0';end if;
  if coalesce(NEW.year_doom::text, '') = '' or NEW.year_doom = 0 then
    NEW.year_doom := Extract( year from statement_timestamp()  ) + 543;
  end if;
  if coalesce(NEW.id_card_mask::text, '') = '' or length(trim(both NEW.id_card_mask )) = 0 then
    NEW.id_card_mask := 'X-XXXX-XXXXX-XX-X';
  end if;
  if coalesce(NEW.count_resign::text, '') = '' then
      NEW.count_resign := 0;
  end if;
   if coalesce(trim(both NEW.count_resign_m)::text, '') = '' then
      NEW.count_resign := '0';
  end if;

RETURN NEW;
end
$function$;

-- ─────────────────────────────────────────────────────────────────────────────
-- แถม: column default ของ date_type เพี้ยนเป็น mojibake '??' (ตอน PL สร้างตารางใน
--   pgAdmin ค่าไทย 'พศ' encode พัง) → insert/update ที่ไม่ระบุ date_type จะได้ '??'
--   แล้ว trigger ด้านบน validate ('พศ','คศ') ไม่ผ่าน → ระเบิด. คืนค่า default ให้ตรง Oracle
-- ─────────────────────────────────────────────────────────────────────────────
ALTER TABLE sc_cnt_m_coop ALTER COLUMN date_type SET DEFAULT 'พศ';

-- ซ่อมแถวเดิม (ถ้ามี) ที่ date_type ถูกตั้งเป็น '??' ไปแล้ว
UPDATE sc_cnt_m_coop SET date_type = 'พศ' WHERE date_type = '??';
