CREATE TABLE sc_lon_m_trans_back_coll_det (
	transfer_doc_no varchar(10) NOT NULL,
	seq_no double precision NOT NULL,
	collateral_no varchar(6),
	new_contract_no varchar(15),
	loan_transfer_amount decimal(15,2),
	period_payment decimal(15,2),
	loan_type varchar(6),
	int_arrear decimal(15,2),
	interest_rate decimal(15,4),
	loan_status char(1),
	last_calcint_date timestamp,
	membership_no varchar(15)
) ;
ALTER TABLE sc_lon_m_trans_back_coll_det ADD PRIMARY KEY (transfer_doc_no,seq_no);


