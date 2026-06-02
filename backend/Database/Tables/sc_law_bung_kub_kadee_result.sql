CREATE TABLE sc_law_bung_kub_kadee_result (
	prosec_no varchar(15) NOT NULL,
	result_sale varchar(50),
	sale_amount double precision DEFAULT 0,
	kadee_status char(1) DEFAULT '0',
	ownership_date timestamp,
	sale_receive_date timestamp,
	sale_amount_coop double precision NOT NULL DEFAULT 0,
	seq_no_yed double precision NOT NULL DEFAULT 0
) ;
ALTER TABLE sc_law_bung_kub_kadee_result ADD PRIMARY KEY (prosec_no,seq_no_yed);
ALTER TABLE sc_law_bung_kub_kadee_result ALTER COLUMN prosec_no SET NOT NULL;
ALTER TABLE sc_law_bung_kub_kadee_result ALTER COLUMN sale_amount_coop SET NOT NULL;
ALTER TABLE sc_law_bung_kub_kadee_result ALTER COLUMN seq_no_yed SET NOT NULL;


