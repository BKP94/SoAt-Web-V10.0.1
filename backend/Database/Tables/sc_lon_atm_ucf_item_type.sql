CREATE TABLE sc_lon_atm_ucf_item_type (
	item_type varchar(3) NOT NULL,
	item_desc varchar(35),
	potocol_type varchar(6) DEFAULT '00'
) ;
ALTER TABLE sc_lon_atm_ucf_item_type ALTER COLUMN item_type SET NOT NULL;


