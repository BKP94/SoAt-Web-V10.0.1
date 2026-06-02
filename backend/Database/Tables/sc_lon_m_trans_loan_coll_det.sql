CREATE TABLE sc_lon_m_trans_loan_coll_det (
	transfer_doc_no varchar(10) NOT NULL,
	seq_no double precision NOT NULL,
	collateral_no varchar(7),
	new_contract_no varchar(15),
	loan_transfer_amount decimal(15,2),
	period_payment decimal(15,2),
	start_keep_date timestamp,
	drop_loan_status char(1),
	loan_type varchar(6),
	int_arrear decimal(15,2),
	interest_rate decimal(10,6),
	loan_status char(1),
	payment_type_code varchar(6) DEFAULT '00',
	fee_amount decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_lon_m_trans_loan_coll_det ADD PRIMARY KEY (transfer_doc_no,seq_no);


