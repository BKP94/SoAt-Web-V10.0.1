CREATE TABLE sc_mem_m_member_picture (
	membership_no varchar(15) NOT NULL,
	mem_picture bytea
) ;
COMMENT ON TABLE sc_mem_m_member_picture IS E'!NN!';
ALTER TABLE sc_mem_m_member_picture ADD PRIMARY KEY (membership_no);


