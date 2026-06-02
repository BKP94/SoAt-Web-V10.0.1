CREATE TABLE sc_crem_ucf_item_type (
	item_type_id varchar(3) NOT NULL,
	item_type_code varchar(6) NOT NULL,
	item_desc varchar(100),
	visible_status char(1),
	group_item varchar(6)
) ;
ALTER TABLE sc_crem_ucf_item_type ADD PRIMARY KEY (item_type_id);
ALTER TABLE sc_crem_ucf_item_type ALTER COLUMN item_type_id SET NOT NULL;
ALTER TABLE sc_crem_ucf_item_type ALTER COLUMN item_type_code SET NOT NULL;


