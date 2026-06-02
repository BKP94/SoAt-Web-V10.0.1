CREATE TABLE sc_security_permit_detail (
	request_id varchar(16) NOT NULL,
	request_group numeric(38) NOT NULL DEFAULT 0,
	seq_no numeric(38) NOT NULL DEFAULT 0,
	applications varchar(35),
	security_code varchar(6),
	security_remark varchar(100)
) ;
COMMENT ON TABLE sc_security_permit_detail IS E'!NN!';
ALTER TABLE sc_security_permit_detail ADD PRIMARY KEY (request_id,request_group,seq_no);


