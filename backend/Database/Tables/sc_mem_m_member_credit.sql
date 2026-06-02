CREATE TABLE sc_mem_m_member_credit (
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	credit_code varchar(6) DEFAULT '00',
	credit_desc varchar(200),
	approve_date timestamp,
	approve_userid varchar(16),
	approve_branch varchar(6),
	approve_cilent varchar(50),
	lastedit_date timestamp,
	lastedit_userid varchar(16),
	lastedit_branch varchar(6),
	lastedit_cilent varchar(50)
) ;
ALTER TABLE sc_mem_m_member_credit ADD PRIMARY KEY (membership_no,seq_no);
ALTER TABLE sc_mem_m_member_credit ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_m_member_credit ALTER COLUMN seq_no SET NOT NULL;


