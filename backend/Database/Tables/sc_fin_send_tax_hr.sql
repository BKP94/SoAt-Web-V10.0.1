CREATE TABLE sc_fin_send_tax_hr (
	tax_date timestamp NOT NULL,
	tax_seq double precision NOT NULL,
	id_card varchar(15),
	prename varchar(30),
	memname varchar(50),
	memsurname varchar(50),
	paid_amount decimal(15,2),
	tax_amount decimal(15,2),
	official_no varchar(15),
	sal_year double precision,
	sal_month double precision,
	reward_amount decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_fin_send_tax_hr ADD PRIMARY KEY (tax_date,tax_seq);
ALTER TABLE sc_fin_send_tax_hr ALTER COLUMN tax_date SET NOT NULL;
ALTER TABLE sc_fin_send_tax_hr ALTER COLUMN tax_seq SET NOT NULL;


