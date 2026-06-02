CREATE TABLE sc_inv_bill_stm (
	bill_no varchar(15) NOT NULL,
	seq_no integer NOT NULL,
	receipt_no varchar(15) NOT NULL,
	item_type varchar(3),
	period integer,
	operate_date timestamp,
	principal decimal(15,2),
	interest decimal(15,2),
	tax decimal(15,2) NOT NULL,
	principal_balance decimal(15,2),
	interest_cal decimal(15,2),
	interest_from timestamp,
	interest_to timestamp,
	interest_paid_fw decimal(15,2),
	cancel_status char(1),
	remark varchar(200),
	ref_doc_no varchar(50),
	entry_date timestamp,
	entry_id varchar(16),
	branch_id varchar(6),
	client_id varchar(20)
) ;
ALTER TABLE sc_inv_bill_stm ADD PRIMARY KEY (bill_no,seq_no);
ALTER TABLE sc_inv_bill_stm ALTER COLUMN bill_no SET NOT NULL;
ALTER TABLE sc_inv_bill_stm ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_inv_bill_stm ALTER COLUMN receipt_no SET NOT NULL;
ALTER TABLE sc_inv_bill_stm ALTER COLUMN tax SET NOT NULL;


