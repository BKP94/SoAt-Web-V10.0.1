CREATE TABLE sc_hr_off_member_souvenir (
	official_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	souvenir_type varchar(6) DEFAULT '00',
	paid_date timestamp
) ;
ALTER TABLE sc_hr_off_member_souvenir ADD PRIMARY KEY (official_no,seq_no);
ALTER TABLE sc_hr_off_member_souvenir ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_member_souvenir ALTER COLUMN seq_no SET NOT NULL;


