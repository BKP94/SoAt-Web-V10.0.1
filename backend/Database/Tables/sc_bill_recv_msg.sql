CREATE TABLE sc_bill_recv_msg (
	bank_fin varchar(6) NOT NULL,
	operate_date timestamp NOT NULL,
	item_no smallint NOT NULL,
	seq_num double precision NOT NULL,
	operate_time varchar(23) NOT NULL,
	membership_no varchar(20) NOT NULL,
	payment_amount decimal(15,2) DEFAULT 0,
	system_code varchar(6),
	payment_money_code varchar(15),
	payment_item_code varchar(15),
	bill_no varchar(50),
	ref_no2 varchar(50),
	ref_no3 varchar(50),
	ref_doc_no varchar(50),
	terminal_branch_id varchar(6),
	teller_id varchar(6),
	cheque_no varchar(15),
	cheque_bank_code varchar(6),
	cheque_branch_code varchar(6),
	new_cheque_no varchar(10),
	office_id varchar(16),
	post_status char(1),
	post_date timestamp,
	post_id varchar(16),
	response_code varchar(4),
	response_text varchar(256),
	receipt_no varchar(15),
	money_return decimal(15,2),
	pre_membership_no varchar(20),
	pre_payment_item_code varchar(15),
	pre_ref_doc_no varchar(50),
	edit_id varchar(16),
	approve_id varchar(16),
	approve_status char(1) DEFAULT 'N',
	edit_status char(1) DEFAULT '0',
	pre_system_code varchar(6)
) ;
ALTER TABLE sc_bill_recv_msg ADD PRIMARY KEY (bank_fin,operate_date,item_no,seq_num);
ALTER TABLE sc_bill_recv_msg ALTER COLUMN bank_fin SET NOT NULL;
ALTER TABLE sc_bill_recv_msg ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_bill_recv_msg ALTER COLUMN item_no SET NOT NULL;
ALTER TABLE sc_bill_recv_msg ALTER COLUMN seq_num SET NOT NULL;
ALTER TABLE sc_bill_recv_msg ALTER COLUMN operate_time SET NOT NULL;
ALTER TABLE sc_bill_recv_msg ALTER COLUMN membership_no SET NOT NULL;


