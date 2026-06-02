CREATE TABLE si_security_group (
	group_id varchar(16) NOT NULL,
	group_desc varchar(30),
	priority double precision,
	d_create timestamp DEFAULT statement_timestamp(),
	d_change timestamp DEFAULT statement_timestamp(),
	c_status varchar(1),
	autherize_money decimal(15,2) DEFAULT 0.00
) ;
ALTER TABLE si_security_group ADD PRIMARY KEY (group_id);
ALTER TABLE si_security_group ALTER COLUMN group_id SET NOT NULL;


