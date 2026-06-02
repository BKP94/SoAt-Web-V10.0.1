CREATE TABLE sc_hr_off_member_parent (
	official_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	parent_type varchar(6) DEFAULT '00',
	prename_code varchar(6),
	parent_name varchar(50),
	parent_surname varchar(50),
	birth_date timestamp,
	alive_status char(1) DEFAULT '0',
	id_card varchar(15),
	occupation varchar(50),
	office_address varchar(250)
) ;
ALTER TABLE sc_hr_off_member_parent ADD PRIMARY KEY (official_no,seq_no);
ALTER TABLE sc_hr_off_member_parent ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_member_parent ALTER COLUMN seq_no SET NOT NULL;


