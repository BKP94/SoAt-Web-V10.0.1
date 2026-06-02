CREATE TABLE sc_law_prosec_defendants (
	prosec_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	membership_no varchar(15),
	defendant_name varchar(100),
	defendant_type char(1) DEFAULT '0',
	item_order double precision NOT NULL DEFAULT 0,
	card_id varchar(15),
	job varchar(50),
	address_no varchar(80),
	moo varchar(50),
	road varchar(50),
	soi varchar(50),
	tambol varchar(50),
	distinct_code varchar(2),
	province_code varchar(2),
	post_code varchar(10),
	telephone varchar(50),
	status char(1) DEFAULT '0'
) ;
ALTER TABLE sc_law_prosec_defendants ADD PRIMARY KEY (prosec_no,seq_no);
ALTER TABLE sc_law_prosec_defendants ALTER COLUMN prosec_no SET NOT NULL;
ALTER TABLE sc_law_prosec_defendants ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_law_prosec_defendants ALTER COLUMN item_order SET NOT NULL;


