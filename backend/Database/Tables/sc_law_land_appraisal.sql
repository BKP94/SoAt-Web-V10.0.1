CREATE TABLE sc_law_land_appraisal (
	prosec_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	item_type_code char(1) NOT NULL DEFAULT '0',
	area double precision DEFAULT 0,
	space double precision DEFAULT 0,
	price_per_unit double precision DEFAULT 0,
	price_per_meter double precision DEFAULT 0,
	item_code double precision NOT NULL DEFAULT 0
) ;
ALTER TABLE sc_law_land_appraisal ADD PRIMARY KEY (prosec_no,seq_no,item_code);
ALTER TABLE sc_law_land_appraisal ALTER COLUMN prosec_no SET NOT NULL;
ALTER TABLE sc_law_land_appraisal ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_law_land_appraisal ALTER COLUMN item_type_code SET NOT NULL;
ALTER TABLE sc_law_land_appraisal ALTER COLUMN item_code SET NOT NULL;


