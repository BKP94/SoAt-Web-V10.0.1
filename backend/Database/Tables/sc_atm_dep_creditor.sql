CREATE TABLE sc_atm_dep_creditor (
	deposit_account_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	close_status char(1) DEFAULT '0',
	approve_amount decimal(15,2) DEFAULT 0,
	withdrawable_amount decimal(15,2) DEFAULT 0,
	modify_status char(1) DEFAULT '0',
	new_send_status char(1) DEFAULT '0',
	bank_code varchar(6),
	send_last_no double precision DEFAULT 0,
	last_access_time varchar(23) DEFAULT to_char(statement_timestamp(),'DD/MM/YYYY HH24:MI:SS.MS'),
	current_account varchar(15),
	date_regis timestamp,
	send_status char(1) DEFAULT '0',
	date_approve timestamp,
	date_app_entry timestamp,
	entry_app varchar(15),
	entry_branch varchar(6),
	send_last_date timestamp,
	bank_acc_no varchar(15),
	last_access_user varchar(10),
	last_access_datetime timestamp
) ;
ALTER TABLE sc_atm_dep_creditor ADD PRIMARY KEY (deposit_account_no,seq_no);


