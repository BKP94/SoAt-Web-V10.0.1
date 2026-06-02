CREATE TABLE sc_mem_m_capital_pay (
	account_year double precision NOT NULL,
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	group_pay_code varchar(3),
	item_amount decimal(15,2) DEFAULT 0,
	bank_code varchar(6),
	bank_branch varchar(6),
	bank_acc_no varchar(15),
	post_status char(1) DEFAULT '0',
	post_date timestamp,
	post_entry_time timestamp,
	post_entry_id char(16),
	post_entry_pc char(3),
	post_entry_br varchar(6),
	post_refno char(15),
	item_div decimal(15,2) DEFAULT 0,
	item_avr decimal(15,2) DEFAULT 0,
	item_bf_div decimal(15,2) DEFAULT 0,
	item_bf_avr decimal(15,2) DEFAULT 0,
	paid_dividen decimal(15,2) DEFAULT 0,
	paid_average decimal(15,2) DEFAULT 0,
	entry_date timestamp,
	entry_id varchar(16),
	entry_br varchar(6),
	crem_membership_no varchar(15),
	crem_seq_no integer,
	crem_crem_type varchar(6),
	post_to_fin char(1) DEFAULT '0',
	loan_contract_no varchar(15),
	isp_type_code varchar(5),
	balance decimal(15,2) DEFAULT 0,
	ext_status char(1) DEFAULT '0',
	keeping_type_code char(5),
	principal_amount decimal(15,2) DEFAULT 0,
	interest_amount decimal(15,2) DEFAULT 0,
	interest_to timestamp,
	post_amount decimal(15,2) DEFAULT 0,
	trans_bank_status char(1) DEFAULT '0',
	comfirm_data char(1) DEFAULT '0',
	mrt_amount decimal(15,2) DEFAULT 0,
	pay_desc varchar(100)
) ;
ALTER TABLE sc_mem_m_capital_pay ADD PRIMARY KEY (account_year,membership_no,seq_no);
ALTER TABLE sc_mem_m_capital_pay ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_mem_m_capital_pay ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_m_capital_pay ALTER COLUMN seq_no SET NOT NULL;


