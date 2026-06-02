CREATE TABLE sc_mem_m_member_cremation_round (
	seq_no double precision NOT NULL,
	crem_type varchar(6) NOT NULL,
	crem_round varchar(6),
	crem_special char(1)
) ;
ALTER TABLE sc_mem_m_member_cremation_round ADD PRIMARY KEY (seq_no,crem_type);
ALTER TABLE sc_mem_m_member_cremation_round ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_mem_m_member_cremation_round ALTER COLUMN crem_type SET NOT NULL;


