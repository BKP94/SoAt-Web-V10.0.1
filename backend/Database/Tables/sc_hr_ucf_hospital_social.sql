CREATE TABLE sc_hr_ucf_hospital_social (
	hopital_social_id varchar(6) NOT NULL,
	hopital_desc varchar(100)
) ;
ALTER TABLE sc_hr_ucf_hospital_social ADD PRIMARY KEY (hopital_social_id);
ALTER TABLE sc_hr_ucf_hospital_social ALTER COLUMN hopital_social_id SET NOT NULL;


