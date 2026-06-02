CREATE TABLE sc_dep_m_creditor (
	deposit_account_no varchar(15) NOT NULL,
	deposit_type_code varchar(6) NOT NULL,
	membership_no varchar(15),
	deposit_opened_date timestamp,
	deposit_account_name varchar(200),
	deposit_objective varchar(200),
	deposit_balance decimal(15,2),
	withdrawable_amount decimal(15,2),
	cheque_pending_amount decimal(15,2),
	loan_holding_amount decimal(15,2),
	deposit_standsecurity_amount decimal(15,2),
	sequester_status char(1),
	withdraw_count double precision,
	accumulate_interest decimal(15,2),
	last_calcint_date timestamp,
	beging_balance decimal(15,2),
	present_account_year double precision,
	special_rule_status char(1),
	monthly_int_status char(1),
	monthly_deposit_status char(1),
	monthly_deposit_amount decimal(15,2),
	tax_status char(1),
	tax_id varchar(15),
	withdrawdued timestamp,
	accu_int_holding decimal(15,2),
	address varchar(200),
	remark varchar(1000),
	moneytype_deposit_status char(1),
	method_int_month char(1),
	deposit_account_no_other varchar(15),
	account_bank varchar(30),
	passbook_no varchar(15),
	printed_seq_no double precision,
	last_page double precision,
	last_line double precision,
	card_printed_seq_no double precision,
	card_last_page double precision,
	card_last_line double precision,
	int_rate_status char(1),
	int_rate decimal(8,6),
	close_status char(1),
	deposit_closing_date timestamp,
	froce_close_date timestamp,
	movement_times double precision,
	movement_check_date timestamp,
	movement_due_date timestamp,
	fee_maintenance decimal(15,2),
	fee_maintenance_arrear decimal(15,2),
	interest_arrear decimal(15,2),
	interest_arrear_date timestamp,
	interest_cut_date timestamp,
	interest_cut decimal(15,2),
	member_status char(1),
	crosscheck_balance decimal(15,2),
	crosscheck_withdraw decimal(15,2),
	crosscheck_day timestamp,
	officer_id varchar(16),
	month_paid_int decimal(15,2),
	month_date_start timestamp,
	month_date_end timestamp,
	member_type char(1),
	deposit_dued_date timestamp,
	branch_id varchar(6),
	conclude_fixed char(1),
	transfer_to_bank varchar(20),
	remark_seques varchar(200),
	remark_cancleacc_close varchar(200),
	mlr_status char(1),
	not_int_comound_status char(1),
	rwmagnatic_status char(1),
	accu_int_cal decimal(15,2),
	accu_int_paid decimal(15,2),
	accu_int_temp decimal(15,2),
	dep_withdraw_per_day decimal(15,2),
	intmonth_bank varchar(6),
	atm_status char(1),
	last_access_time varchar(23) DEFAULT to_char(statement_timestamp(),'YYYY-MM-DD HH24:MI:SS.MS'),
	atm_regis_id char(16),
	atm_regis_date timestamp,
	last_compound_date timestamp,
	min_balance_fixed decimal(15,2) DEFAULT 0,
	paidintnostm decimal(15,2) DEFAULT 0,
	paid_nostm_init decimal(15,2) DEFAULT 0,
	accumulate_interest_copy decimal(15,2) DEFAULT 0,
	depdue timestamp,
	depcount double precision DEFAULT 0,
	special_tax_rate decimal(15,6) DEFAULT 0,
	membership_no_old varchar(15),
	paidint_bycountopen_date timestamp,
	last_access_time_main varchar(23) DEFAULT to_char(statement_timestamp(),'YYYY-MM-DD HH24:MI:SS.MS'),
	last_access_time_onsite varchar(23) DEFAULT to_char(statement_timestamp(),'YYYY-MM-DD HH24:MI:SS.MS'),
	intmonth_bankbr varchar(6),
	fixed_due_to_dep_no varchar(15),
	approx_int decimal(15,2) DEFAULT 0,
	close_id varchar(16),
	close_branch_id varchar(6),
	intmonth_name varchar(200),
	krabi_status char(1) DEFAULT '0',
	sequest_date timestamp,
	last_depdate timestamp,
	join_status char(1) DEFAULT '0',
	loan_type_coll varchar(6),
	account_id varchar(8),
	int_account_id varchar(8),
	deposit_account_old varchar(15),
	accumulate_spec_int decimal(15,2),
	last_calc_spec_date timestamp,
	bank_fin varchar(6)
) ;
COMMENT ON TABLE sc_dep_m_creditor IS E'!N?????????????N!';
COMMENT ON COLUMN sc_dep_m_creditor.account_bank IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.accu_int_holding IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.accumulate_interest IS E'!N????????????N!';
COMMENT ON COLUMN sc_dep_m_creditor.address IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.beging_balance IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.branch_id IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.card_last_line IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.card_last_page IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.card_printed_seq_no IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.cheque_pending_amount IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.close_status IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.conclude_fixed IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.crosscheck_balance IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.crosscheck_day IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.crosscheck_withdraw IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.depcount IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.depdue IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.deposit_account_name IS E'!N?????????N!';
COMMENT ON COLUMN sc_dep_m_creditor.deposit_account_no IS E'!N???????????N!';
COMMENT ON COLUMN sc_dep_m_creditor.deposit_account_no_other IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.deposit_balance IS E'!N?????????????????N!';
COMMENT ON COLUMN sc_dep_m_creditor.deposit_closing_date IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.deposit_dued_date IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.deposit_objective IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.deposit_opened_date IS E'!N???????????????N!';
COMMENT ON COLUMN sc_dep_m_creditor.deposit_standsecurity_amount IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.deposit_type_code IS E'!N?????????????N!';
COMMENT ON COLUMN sc_dep_m_creditor.fee_maintenance IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.fee_maintenance_arrear IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.froce_close_date IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.int_rate IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.int_rate_status IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.interest_arrear IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.interest_arrear_date IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.interest_cut IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.interest_cut_date IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.last_calcint_date IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.last_line IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.last_page IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.loan_holding_amount IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.member_status IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.member_type IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.membership_no IS E'!N?????????????N!';
COMMENT ON COLUMN sc_dep_m_creditor.membership_no_old IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.method_int_month IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.min_balance_fixed IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.mlr_status IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.moneytype_deposit_status IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.month_date_end IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.month_date_start IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.month_paid_int IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.monthly_deposit_amount IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.monthly_deposit_status IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.monthly_int_status IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.movement_check_date IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.movement_due_date IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.movement_times IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.not_int_comound_status IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.officer_id IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.paid_nostm_init IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.paidint_bycountopen_date IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.paidintnostm IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.passbook_no IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.present_account_year IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.printed_seq_no IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.remark IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.remark_cancleacc_close IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.remark_seques IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.rwmagnatic_status IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.sequester_status IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.special_rule_status IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.special_tax_rate IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.tax_id IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.tax_status IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.transfer_to_bank IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.withdraw_count IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.withdrawable_amount IS E'!NN!';
COMMENT ON COLUMN sc_dep_m_creditor.withdrawdued IS E'!NN!';
CREATE INDEX idx_dep_creditor_dep_balance ON sc_dep_m_creditor (deposit_balance);
CREATE INDEX idx_dep_creditor_dep_opendate ON sc_dep_m_creditor (deposit_opened_date);
CREATE INDEX idx_dep_creditor_dep_type ON sc_dep_m_creditor (deposit_type_code);
CREATE INDEX idx_dep_creditor_mamt ON sc_dep_m_creditor (monthly_deposit_amount);
CREATE INDEX idx_dep_creditor_memno ON sc_dep_m_creditor (membership_no);
CREATE INDEX idx_dep_creditor_mstatus ON sc_dep_m_creditor (monthly_deposit_status);
CREATE INDEX idx_dep_creditor_withdrawable ON sc_dep_m_creditor (withdrawable_amount);
CREATE INDEX ix_sc_dep_m_creditor_1 ON sc_dep_m_creditor (deposit_account_no, deposit_type_code, close_status);
ALTER TABLE sc_dep_m_creditor ADD PRIMARY KEY (deposit_account_no);
ALTER TABLE sc_dep_m_creditor ALTER COLUMN deposit_account_no SET NOT NULL;
ALTER TABLE sc_dep_m_creditor ALTER COLUMN deposit_type_code SET NOT NULL;


