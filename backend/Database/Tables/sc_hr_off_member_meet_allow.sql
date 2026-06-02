CREATE TABLE sc_hr_off_member_meet_allow (
	seq_no integer NOT NULL DEFAULT 0,
	official_no varchar(15) NOT NULL,
	meeting_detail varchar(250),
	meeting_amount decimal(15,2),
	paid_date timestamp
) ;
ALTER TABLE sc_hr_off_member_meet_allow ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_hr_off_member_meet_allow ALTER COLUMN official_no SET NOT NULL;


