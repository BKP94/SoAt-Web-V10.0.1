CREATE TABLE sc_law_land_appraisal_pic (
	prosec_no varchar(15) NOT NULL,
	type_pic char(1) NOT NULL DEFAULT '0',
	law_pic bytea
) ;
ALTER TABLE sc_law_land_appraisal_pic ADD PRIMARY KEY (prosec_no,type_pic);
ALTER TABLE sc_law_land_appraisal_pic ALTER COLUMN prosec_no SET NOT NULL;
ALTER TABLE sc_law_land_appraisal_pic ALTER COLUMN type_pic SET NOT NULL;


