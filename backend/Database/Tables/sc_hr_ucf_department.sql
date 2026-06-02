CREATE TABLE sc_hr_ucf_department (
	department_id varchar(6) NOT NULL,
	department_desc varchar(100),
	sort_order bigint DEFAULT 0
) ;
ALTER TABLE sc_hr_ucf_department ADD PRIMARY KEY (department_id);
ALTER TABLE sc_hr_ucf_department ALTER COLUMN department_id SET NOT NULL;


