CREATE TABLE sc_lon_m_loan_card_detail (
	loan_contract_no varchar(15) NOT NULL DEFAULT 'cnv',
	seq_no double precision NOT NULL,
	loan_payment_date timestamp,
	item_type_code varchar(6),
	ref_loan_doc_no varchar(15),
	principal_balance decimal(15,2),
	payment_amount decimal(15,2),
	interest_amout decimal(15,2),
	interest_from timestamp,
	interest_payment decimal(15,2),
	interest_arrear decimal(15,2),
	fine_amount decimal(15,2),
	interest_to timestamp,
	fine_payment decimal(15,2),
	fine_arrear decimal(15,2),
	last_interate_date timestamp,
	interest_return decimal(15,2),
	period double precision,
	branch_id varchar(6),
	entry_id varchar(16),
	entry_date timestamp,
	client_name varchar(15),
	int_share_coll decimal(15,2),
	share_coll_amount decimal(15,2),
	balance_receipt decimal(15,2),
	status char(1),
	remark varchar(255),
	temp_seq double precision,
	external_id varchar(7),
	membership_no varchar(15),
	loan_status char(1),
	interest_notpay decimal(15,2),
	client_pc varchar(3),
	old_interest_arrear decimal(15,2),
	calint_date_move char(1),
	ppm_status char(1),
	pay_principal_arr decimal(15,2),
	calint_method varchar(6),
	calint_active char(1),
	interest_calulate decimal(15,2),
	interest_arrear_add decimal(15,2),
	interest_arrear_bf decimal(15,2),
	interest_arrear_bal decimal(15,2),
	calcint_date timestamp,
	working_date timestamp,
	mark_status char(1) DEFAULT '0',
	calint_mesage varchar(100),
	keepint_over decimal(15,2) DEFAULT 0,
	seq_no_temp double precision DEFAULT 0,
	receive_status char(1) DEFAULT '0',
	keeping_status char(1) DEFAULT '0',
	co_code varchar(10),
	revers_seq numeric(38) DEFAULT 0,
	finance_date timestamp,
	begin_recalc char(1) DEFAULT '0',
	edit_seq_no integer DEFAULT 0,
	edit_entry_id varchar(16),
	edit_entry_date timestamp,
	edit_principal_balance decimal(15,2) DEFAULT 0,
	seq_adjust double precision DEFAULT 0,
	to_sybase char(1) DEFAULT '0',
	period_payment_amount double precision DEFAULT 0,
	split_seq integer DEFAULT 0,
	split_balance decimal(15,2) DEFAULT 0.00,
	real_balance decimal(15,2),
	accu_interest decimal(15,2),
	calintstep_code char(15),
	fin_status char(1),
	interest_calmonth decimal(15,2),
	interest_arrear_old decimal(15,2),
	intreturn_active char(1),
	old_item_type_code char(2),
	interest_amout_temp decimal(15,2)
) ;
COMMENT ON TABLE sc_lon_m_loan_card_detail IS E'!N??????? - ????????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.branch_id IS E'!N????N!!M???????????????????M!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.calint_active IS E'!NN!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.calint_date_move IS E'!NN!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.calint_method IS E'!NN!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.client_pc IS E'!N????????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.entry_date IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.entry_id IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.interest_amout IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.interest_arrear IS E'!N???????????????????N!!M?????????????????????????M!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.interest_arrear_bal IS E'!N???????????????????N!!M???????????????????????? interest_arrear ??? loan cardM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.interest_calulate IS E'!NN!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.interest_from IS E'!N?????????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.interest_notpay IS E'!N???????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.interest_return IS E'!NN!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.interest_to IS E'!N????????????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.item_type_code IS E'!N??????N!!M??????????M!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.loan_contract_no IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.loan_payment_date IS E'!N??????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.loan_status IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.old_interest_arrear IS E'!N?????????????????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.pay_principal_arr IS E'!N???????????????N!!M????????????????????????????????????? ?????????????????M!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.payment_amount IS E'!N???????????N!!M??????????????????????M!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.period IS E'!N???N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.ppm_status IS E'!N?????????????N!!M????????????????????M!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.principal_balance IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.ref_loan_doc_no IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.remark IS E'!N????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.seq_no IS E'!N?????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_card_detail.status IS E'!N?????N!!MM!';
CREATE INDEX idx_card_detail_con_item_dte ON sc_lon_m_loan_card_detail (loan_contract_no, loan_payment_date, item_type_code);
CREATE INDEX idx_card_detail_item_type ON sc_lon_m_loan_card_detail (item_type_code);
CREATE INDEX idx_card_detail_loan_con_no ON sc_lon_m_loan_card_detail (loan_contract_no);
CREATE INDEX idx_card_detail_loan_pay ON sc_lon_m_loan_card_detail (loan_payment_date);
CREATE INDEX idx_card_detail_ref_doc ON sc_lon_m_loan_card_detail (ref_loan_doc_no);
CREATE INDEX idx_lon_det_finance_date ON sc_lon_m_loan_card_detail (finance_date);
CREATE INDEX idx_lon_det_interest_amout ON sc_lon_m_loan_card_detail (interest_amout);
CREATE INDEX idx_lon_det_payment_amount ON sc_lon_m_loan_card_detail (payment_amount);
ALTER TABLE sc_lon_m_loan_card_detail ADD PRIMARY KEY (loan_contract_no,seq_no);
ALTER TABLE sc_lon_m_loan_card_detail ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_lon_m_loan_card_detail ALTER COLUMN seq_no SET NOT NULL;


