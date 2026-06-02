CREATE TABLE sc_hr_ucf_committee_position (
	committee_position varchar(6) NOT NULL,
	committee_desc varchar(100)
) ;
ALTER TABLE sc_hr_ucf_committee_position ADD PRIMARY KEY (committee_position);
ALTER TABLE sc_hr_ucf_committee_position ALTER COLUMN committee_position SET NOT NULL;


