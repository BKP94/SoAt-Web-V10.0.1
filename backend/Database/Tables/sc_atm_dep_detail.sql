CREATE TABLE sc_atm_dep_detail (
	deposit_account_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	operate_date timestamp,
	item_type varchar(3),
	prin_amount decimal(15,2) DEFAULT 0,
	fee_amount decimal(15,2) DEFAULT 0,
	dep_balance decimal(15,2) DEFAULT 0,
	approve_amount decimal(15,2) DEFAULT 0,
	ref_sys_dep double precision DEFAULT 0,
	entry_id varchar(16),
	entry_date timestamp,
	entry_br varchar(6),
	entry_pc varchar(3),
	dep_transaction varchar(6),
	transaction_no varchar(15)
) ;
ALTER TABLE sc_atm_dep_detail ADD PRIMARY KEY (deposit_account_no,seq_no);


