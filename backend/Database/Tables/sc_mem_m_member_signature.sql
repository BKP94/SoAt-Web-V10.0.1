CREATE TABLE sc_mem_m_member_signature (
	membership_no varchar(15) NOT NULL,
	mem_signature bytea
) ;
COMMENT ON TABLE sc_mem_m_member_signature IS E'!NN!';
ALTER TABLE sc_mem_m_member_signature ADD PRIMARY KEY (membership_no);


