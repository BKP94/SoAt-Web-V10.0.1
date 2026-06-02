CREATE TABLE sc_hr_off_member_work_coll (
	official_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	coll_desc varchar(50),
	coll_ref varchar(50),
	coll_type char(1) DEFAULT '0',
	coll_birthday timestamp,
	coll_postion varchar(150),
	coll_part_work varchar(150),
	coll_amount decimal(15,2),
	coll_relationship varchar(150),
	coll_date_begin timestamp,
	coll_date_end timestamp,
	coll_address varchar(255),
	coll_telephone varchar(60),
	coll_marriage_status char(1),
	coll_spouse_name varchar(255),
	coll_status char(1)
) ;
ALTER TABLE sc_hr_off_member_work_coll ADD PRIMARY KEY (official_no,seq_no);
ALTER TABLE sc_hr_off_member_work_coll ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_member_work_coll ALTER COLUMN seq_no SET NOT NULL;


