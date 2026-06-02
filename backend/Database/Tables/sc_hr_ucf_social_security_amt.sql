CREATE TABLE sc_hr_ucf_social_security_amt (
	seq_no double precision NOT NULL DEFAULT 0,
	column_names varchar(100),
	column_desc varchar(100),
	kep_satus char(1) DEFAULT '0'
) ;
ALTER TABLE sc_hr_ucf_social_security_amt ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_hr_ucf_social_security_amt ALTER COLUMN seq_no SET NOT NULL;


