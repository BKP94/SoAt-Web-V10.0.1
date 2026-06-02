CREATE TABLE sc_inv_bill_rec_lot_no (
	bill_no varchar(15) NOT NULL,
	bill_rec_no varchar(100) NOT NULL,
	bill_money decimal(15,2) NOT NULL,
	gua_no varchar(100),
	gua_type varchar(100),
	gua_name varchar(100),
	gua_money decimal(15,2),
	gua_begindate timestamp,
	gua_enddate timestamp,
	gua_remarks varchar(100),
	gua_status char(1),
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	branch_id varchar(6) NOT NULL,
	client_id varchar(20) NOT NULL
) ;
ALTER TABLE sc_inv_bill_rec_lot_no ADD PRIMARY KEY (bill_no,bill_rec_no);
ALTER TABLE sc_inv_bill_rec_lot_no ALTER COLUMN bill_no SET NOT NULL;
ALTER TABLE sc_inv_bill_rec_lot_no ALTER COLUMN bill_rec_no SET NOT NULL;
ALTER TABLE sc_inv_bill_rec_lot_no ALTER COLUMN bill_money SET NOT NULL;
ALTER TABLE sc_inv_bill_rec_lot_no ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_inv_bill_rec_lot_no ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_inv_bill_rec_lot_no ALTER COLUMN branch_id SET NOT NULL;
ALTER TABLE sc_inv_bill_rec_lot_no ALTER COLUMN client_id SET NOT NULL;


