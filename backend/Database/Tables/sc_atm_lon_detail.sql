CREATE TABLE sc_atm_lon_detail (
	loan_contract_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	operate_date timestamp,
	item_type varchar(3),
	prin_amount decimal(15,2) DEFAULT 0,
	fee_amount decimal(15,2) DEFAULT 0,
	loan_balance decimal(15,2) DEFAULT 0,
	approve_amount decimal(15,2) DEFAULT 0,
	ref_sys_lon double precision DEFAULT 0,
	entry_id varchar(16),
	entry_date timestamp,
	entry_br varchar(6),
	entry_pc varchar(3),
	transaction_no varchar(8),
	terminal_lacation varchar(15),
	remark varchar(250),
	trans_datetime timestamp
) ;
ALTER TABLE sc_atm_lon_detail ADD PRIMARY KEY (loan_contract_no,seq_no);


