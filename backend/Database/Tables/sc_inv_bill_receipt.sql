CREATE TABLE sc_inv_bill_receipt (
	receipt_no varchar(15) NOT NULL,
	bill_no varchar(15) NOT NULL,
	period integer NOT NULL,
	operate_date timestamp NOT NULL,
	principal decimal(15,2) NOT NULL,
	interest decimal(15,2) NOT NULL,
	tax decimal(15,2) NOT NULL,
	interest_cal decimal(15,2) NOT NULL,
	interest_from timestamp NOT NULL,
	interest_to timestamp NOT NULL,
	interest_paid_fw decimal(15,2) NOT NULL,
	remark varchar(200),
	receipt_status char(1) NOT NULL,
	sale_org_id varchar(100),
	sale_market_value decimal(15,2) NOT NULL,
	sale_book_value decimal(15,2) NOT NULL,
	sale_price decimal(15,2) NOT NULL,
	ref_doc_no varchar(50),
	int_rate varchar(50),
	bill_date timestamp NOT NULL,
	due_date timestamp NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	branch_id varchar(6) NOT NULL,
	client_id varchar(20) NOT NULL,
	cancle_status char(1) NOT NULL,
	cancle_id varchar(16),
	cancle_branchid varchar(6),
	cancle_date timestamp,
	cancle_remark varchar(200),
	fin_bank varchar(6),
	fin_status char(1),
	vourcher_no varchar(15),
	fee_bank decimal(15,2),
	interest_received decimal(15,2),
	money_type_id varchar(3),
	cheque_no varchar(10),
	bank_id varchar(6),
	bank_branch_id varchar(6),
	link_book_bank char(1),
	book_bank_seq double precision,
	money_trans_amount decimal(15,2),
	fee_int decimal(15,2),
	interest_arrear decimal(15,2) DEFAULT 0.00,
	interest_rate decimal(15,8) DEFAULT 0
) ;
ALTER TABLE sc_inv_bill_receipt ADD PRIMARY KEY (receipt_no);
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN receipt_no SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN bill_no SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN period SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN principal SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN interest SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN tax SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN interest_cal SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN interest_from SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN interest_to SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN interest_paid_fw SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN receipt_status SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN sale_market_value SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN sale_book_value SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN sale_price SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN bill_date SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN due_date SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN branch_id SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN client_id SET NOT NULL;
ALTER TABLE sc_inv_bill_receipt ALTER COLUMN cancle_status SET NOT NULL;


