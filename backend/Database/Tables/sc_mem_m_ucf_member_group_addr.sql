CREATE TABLE sc_mem_m_ucf_member_group_addr (
	member_group_no varchar(15) NOT NULL,
	address_no varchar(50),
	moo varchar(50),
	road varchar(50),
	soi varchar(50),
	tambol varchar(50),
	district_code varchar(6) DEFAULT '00',
	province_code varchar(6) DEFAULT '00',
	postcode varchar(5),
	telephone varchar(50),
	mooban varchar(100)
) ;
ALTER TABLE sc_mem_m_ucf_member_group_addr ADD PRIMARY KEY (member_group_no);


