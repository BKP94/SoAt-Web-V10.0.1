CREATE TABLE sc_hr_off_member_resign_req (
	requestment_no varchar(15) NOT NULL DEFAULT '<NEW>',
	official_no varchar(15),
	resign_date timestamp,
	resign_code varchar(6) DEFAULT '00',
	approve_status char(1) DEFAULT '2',
	cancel_status char(1) DEFAULT '0',
	approve_date timestamp,
	approve_id varchar(16),
	remark_desc varchar(100),
	entry_id varchar(16),
	entry_date timestamp,
	entry_branch varchar(6),
	entry_clientid varchar(30),
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_branch varchar(6)
) ;
ALTER TABLE sc_hr_off_member_resign_req ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_hr_off_member_resign_req ALTER COLUMN requestment_no SET NOT NULL;


