CREATE TABLE sc_lon_m_trans_back_coll_head (
	transfer_doc_no varchar(10) NOT NULL,
	membership_no varchar(15),
	loan_contract_no varchar(15),
	transfer_date timestamp,
	principal_balance decimal(15,2),
	last_access_date timestamp,
	transfer_status char(1),
	principal_of_loan decimal(15,2),
	period_payment decimal(15,2),
	begining_of_contract timestamp,
	last_period double precision,
	int_transfer_amount decimal(15,2),
	last_calcint_date timestamp,
	entry_id varchar(10),
	branch_id varchar(15),
	entry_date timestamp,
	interest_rate decimal(15,2)
) ;
ALTER TABLE sc_lon_m_trans_back_coll_head ADD PRIMARY KEY (transfer_doc_no);


