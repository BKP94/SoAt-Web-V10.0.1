CREATE TABLE sc_mem_m_member_own_info (
	membership_no varchar(15) NOT NULL,
	from_code varchar(2),
	own_work_age double precision,
	own_member_age double precision,
	own_total_loan decimal(15,2),
	mati_detail varchar(250),
	other_saving varchar(6) DEFAULT '00',
	first_date timestamp
) ;
ALTER TABLE sc_mem_m_member_own_info ADD PRIMARY KEY (membership_no);
ALTER TABLE sc_mem_m_member_own_info ALTER COLUMN membership_no SET NOT NULL;


