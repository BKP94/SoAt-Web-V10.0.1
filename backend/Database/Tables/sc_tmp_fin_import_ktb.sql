CREATE TABLE sc_tmp_fin_import_ktb (
	bank_fin varchar(6) NOT NULL,
	seq_no double precision NOT NULL,
	col_date varchar(100),
	col_teller_id varchar(100),
	col_trans_code varchar(100),
	col_desc varchar(100),
	col_cheque varchar(100),
	col_amount varchar(100),
	col_tax varchar(100),
	col_balance varchar(100),
	col_init_br varchar(100)
) ;
ALTER TABLE sc_tmp_fin_import_ktb ADD PRIMARY KEY (bank_fin,seq_no);


