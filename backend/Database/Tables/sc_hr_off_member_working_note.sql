CREATE TABLE sc_hr_off_member_working_note (
	official_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	work_type varchar(6) DEFAULT '00',
	remark_desc varchar(200),
	entry_date timestamp,
	note_year varchar(6),
	grade varchar(6),
	point decimal(15,2)
) ;
ALTER TABLE sc_hr_off_member_working_note ADD PRIMARY KEY (official_no,seq_no);
ALTER TABLE sc_hr_off_member_working_note ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_member_working_note ALTER COLUMN seq_no SET NOT NULL;


