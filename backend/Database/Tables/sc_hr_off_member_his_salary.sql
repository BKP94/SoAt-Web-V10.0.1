CREATE TABLE sc_hr_off_member_his_salary (
	official_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	salary_amount decimal(15,2) DEFAULT 0,
	operate_date timestamp,
	description_sal varchar(100),
	ref_docno varchar(100),
	sal_level double precision DEFAULT 0,
	year_salary_adj double precision DEFAULT 0,
	old_salary_amount decimal(15,2) DEFAULT 0,
	new_salary_amount decimal(15,2) DEFAULT 0,
	sasom_amount decimal(15,2) DEFAULT 0,
	insure_amount decimal(15,2) DEFAULT 0,
	entry_id varchar(16),
	entry_date timestamp,
	entry_branch varchar(6),
	entry_clientid varchar(30)
) ;
ALTER TABLE sc_hr_off_member_his_salary ADD PRIMARY KEY (official_no,seq_no);
ALTER TABLE sc_hr_off_member_his_salary ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_member_his_salary ALTER COLUMN seq_no SET NOT NULL;


