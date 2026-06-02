CREATE TABLE sc_fin_ucf_item_type_group (
	item_type_group char(6) NOT NULL,
	item_group_description char(100) NOT NULL
) ;
ALTER TABLE sc_fin_ucf_item_type_group ALTER COLUMN item_type_group SET NOT NULL;
ALTER TABLE sc_fin_ucf_item_type_group ALTER COLUMN item_group_description SET NOT NULL;


