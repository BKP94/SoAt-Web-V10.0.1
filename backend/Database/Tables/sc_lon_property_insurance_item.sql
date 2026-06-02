CREATE TABLE sc_lon_property_insurance_item (
	loan_requestment_no varchar(15) NOT NULL,
	insurance_no varchar(15) NOT NULL DEFAULT 'cnv',
	seq_no double precision NOT NULL DEFAULT 0,
	money_amount decimal(15,2) DEFAULT 0,
	principal decimal(15,2) DEFAULT 0,
	interest decimal(15,2) DEFAULT 0,
	entry_date timestamp,
	entry_id varchar(30),
	entry_client varchar(30),
	entry_branch varchar(6),
	status char(1) DEFAULT '0',
	doc_no varchar(15),
	item_type varchar(3),
	remark varchar(255)
) ;
CREATE INDEX idx_lon_prop_ins ON sc_lon_property_insurance_item (loan_requestment_no, insurance_no);
ALTER TABLE sc_lon_property_insurance_item ADD PRIMARY KEY (loan_requestment_no,insurance_no,seq_no);
ALTER TABLE sc_lon_property_insurance_item ALTER COLUMN loan_requestment_no SET NOT NULL;
ALTER TABLE sc_lon_property_insurance_item ALTER COLUMN insurance_no SET NOT NULL;
ALTER TABLE sc_lon_property_insurance_item ALTER COLUMN seq_no SET NOT NULL;


