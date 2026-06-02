CREATE TABLE sc_dep_m_fee (
	deposit_account_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	fee_date timestamp,
	fee_type varchar(3),
	fee_amount decimal(15,2),
	op_balance decimal(15,2),
	fee_maintain_status char(1),
	refer_to_deposit_doc_no varchar(15),
	ref_doc_adj varchar(30),
	ref_seq_no double precision,
	officer_id varchar(15),
	operate_date timestamp,
	branch_id varchar(6),
	working_day timestamp
) ;
COMMENT ON TABLE sc_dep_m_fee IS E'!NN!';
ALTER TABLE sc_dep_m_fee ADD PRIMARY KEY (deposit_account_no,seq_no);


