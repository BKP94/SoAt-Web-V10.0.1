CREATE TABLE sc_hr_off_member_leave_req (
	requestment_no varchar(15) NOT NULL DEFAULT '<NEW>',
	official_no varchar(15),
	operate_date timestamp,
	leave_type varchar(6) DEFAULT '00',
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
	cancel_branch varchar(6),
	leave_group_code varchar(6) DEFAULT '00',
	time_begin timestamp,
	time_end timestamp,
	leave_date_from timestamp,
	leave_date_to timestamp,
	assign_name varchar(100),
	objective_des varchar(100),
	assign_tel varchar(100),
	leave_day decimal(6,2),
	late_time timestamp
) ;
ALTER TABLE sc_hr_off_member_leave_req ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_hr_off_member_leave_req ALTER COLUMN requestment_no SET NOT NULL;


