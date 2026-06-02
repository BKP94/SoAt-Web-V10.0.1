CREATE TABLE sc_mem_m_member_crem_type (
	crem_type varchar(6) NOT NULL,
	crem_name_shot varchar(500),
	crem_name_full varchar(100),
	deposit_account_no varchar(15),
	bonus_amount decimal(15,2),
	account_id varchar(8),
	default_cost decimal(15,2) DEFAULT (0)
) ;
ALTER TABLE sc_mem_m_member_crem_type ADD PRIMARY KEY (crem_type);
ALTER TABLE sc_mem_m_member_crem_type ALTER COLUMN crem_type SET NOT NULL;


