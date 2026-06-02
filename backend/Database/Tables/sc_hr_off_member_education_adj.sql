CREATE TABLE sc_hr_off_member_education_adj (
	official_no varchar(5) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	edu_code_old varchar(2),
	edu_code_new varchar(2),
	edu_adj_date timestamp,
	edu_adj_year double precision,
	entry_id varchar(16),
	entry_date timestamp,
	entry_branch varchar(6),
	entry_clientid varchar(30)
) ;
ALTER TABLE sc_hr_off_member_education_adj ADD PRIMARY KEY (official_no,seq_no);


