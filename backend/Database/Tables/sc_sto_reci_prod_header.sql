CREATE TABLE sc_sto_reci_prod_header (
	doc_no varchar(15) NOT NULL,
	id_company varchar(15),
	date_rec timestamp,
	pay_by varchar(50),
	human_name_rec varchar(50),
	total_amount decimal(20,2),
	refer_no numeric(20),
	ref_no varchar(20),
	branch_id varchar(6),
	status char(1),
	note varchar(250),
	place varchar(15),
	date_paid timestamp
) ;
ALTER TABLE sc_sto_reci_prod_header ADD PRIMARY KEY (doc_no);
ALTER TABLE sc_sto_reci_prod_header ALTER COLUMN doc_no SET NOT NULL;


