CREATE TABLE sc_inv_bill_book_value (
	bill_no char(15) NOT NULL,
	operate_date timestamp NOT NULL,
	discount_value decimal(15,2) NOT NULL,
	book_value_arrear decimal(15,2) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(20) NOT NULL,
	branch_id varchar(6) NOT NULL,
	client_id varchar(20) NOT NULL
) ;
ALTER TABLE sc_inv_bill_book_value ADD PRIMARY KEY (bill_no,operate_date);
ALTER TABLE sc_inv_bill_book_value ALTER COLUMN bill_no SET NOT NULL;
ALTER TABLE sc_inv_bill_book_value ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_inv_bill_book_value ALTER COLUMN discount_value SET NOT NULL;
ALTER TABLE sc_inv_bill_book_value ALTER COLUMN book_value_arrear SET NOT NULL;
ALTER TABLE sc_inv_bill_book_value ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_inv_bill_book_value ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_inv_bill_book_value ALTER COLUMN branch_id SET NOT NULL;
ALTER TABLE sc_inv_bill_book_value ALTER COLUMN client_id SET NOT NULL;


