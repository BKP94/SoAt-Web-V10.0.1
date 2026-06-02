CREATE TABLE sc_crem_fee_control (
	crem_code varchar(10) NOT NULL,
	fee_status char(1) NOT NULL,
	year_status char(1) NOT NULL
) ;
ALTER TABLE sc_crem_fee_control ADD PRIMARY KEY (crem_code);
ALTER TABLE sc_crem_fee_control ALTER COLUMN crem_code SET NOT NULL;
ALTER TABLE sc_crem_fee_control ALTER COLUMN fee_status SET NOT NULL;
ALTER TABLE sc_crem_fee_control ALTER COLUMN year_status SET NOT NULL;


