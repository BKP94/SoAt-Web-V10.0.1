CREATE TABLE ucf_receipt_item_type (
	item_type_id char(6) NOT NULL,
	item_type_name char(50),
	sign_flag double precision,
	print_code char(6),
	group_item char(3),
	sort_order smallint NOT NULL,
	mpay_code char(3),
	mpay_reftype char(2),
	mpay_account char(8)
) ;
CREATE UNIQUE INDEX sc_com_m_ucf_receipt_item_typ_ ON ucf_receipt_item_type (item_type_id);
ALTER TABLE ucf_receipt_item_type ALTER COLUMN item_type_id SET NOT NULL;
ALTER TABLE ucf_receipt_item_type ALTER COLUMN sort_order SET NOT NULL;


