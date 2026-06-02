CREATE TABLE sc_fin_ucf_item_type_cnv (
	item_type char(3) NOT NULL,
	item_description char(100) NOT NULL,
	sign_status integer NOT NULL,
	application_type char(20) NOT NULL,
	map_code char(3),
	loan_type char(2),
	pay_type char(3),
	account_id char(8),
	tran_account_id char(15),
	hold_account_id char(15),
	adj_dep char(1),
	loan_code char(1),
	item_type_group char(6),
	item_type_group_bk char(6)
) ;
ALTER TABLE sc_fin_ucf_item_type_cnv ALTER COLUMN item_type SET NOT NULL;
ALTER TABLE sc_fin_ucf_item_type_cnv ALTER COLUMN item_description SET NOT NULL;
ALTER TABLE sc_fin_ucf_item_type_cnv ALTER COLUMN sign_status SET NOT NULL;
ALTER TABLE sc_fin_ucf_item_type_cnv ALTER COLUMN application_type SET NOT NULL;


