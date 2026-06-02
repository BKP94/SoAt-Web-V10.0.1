CREATE TABLE sc_atm_m_chg_dep_det (
	membership_no varchar(15),
	document_no varchar(15) NOT NULL DEFAULT '<NEW>',
	deposit_account_no varchar(15),
	deposit_type_code varchar(6),
	principal_balace decimal(15,2),
	approve_amount_old decimal(15,2),
	approve_amount_new decimal(15,2),
	chg_status_last char(1),
	chg_status char(1),
	remark char(100),
	approve_status char(1),
	entry_date timestamp,
	entry_id char(20),
	approve_id char(10),
	approve_branch varchar(6),
	approve_date timestamp,
	last_access_user char(20),
	last_access_datetime timestamp,
	last_access_branch char(20),
	last_access_client char(20),
	bank_code varchar(6),
	seq_no double precision,
	current_account_last char(15),
	bank_code_lase char(6),
	current_account char(15)
) ;
ALTER TABLE sc_atm_m_chg_dep_det ADD PRIMARY KEY (document_no);


