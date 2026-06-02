CREATE TABLE sc_hr_off_member_working_late (
	official_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	operate_date timestamp,
	entry_id varchar(16),
	entry_date timestamp,
	entry_branch varchar(6),
	entry_clientid varchar(30),
	cancel_status char(1) DEFAULT '0',
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_branch varchar(6)
) ;
ALTER TABLE sc_hr_off_member_working_late ADD PRIMARY KEY (official_no,seq_no);
ALTER TABLE sc_hr_off_member_working_late ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_member_working_late ALTER COLUMN seq_no SET NOT NULL;


