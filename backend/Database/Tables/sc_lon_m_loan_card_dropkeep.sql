CREATE TABLE sc_lon_m_loan_card_dropkeep (
	loan_contract_no varchar(15) NOT NULL,
	drop_document_no varchar(15) NOT NULL,
	seq_no numeric(38) NOT NULL DEFAULT 0,
	keep_year numeric(38) DEFAULT 0,
	keep_month numeric(38) DEFAULT 0
) ;
ALTER TABLE sc_lon_m_loan_card_dropkeep ADD PRIMARY KEY (loan_contract_no,drop_document_no,seq_no);


