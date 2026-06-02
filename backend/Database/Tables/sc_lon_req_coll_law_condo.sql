CREATE TABLE sc_lon_req_coll_law_condo (
	doc_no varchar(15) NOT NULL,
	title_deed varchar(100),
	land_address_no varchar(60),
	moo varchar(50),
	road varchar(50),
	soi varchar(50),
	tambol varchar(50),
	district_code varchar(2) DEFAULT '00',
	province_code varchar(2) DEFAULT '00',
	postcode varchar(10),
	address_no varchar(60),
	floor_no varchar(60),
	building_no varchar(60),
	building_name varchar(100),
	building_gruop_no varchar(60),
	square_meter double precision DEFAULT 0,
	use_area double precision DEFAULT 0,
	use_area_percent double precision DEFAULT 0,
	appraised_value double precision DEFAULT 0,
	depreciation_type varchar(2) DEFAULT '00',
	age_no double precision DEFAULT 0,
	depreciation_percent double precision DEFAULT 0,
	depreciation_value double precision DEFAULT 0,
	remark varchar(100),
	district_des varchar(50),
	province_des varchar(50),
	teedin varchar(50),
	teedin_branch varchar(50),
	text_use_area varchar(50),
	temp_conno varchar(15),
	temp_reqno varchar(15),
	temp_seqno integer
) ;
ALTER TABLE sc_lon_req_coll_law_condo ADD PRIMARY KEY (doc_no);
ALTER TABLE sc_lon_req_coll_law_condo ALTER COLUMN doc_no SET NOT NULL;


