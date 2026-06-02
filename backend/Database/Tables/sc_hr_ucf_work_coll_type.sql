CREATE TABLE sc_hr_ucf_work_coll_type (
	coll_type varchar(6) NOT NULL DEFAULT '0',
	coll_desc varchar(50)
) ;
ALTER TABLE sc_hr_ucf_work_coll_type ADD PRIMARY KEY (coll_type);
ALTER TABLE sc_hr_ucf_work_coll_type ALTER COLUMN coll_type SET NOT NULL;


