CREATE TABLE sc_crem_reg_control (
	crem_code varchar(10) NOT NULL,
	receive_fee_new char(1),
	receive_fee_year char(1)
) ;
ALTER TABLE sc_crem_reg_control ADD PRIMARY KEY (crem_code);
ALTER TABLE sc_crem_reg_control ALTER COLUMN crem_code SET NOT NULL;


