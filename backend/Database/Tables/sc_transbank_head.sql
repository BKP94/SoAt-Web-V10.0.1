CREATE TABLE sc_transbank_head (
	data_code varchar(3) NOT NULL,
	bank_code varchar(6) NOT NULL,
	trandate timestamp NOT NULL,
	seq_tran integer NOT NULL DEFAULT 0,
	account_name varchar(200),
	acc_no varchar(20),
	file_name varchar(100),
	bank_fin varchar(6),
	entry_id varchar(16)
) ;
ALTER TABLE sc_transbank_head ADD PRIMARY KEY (data_code,bank_code,trandate,seq_tran);


