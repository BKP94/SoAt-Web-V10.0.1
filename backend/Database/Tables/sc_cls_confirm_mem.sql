CREATE TABLE sc_cls_confirm_mem (
	confirm_date timestamp NOT NULL,
	membership_no varchar(15) NOT NULL,
	member_group_no varchar(15),
	salary_amount decimal(15,2),
	member_fullname varchar(100),
	member_status_code char(1),
	mem_type varchar(6)
) ;
ALTER TABLE sc_cls_confirm_mem ADD PRIMARY KEY (confirm_date,membership_no);


