CREATE TABLE sc_mem_m_member_crem_special (
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	debtor_code char(3),
	deptor_detail varchar(200)
) ;
ALTER TABLE sc_mem_m_member_crem_special ADD PRIMARY KEY (membership_no,seq_no);
ALTER TABLE sc_mem_m_member_crem_special ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_m_member_crem_special ALTER COLUMN seq_no SET NOT NULL;


