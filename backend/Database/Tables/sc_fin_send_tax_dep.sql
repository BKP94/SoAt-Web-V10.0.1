CREATE TABLE sc_fin_send_tax_dep (
	tax_date timestamp NOT NULL,
	tax_seq double precision NOT NULL,
	id_card varchar(15),
	prename varchar(30),
	memname varchar(50),
	memsurname varchar(50),
	paid_amount decimal(15,2),
	tax_amount decimal(15,2),
	deposit_account_no varchar(15),
	deposit_type_code varchar(6),
	seq_no double precision
) ;
ALTER TABLE sc_fin_send_tax_dep ADD PRIMARY KEY (tax_date,tax_seq);
ALTER TABLE sc_fin_send_tax_dep ALTER COLUMN tax_date SET NOT NULL;
ALTER TABLE sc_fin_send_tax_dep ALTER COLUMN tax_seq SET NOT NULL;


