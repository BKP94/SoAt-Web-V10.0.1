CREATE TABLE sc_hr_off_member_leave_req_detail (
	requestment_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	leave_date_from timestamp,
	leave_date_to timestamp,
	leave_day decimal(6,2),
	leave_group_code varchar(6),
	late_status varchar(6),
	leave_early_status varchar(6)
) ;
ALTER TABLE sc_hr_off_member_leave_req_detail ADD PRIMARY KEY (requestment_no,seq_no);
ALTER TABLE sc_hr_off_member_leave_req_detail ALTER COLUMN requestment_no SET NOT NULL;
ALTER TABLE sc_hr_off_member_leave_req_detail ALTER COLUMN seq_no SET NOT NULL;


