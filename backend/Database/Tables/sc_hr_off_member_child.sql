CREATE TABLE sc_hr_off_member_child (
	official_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	prename_code varchar(6),
	child_name varchar(50),
	child_surname varchar(50),
	birth_date timestamp,
	child_sex char(1) DEFAULT '0',
	edu_level varchar(6),
	alive_status char(1) DEFAULT '0',
	working_status char(1) DEFAULT '0',
	child_type char(1) DEFAULT '0',
	id_card varchar(15)
) ;
ALTER TABLE sc_hr_off_member_child ADD PRIMARY KEY (official_no,seq_no);
ALTER TABLE sc_hr_off_member_child ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_member_child ALTER COLUMN seq_no SET NOT NULL;


