CREATE TABLE sc_cls_confirm_mem_07 (
	confirm_date timestamp NOT NULL,
	membership_no varchar(15) NOT NULL,
	member_group_no varchar(15),
	salary_amount decimal(15,2),
	member_fullname varchar(100),
	member_status_code char(1)
) ;
ALTER TABLE sc_cls_confirm_mem_07 ADD PRIMARY KEY (confirm_date,membership_no);
ALTER TABLE sc_cls_confirm_mem_07 ALTER COLUMN confirm_date SET NOT NULL;
ALTER TABLE sc_cls_confirm_mem_07 ALTER COLUMN membership_no SET NOT NULL;


