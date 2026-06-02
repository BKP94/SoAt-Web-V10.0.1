CREATE TABLE sc_hr_off_member_parole (
	official_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	parole varchar(100),
	parole_date timestamp
) ;
ALTER TABLE sc_hr_off_member_parole ADD PRIMARY KEY (official_no,seq_no);
ALTER TABLE sc_hr_off_member_parole ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_member_parole ALTER COLUMN seq_no SET NOT NULL;


