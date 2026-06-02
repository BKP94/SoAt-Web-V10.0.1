CREATE TABLE sc_law_land_appraisal_head (
	prosec_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	tidin varchar(15),
	building varchar(50),
	item_code double precision NOT NULL DEFAULT 0
) ;
ALTER TABLE sc_law_land_appraisal_head ADD PRIMARY KEY (prosec_no,item_code);
ALTER TABLE sc_law_land_appraisal_head ALTER COLUMN prosec_no SET NOT NULL;
ALTER TABLE sc_law_land_appraisal_head ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_law_land_appraisal_head ALTER COLUMN item_code SET NOT NULL;


