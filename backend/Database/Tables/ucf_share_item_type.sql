CREATE TABLE ucf_share_item_type (
	item_type char(5) NOT NULL,
	item_type_description char(60),
	sign_flag double precision,
	cancel_item_ref char(5),
	cancel_status char(1),
	not_div_in_year char(1)
) ;
CREATE UNIQUE INDEX sc_mem_m_ucf_share_item_type_x ON ucf_share_item_type (item_type);
ALTER TABLE ucf_share_item_type ALTER COLUMN item_type SET NOT NULL;


