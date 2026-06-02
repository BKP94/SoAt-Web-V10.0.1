CREATE TABLE sc_hr_training_tb_human (
	c_id char(15),
	c_branchid char(2),
	c_seq double precision,
	c_course_training varchar(150),
	c_place_training varchar(100),
	c_org_build_training varchar(100),
	c_date_start_training timestamp,
	c_date_end_training timestamp,
	c_pay_training decimal(15,2),
	entry_id varchar(15),
	entry_date timestamp,
	c_pay_vehicle decimal(15,2),
	c_pay_reward decimal(15,2)
) ;


