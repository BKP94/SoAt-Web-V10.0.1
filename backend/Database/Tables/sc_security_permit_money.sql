CREATE TABLE sc_security_permit_money (
	security_code char(6) NOT NULL,
	group_id varchar(16) NOT NULL,
	autherize_money decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_security_permit_money ADD PRIMARY KEY (security_code,group_id);
ALTER TABLE sc_security_permit_money ALTER COLUMN security_code SET NOT NULL;
ALTER TABLE sc_security_permit_money ALTER COLUMN group_id SET NOT NULL;


