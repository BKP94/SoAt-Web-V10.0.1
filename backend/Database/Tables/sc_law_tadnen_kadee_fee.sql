CREATE TABLE sc_law_tadnen_kadee_fee (
	prosec_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	insurance_type varchar(5) NOT NULL,
	insurance_date timestamp,
	fee_amount decimal(15,2) DEFAULT 0,
	remark varchar(100),
	cancel_status char(1) NOT NULL DEFAULT '0',
	insurance_no varchar(15),
	process_status char(1) DEFAULT '0'
) ;
ALTER TABLE sc_law_tadnen_kadee_fee ADD PRIMARY KEY (prosec_no,seq_no);
ALTER TABLE sc_law_tadnen_kadee_fee ALTER COLUMN prosec_no SET NOT NULL;
ALTER TABLE sc_law_tadnen_kadee_fee ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_law_tadnen_kadee_fee ALTER COLUMN insurance_type SET NOT NULL;
ALTER TABLE sc_law_tadnen_kadee_fee ALTER COLUMN cancel_status SET NOT NULL;


