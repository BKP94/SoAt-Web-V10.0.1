CREATE TABLE sc_hr_off_member_position_adj (
	official_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	official_position_old varchar(6),
	official_position_new varchar(6),
	operate_date timestamp,
	entry_id varchar(16),
	entry_date timestamp,
	entry_branch varchar(6),
	entry_clientid varchar(30),
	department_description varchar(200),
	ref_docno varchar(100),
	adj_year integer,
	adj_level varchar(50),
	adj_position varchar(50),
	adj_refer varchar(50),
	adj_remark varchar(50)
) ;
ALTER TABLE sc_hr_off_member_position_adj ADD PRIMARY KEY (official_no,seq_no);
ALTER TABLE sc_hr_off_member_position_adj ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_member_position_adj ALTER COLUMN seq_no SET NOT NULL;


