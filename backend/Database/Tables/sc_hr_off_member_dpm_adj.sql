CREATE TABLE sc_hr_off_member_dpm_adj (
	official_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	department_old varchar(6),
	department_new varchar(6),
	operate_date timestamp,
	entry_id varchar(16),
	entry_date timestamp,
	entry_branch varchar(6),
	entry_clientid varchar(30)
) ;
ALTER TABLE sc_hr_off_member_dpm_adj ADD PRIMARY KEY (official_no,seq_no);
ALTER TABLE sc_hr_off_member_dpm_adj ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_member_dpm_adj ALTER COLUMN seq_no SET NOT NULL;


