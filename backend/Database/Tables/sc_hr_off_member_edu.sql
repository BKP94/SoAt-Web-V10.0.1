CREATE TABLE sc_hr_off_member_edu (
	official_no varchar(15) NOT NULL,
	degree_in varchar(6),
	degree_in_program varchar(250),
	degree_in_academy varchar(250),
	degree_current varchar(6),
	degree_current_program varchar(250),
	degree_current_academy varchar(250)
) ;
ALTER TABLE sc_hr_off_member_edu ADD PRIMARY KEY (official_no);
ALTER TABLE sc_hr_off_member_edu ALTER COLUMN official_no SET NOT NULL;


