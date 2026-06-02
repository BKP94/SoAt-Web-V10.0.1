CREATE TABLE sc_lon_ucf_salary_level (
	seq_no double precision NOT NULL,
	mem_type varchar(255),
	salary decimal(15,2),
	salary_level varchar(255),
	max_of_level varchar(255)
) ;
ALTER TABLE sc_lon_ucf_salary_level ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_lon_ucf_salary_level ALTER COLUMN seq_no SET NOT NULL;


