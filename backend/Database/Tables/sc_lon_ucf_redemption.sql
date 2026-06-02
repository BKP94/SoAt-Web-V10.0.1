CREATE TABLE sc_lon_ucf_redemption (
	redemption_type char(1) NOT NULL DEFAULT '0',
	redemption_desc varchar(50)
) ;
ALTER TABLE sc_lon_ucf_redemption ADD PRIMARY KEY (redemption_type);
ALTER TABLE sc_lon_ucf_redemption ALTER COLUMN redemption_type SET NOT NULL;


