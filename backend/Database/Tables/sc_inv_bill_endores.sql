CREATE TABLE sc_inv_bill_endores (
	bill_no varchar(15) NOT NULL,
	endores_date timestamp,
	endores_no varchar(100),
	coll_name varchar(100),
	branch_endores varchar(6),
	bank_id varchar(6),
	remarks varchar(200),
	cancel_status char(1),
	entry_date timestamp,
	entry_id varchar(16),
	branch_id varchar(6),
	client_id varchar(20)
) ;
ALTER TABLE sc_inv_bill_endores ADD PRIMARY KEY (bill_no);
ALTER TABLE sc_inv_bill_endores ALTER COLUMN bill_no SET NOT NULL;


