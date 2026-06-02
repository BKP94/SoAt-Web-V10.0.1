CREATE TABLE sc_inv_bill_term_of_payment (
	bill_no varchar(15) NOT NULL,
	bank_id varchar(6),
	bank_branch_id varchar(6),
	date_term_of_pay timestamp,
	money_amount decimal(15,2),
	mode_tranfer varchar(3),
	no_account_c varchar(15),
	receive_name varchar(30),
	status char(1),
	transfer_date timestamp,
	type_term_of_pay varchar(3),
	cancel_status char(1),
	entry_date timestamp,
	entry_id varchar(16),
	branch_id varchar(6),
	client_id varchar(20),
	agent_name varchar(100),
	telephone varchar(100),
	fax varchar(100),
	cell_phone varchar(100),
	fin_bank varchar(6),
	fin_status char(1),
	vourcher_no varchar(15),
	fee_bank decimal(15,2),
	cancle_id varchar(16),
	cancle_date timestamp,
	cancle_branch varchar(6),
	bank_account_name varchar(200),
	cheque_no varchar(10),
	tran_status char(1) DEFAULT '0',
	ref_doc_no varchar(50)
) ;
ALTER TABLE sc_inv_bill_term_of_payment ADD PRIMARY KEY (bill_no);
ALTER TABLE sc_inv_bill_term_of_payment ALTER COLUMN bill_no SET NOT NULL;


