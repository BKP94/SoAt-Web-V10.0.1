CREATE TABLE sc_wef_ucf_hospital (
	hospital_code varchar(6) NOT NULL,
	hospital_name varchar(100),
	sort_order integer DEFAULT 0
) ;
ALTER TABLE sc_wef_ucf_hospital ADD PRIMARY KEY (hospital_code);
ALTER TABLE sc_wef_ucf_hospital ALTER COLUMN hospital_code SET NOT NULL;


