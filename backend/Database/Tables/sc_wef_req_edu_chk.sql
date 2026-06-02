CREATE TABLE sc_wef_req_edu_chk (
	entry_id varchar(16) NOT NULL,
	entry_date timestamp NOT NULL,
	membership_no varchar(15),
	operate_date timestamp,
	remark varchar(200),
	total_receive decimal(15,2) DEFAULT 0,
	edu_type varchar(6),
	class_type varchar(6),
	child_id_card varchar(15),
	date_of_birth timestamp,
	pre_name varchar(6),
	child_name varchar(100),
	child_surname varchar(100)
) ;
ALTER TABLE sc_wef_req_edu_chk ADD PRIMARY KEY (entry_id,entry_date);
ALTER TABLE sc_wef_req_edu_chk ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_wef_req_edu_chk ALTER COLUMN entry_date SET NOT NULL;


