CREATE TABLE sc_wef_req_edu (
	requestment_no varchar(15) NOT NULL,
	edu_type varchar(6),
	class_type varchar(6),
	child_id_card varchar(15),
	date_of_birth timestamp,
	pre_name varchar(6),
	child_name varchar(100),
	child_surname varchar(100),
	edu_school varchar(100),
	edu_graed decimal(15,2),
	remark varchar(200),
	receive_name varchar(200),
	money_type_id varchar(6),
	bank_id varchar(6),
	bank_acc_no varchar(15),
	num_gpa decimal(5,2),
	num_rec integer,
	num_random integer
) ;
ALTER TABLE sc_wef_req_edu ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_wef_req_edu ALTER COLUMN requestment_no SET NOT NULL;


