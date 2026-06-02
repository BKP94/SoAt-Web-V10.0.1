CREATE TABLE sc_inv_bill_guarantee (
	bill_no varchar(15) NOT NULL,
	guarantee_no varchar(100) NOT NULL,
	loan_type_desc varchar(200),
	gua_money decimal(15,2),
	gua_date timestamp,
	remarks varchar(200),
	cancel_status char(1),
	end_date timestamp,
	entry_date timestamp,
	entry_id varchar(16),
	branch_id varchar(6),
	client_id varchar(20),
	coll_name varchar(200)
) ;
ALTER TABLE sc_inv_bill_guarantee ADD PRIMARY KEY (bill_no);
ALTER TABLE sc_inv_bill_guarantee ALTER COLUMN bill_no SET NOT NULL;
ALTER TABLE sc_inv_bill_guarantee ALTER COLUMN guarantee_no SET NOT NULL;


