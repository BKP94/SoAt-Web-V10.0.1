CREATE TABLE sc_mem_m_ucf_member_cremation (
	crem_type char(2) NOT NULL,
	crem_name varchar(200),
	deposit_account_no varchar(15),
	full_name varchar(200),
	crem_address varchar(200),
	cal_loan char(1) DEFAULT (0),
	default_cost decimal(15,2) DEFAULT (0)
) ;
ALTER TABLE sc_mem_m_ucf_member_cremation ADD PRIMARY KEY (crem_type);
ALTER TABLE sc_mem_m_ucf_member_cremation ALTER COLUMN crem_type SET NOT NULL;


