CREATE TABLE si_security_info (
	group_id varchar(16) NOT NULL,
	page_name varchar(30) NOT NULL,
	control_name varchar(70) NOT NULL,
	secure_status char(1)
) ;
ALTER TABLE si_security_info ADD PRIMARY KEY (group_id,page_name,control_name);
ALTER TABLE si_security_info ALTER COLUMN group_id SET NOT NULL;
ALTER TABLE si_security_info ALTER COLUMN page_name SET NOT NULL;
ALTER TABLE si_security_info ALTER COLUMN control_name SET NOT NULL;


