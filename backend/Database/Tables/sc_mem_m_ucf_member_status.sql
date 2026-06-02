CREATE TABLE sc_mem_m_ucf_member_status (
	member_status_code char(1) NOT NULL,
	member_status_name varchar(100),
	member_flag double precision,
	sumbalance_flag double precision,
	keeping_flag double precision,
	dividend_flag double precision,
	average_flag double precision
) ;
COMMENT ON TABLE sc_mem_m_ucf_member_status IS E'!NN!';
ALTER TABLE sc_mem_m_ucf_member_status ADD PRIMARY KEY (member_status_code);


