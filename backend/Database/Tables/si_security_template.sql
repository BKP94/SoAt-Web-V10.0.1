CREATE TABLE si_security_template (
	page_name varchar(30) NOT NULL,
	control_name varchar(70) NOT NULL,
	control_desc varchar(50),
	control_type varchar(30),
	parent_name varchar(70)
) ;
ALTER TABLE si_security_template ADD PRIMARY KEY (page_name,control_name);
ALTER TABLE si_security_template ALTER COLUMN page_name SET NOT NULL;
ALTER TABLE si_security_template ALTER COLUMN control_name SET NOT NULL;


