CREATE TABLE sc_security_permit_ucf (
	applications varchar(35) NOT NULL,
	security_code varchar(6) NOT NULL,
	code_desc varchar(100),
	priority smallint DEFAULT 0,
	active_status char(1) DEFAULT '0',
	autherize_mode char(1) DEFAULT 'A',
	configure_able char(1) DEFAULT '0',
	autherize_money decimal(15,2)
) ;
COMMENT ON TABLE sc_security_permit_ucf IS E'!N???????????? - ????????????????????N!!MM!';
COMMENT ON COLUMN sc_security_permit_ucf.active_status IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_security_permit_ucf.applications IS E'!N????????N!!MM!';
COMMENT ON COLUMN sc_security_permit_ucf.code_desc IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_security_permit_ucf.priority IS E'!N?????N!!MM!';
COMMENT ON COLUMN sc_security_permit_ucf.security_code IS E'!N????N!!MM!';
CREATE INDEX idx_sec_permit_ucf_active_stat ON sc_security_permit_ucf (active_status);
CREATE INDEX idx_sec_permit_ucf_application ON sc_security_permit_ucf (applications);
ALTER TABLE sc_security_permit_ucf ADD PRIMARY KEY (applications,security_code);


