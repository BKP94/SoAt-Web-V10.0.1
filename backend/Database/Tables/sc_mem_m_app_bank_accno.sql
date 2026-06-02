CREATE TABLE sc_mem_m_app_bank_accno (
	application_form_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	bank_id varchar(6),
	bank_acc_no varchar(15),
	paid_loan char(1) DEFAULT '0',
	paid_dividen char(1) DEFAULT '0',
	share_withdraw char(1) DEFAULT '0',
	atm_lon char(1) DEFAULT '0',
	atm_dep char(1) DEFAULT '0',
	bank_branch_id varchar(6),
	mustcoll_loan char(1) DEFAULT '0',
	paid_salary char(1) DEFAULT '0',
	paid_agent char(1) DEFAULT '0',
	keep_monthly char(1) DEFAULT '0'
) ;
ALTER TABLE sc_mem_m_app_bank_accno ADD PRIMARY KEY (application_form_no,seq_no);


