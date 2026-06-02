CREATE TABLE sc_hr_relation_tb_human (
	c_id char(15),
	c_branchid char(2),
	c_seq double precision,
	c_relation_name varchar(120),
	c_relation_old decimal(15,2),
	c_relation_occupation varchar(200),
	c_relation_office_address varchar(300),
	c_relation_draw_gain varchar(100),
	entry_id varchar(15),
	entry_date timestamp,
	c_can_draw char(1)
) ;


