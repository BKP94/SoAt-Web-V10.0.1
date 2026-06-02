CREATE TABLE sc_crm_mem_manage_dead (
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	member_name varchar(100),
	member_surname varchar(250),
	address_no varchar(50),
	mooban varchar(100),
	moo varchar(50),
	road varchar(50),
	soi varchar(50),
	tambol varchar(50),
	district_code varchar(6) DEFAULT '00',
	province_code varchar(6) DEFAULT '00',
	postcode varchar(5),
	telephone varchar(50)
) ;
ALTER TABLE sc_crm_mem_manage_dead ADD PRIMARY KEY (membership_no,seq_no);


