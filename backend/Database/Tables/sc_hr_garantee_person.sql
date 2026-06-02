CREATE TABLE sc_hr_garantee_person (
	c_id char(15),
	c_branchid char(2),
	c_seq double precision,
	c_garantee_name varchar(120),
	c_garantee_birthday timestamp,
	c_postion varchar(150),
	c_part_work varchar(150),
	c_garantee_amount decimal(15,2),
	c_relationship varchar(150),
	c_date_end_garantee timestamp,
	c_garantee_address varchar(300),
	c_phone_garantee varchar(60),
	c_marrystatus varchar(15),
	c_marry_name varchar(120),
	entry_id varchar(15),
	entry_date timestamp,
	c_opdate timestamp,
	c_status char(1),
	c_paystatus char(1),
	c_month double precision,
	c_year double precision
) ;


