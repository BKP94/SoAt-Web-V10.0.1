CREATE TABLE sc_fin_send_tax_fin (
	tax_date timestamp NOT NULL,
	tax_seq double precision NOT NULL,
	id_card varchar(15),
	prename varchar(30),
	memname varchar(50),
	memsurname varchar(50),
	paid_amount decimal(15,2),
	tax_amount decimal(15,2),
	company_id varchar(15),
	vourcher_no varchar(30),
	seq_no double precision,
	reward_amount decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_fin_send_tax_fin ADD PRIMARY KEY (tax_date,tax_seq);
ALTER TABLE sc_fin_send_tax_fin ALTER COLUMN tax_date SET NOT NULL;
ALTER TABLE sc_fin_send_tax_fin ALTER COLUMN tax_seq SET NOT NULL;


