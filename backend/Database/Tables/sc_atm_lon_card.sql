CREATE TABLE sc_atm_lon_card (
	loan_contract_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	bank_code varchar(6),
	new_send_status char(1) DEFAULT '0',
	balance_send decimal(15,2) DEFAULT 0,
	modify_status char(1) DEFAULT '0',
	send_last_no double precision DEFAULT 0,
	close_status char(1) DEFAULT '0',
	press_amount_real decimal(15,2) DEFAULT 0,
	current_account varchar(15),
	date_regis timestamp,
	send_status char(1) DEFAULT '0',
	date_approve timestamp,
	date_app_entry timestamp,
	entry_app varchar(15),
	entry_branch varchar(6),
	bank_acc_no varchar(10),
	send_last_date timestamp,
	last_access_id varchar(6) DEFAULT '00',
	last_access_date timestamp,
	temp_mod char(1),
	temp_cls char(1),
	temp_memno varchar(15),
	entry_id varchar(16),
	entry_date timestamp,
	remark varchar(250)
) ;
ALTER TABLE sc_atm_lon_card ADD PRIMARY KEY (loan_contract_no,seq_no);
ALTER TABLE sc_atm_lon_card ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_atm_lon_card ALTER COLUMN seq_no SET NOT NULL;


