CREATE TABLE sc_dep_m_passbook (
	deposit_account_no varchar(15) NOT NULL,
	passbook_no varchar(15) NOT NULL,
	operate_create timestamp,
	amount_book_count double precision,
	remark varchar(50),
	fee_charge decimal(15,2),
	entry_id varchar(20),
	client_name varchar(20),
	branch_id varchar(6),
	entry_date timestamp,
	working_day timestamp,
	status char(1),
	seq_no double precision NOT NULL DEFAULT 0
) ;
COMMENT ON TABLE sc_dep_m_passbook IS E'!NN!';
ALTER TABLE sc_dep_m_passbook ADD PRIMARY KEY (deposit_account_no,passbook_no,seq_no);
ALTER TABLE sc_dep_m_passbook ALTER COLUMN seq_no SET NOT NULL;


