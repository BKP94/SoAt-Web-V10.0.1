CREATE TABLE sc_crem_statement (
	crem_code varchar(10) NOT NULL,
	seq_no double precision NOT NULL,
	item_type_code varchar(3) NOT NULL,
	operate_date timestamp NOT NULL,
	reference_doc_no varchar(10),
	fee_new_amount decimal(18,2),
	fee_year_amount decimal(18,2),
	carcass_amount decimal(18,2),
	balance decimal(18,2),
	n_time double precision,
	n_begin double precision,
	n_end double precision,
	n_paid double precision,
	carcass_paid decimal(15,2)
) ;
ALTER TABLE sc_crem_statement ADD PRIMARY KEY (crem_code,seq_no);
ALTER TABLE sc_crem_statement ALTER COLUMN crem_code SET NOT NULL;
ALTER TABLE sc_crem_statement ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_crem_statement ALTER COLUMN item_type_code SET NOT NULL;
ALTER TABLE sc_crem_statement ALTER COLUMN operate_date SET NOT NULL;


