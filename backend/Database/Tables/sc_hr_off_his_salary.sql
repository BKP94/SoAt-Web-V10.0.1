CREATE TABLE sc_hr_off_his_salary (
	seq_no double precision NOT NULL,
	official_no varchar(50),
	opporate_date timestamp,
	salary decimal(15,2)
) ;
ALTER TABLE sc_hr_off_his_salary ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_hr_off_his_salary ALTER COLUMN seq_no SET NOT NULL;


