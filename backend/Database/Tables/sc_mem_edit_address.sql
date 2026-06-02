CREATE TABLE sc_mem_edit_address (
	membership_no varchar(15) NOT NULL,
	address_type char(1) NOT NULL DEFAULT '0',
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	operate_date timestamp NOT NULL,
	pre_address_no varchar(100),
	pre_moo varchar(50),
	pre_road varchar(50),
	pre_soi varchar(50),
	pre_tambol varchar(50),
	pre_district_code varchar(6) DEFAULT '00',
	pre_province_code varchar(6) DEFAULT '00',
	pre_postcode varchar(10),
	pre_telephone varchar(50),
	pre_mooban varchar(100),
	address_no varchar(100),
	moo varchar(50),
	road varchar(50),
	soi varchar(50),
	tambol varchar(50),
	district_code varchar(6) DEFAULT '00',
	province_code varchar(6) DEFAULT '00',
	postcode varchar(10),
	telephone varchar(50),
	mooban varchar(100)
) ;
ALTER TABLE sc_mem_edit_address ADD PRIMARY KEY (membership_no,address_type,entry_date);
ALTER TABLE sc_mem_edit_address ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_edit_address ALTER COLUMN address_type SET NOT NULL;
ALTER TABLE sc_mem_edit_address ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_mem_edit_address ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_mem_edit_address ALTER COLUMN operate_date SET NOT NULL;


