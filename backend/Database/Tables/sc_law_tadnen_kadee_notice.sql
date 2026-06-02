CREATE TABLE sc_law_tadnen_kadee_notice (
	prosec_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	letter_date timestamp,
	entry_date timestamp,
	owner_name varchar(40),
	header varchar(50),
	prin_amount decimal(15,2) DEFAULT 0,
	doc_no varchar(15),
	loan_at_date timestamp,
	entry_id varchar(10),
	result_book varchar(35)
) ;
ALTER TABLE sc_law_tadnen_kadee_notice ADD PRIMARY KEY (prosec_no,seq_no);
ALTER TABLE sc_law_tadnen_kadee_notice ALTER COLUMN prosec_no SET NOT NULL;
ALTER TABLE sc_law_tadnen_kadee_notice ALTER COLUMN seq_no SET NOT NULL;


