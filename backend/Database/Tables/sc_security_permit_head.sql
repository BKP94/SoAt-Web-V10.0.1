CREATE TABLE sc_security_permit_head (
	request_id varchar(16) NOT NULL,
	request_group numeric(38) NOT NULL DEFAULT 0,
	request_client varchar(15),
	request_date timestamp,
	request_branch varchar(6),
	request_remark varchar(250),
	permit_result char(1),
	permit_id varchar(16),
	permit_client varchar(15),
	permit_date timestamp,
	permit_branch varchar(6),
	specify_permit_id varchar(16),
	sessionid numeric(38) DEFAULT 0,
	request_amount decimal(15,2),
	ref_no varchar(15)
) ;
COMMENT ON TABLE sc_security_permit_head IS E'!NN!';
ALTER TABLE sc_security_permit_head ADD PRIMARY KEY (request_id,request_group);


