CREATE TABLE sc_hr_off_member_spouse (
	official_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	spouse_type char(1) DEFAULT '0',
	prename_code varchar(6),
	spouse_name varchar(50),
	spouse_surname varchar(50),
	date_of_birth timestamp,
	spouse_code char(1) DEFAULT '0',
	id_card varchar(15),
	occupation varchar(50),
	spouse_telephone varchar(60)
) ;
ALTER TABLE sc_hr_off_member_spouse ADD PRIMARY KEY (official_no,seq_no);
ALTER TABLE sc_hr_off_member_spouse ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_member_spouse ALTER COLUMN seq_no SET NOT NULL;


