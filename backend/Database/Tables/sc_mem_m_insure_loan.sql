CREATE TABLE sc_mem_m_insure_loan (
	insurance_type varchar(5),
	insurance_no varchar(15) NOT NULL DEFAULT '<NEW>',
	req_date timestamp,
	membership_no varchar(15),
	member_group_no varchar(15),
	loan_contract_no varchar(15),
	begining_of_contract timestamp,
	company_id varchar(15),
	ref_insurance_no varchar(50),
	protec_begin timestamp,
	protec_end timestamp,
	protec_period varchar(50),
	insurance_amount decimal(15,2) DEFAULT 0,
	company_amount decimal(15,2) DEFAULT 0,
	company_discount decimal(15,2) DEFAULT 0,
	company_real decimal(15,2) DEFAULT 0,
	remark varchar(100),
	entry_id varchar(16) NOT NULL,
	entry_date timestamp NOT NULL,
	approve_status char(1) DEFAULT '0',
	approve_id varchar(16),
	approve_date timestamp,
	cancel_status char(1) DEFAULT '0',
	cancel_id varchar(16),
	cancel_date timestamp,
	conno_new varchar(15),
	vourcher_no varchar(30),
	period_payment_backup decimal(15,2)
) ;
ALTER TABLE sc_mem_m_insure_loan ADD PRIMARY KEY (insurance_no);
ALTER TABLE sc_mem_m_insure_loan ALTER COLUMN insurance_no SET NOT NULL;
ALTER TABLE sc_mem_m_insure_loan ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_mem_m_insure_loan ALTER COLUMN entry_date SET NOT NULL;


