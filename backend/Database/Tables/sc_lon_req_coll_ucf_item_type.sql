CREATE TABLE sc_lon_req_coll_ucf_item_type (
	item_type varchar(6) NOT NULL DEFAULT '000000',
	item_type_desc varchar(100)
) ;
ALTER TABLE sc_lon_req_coll_ucf_item_type ADD PRIMARY KEY (item_type);
ALTER TABLE sc_lon_req_coll_ucf_item_type ALTER COLUMN item_type SET NOT NULL;


