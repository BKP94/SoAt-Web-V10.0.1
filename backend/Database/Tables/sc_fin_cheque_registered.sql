CREATE TABLE sc_fin_cheque_registered (
	bank_fin varchar(6) NOT NULL,
	book_no double precision NOT NULL DEFAULT 0,
	cheque_no_begin varchar(15),
	cheque_no_end varchar(15),
	receive_date timestamp,
	entry_id varchar(16),
	entry_date timestamp,
	entry_branch varchar(6),
	entry_client varchar(15),
	close_status char(1),
	book_control double precision DEFAULT 0
) ;
COMMENT ON TABLE sc_fin_cheque_registered IS E'!NN!';
ALTER TABLE sc_fin_cheque_registered ADD PRIMARY KEY (bank_fin,book_no);


