CREATE TABLE sc_hr_off_member_ot_desc (
	official_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	ot_desc varchar(250),
	cancel_status char(1) DEFAULT '0'
) ;
ALTER TABLE sc_hr_off_member_ot_desc ADD PRIMARY KEY (official_no,seq_no);
ALTER TABLE sc_hr_off_member_ot_desc ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_member_ot_desc ALTER COLUMN seq_no SET NOT NULL;


