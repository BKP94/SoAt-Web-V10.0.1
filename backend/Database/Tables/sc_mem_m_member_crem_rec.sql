CREATE TABLE sc_mem_m_member_crem_rec (
	receipt_no varchar(15) NOT NULL,
	membership_no varchar(15),
	receipt_date timestamp,
	receipt_stataus char(1),
	entry_date timestamp,
	cancel_id varchar(16),
	cancel_date timestamp,
	entry_id varchar(16),
	money_type_id varchar(3),
	crem_type varchar(6),
	remark varchar(100),
	receipt_amount decimal(15,2),
	book_bank_seq numeric(38) DEFAULT 0,
	cancel_resaon varchar(100),
	money_trans_amount decimal(15,2),
	cheque_date timestamp,
	fin_bank varchar(6),
	deposit_slip_no varchar(15),
	receipt_status char(1),
	deposit_slip_no_account varchar(15)
) ;
ALTER TABLE sc_mem_m_member_crem_rec ADD PRIMARY KEY (receipt_no);


