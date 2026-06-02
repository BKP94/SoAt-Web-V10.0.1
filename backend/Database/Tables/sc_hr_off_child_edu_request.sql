CREATE TABLE sc_hr_off_child_edu_request (
	requestment_no varchar(15) NOT NULL DEFAULT '<NEW>',
	official_no varchar(3),
	operate_date timestamp,
	pay_amount decimal(15,2) DEFAULT 0,
	ref_seq_no double precision DEFAULT 0,
	ref_description varchar(100),
	edu_level varchar(5),
	remark_desc varchar(100),
	cancel_status char(1) DEFAULT '0',
	approve_status char(1) DEFAULT '2',
	approve_id varchar(16),
	approve_date timestamp,
	entry_id varchar(16),
	entry_date timestamp,
	entry_branch varchar(6),
	entry_clientid varchar(30),
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_branch varchar(6)
) ;
COMMENT ON TABLE sc_hr_off_child_edu_request IS E'!NN!';
ALTER TABLE sc_hr_off_child_edu_request ADD PRIMARY KEY (requestment_no);


