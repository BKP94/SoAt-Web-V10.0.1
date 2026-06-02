CREATE TABLE sc_amnat_grade_ucf_chg (
	chg_code varchar(6) NOT NULL,
	chg_desc varchar(100)
) ;
ALTER TABLE sc_amnat_grade_ucf_chg ADD PRIMARY KEY (chg_code);
ALTER TABLE sc_amnat_grade_ucf_chg ALTER COLUMN chg_code SET NOT NULL;


