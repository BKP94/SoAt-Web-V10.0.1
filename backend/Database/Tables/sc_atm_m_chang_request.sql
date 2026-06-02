CREATE TABLE sc_atm_m_chang_request (
	document_no varchar(15) NOT NULL DEFAULT '<NEW>',
	operate_date timestamp,
	membership_no varchar(15),
	approve_status char(1) DEFAULT '2',
	entry_id varchar(16),
	entry_date timestamp,
	entry_br varchar(6),
	entry_pc varchar(15),
	approve_id varchar(16),
	approve_date timestamp,
	approve_br varchar(6),
	approve_pc varchar(3),
	remark varchar(100),
	current_account char(15),
	bank_code char(6),
	modify_status char(1)
) ;
ALTER TABLE sc_atm_m_chang_request ADD PRIMARY KEY (document_no);


