CREATE TABLE sc_crem_master_gain (
	crem_code varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	book_no varchar(15),
	book_date timestamp,
	prename_code varchar(6) DEFAULT '000',
	gain_name varchar(50),
	gain_surname varchar(50),
	conceern_code varchar(6) NOT NULL,
	gain_percent decimal(18,4),
	gain_status char(1) DEFAULT '0',
	id_card varchar(15),
	address_no varchar(100),
	mooban varchar(100),
	moo varchar(50),
	soi varchar(50),
	road varchar(50),
	tambol varchar(50),
	subdistinct_code varchar(6) DEFAULT '00',
	distinct_code varchar(6) DEFAULT '00',
	province_code varchar(6) DEFAULT '00',
	post_code varchar(10),
	telephone varchar(50)
) ;
ALTER TABLE sc_crem_master_gain ADD PRIMARY KEY (crem_code,seq_no);
ALTER TABLE sc_crem_master_gain ALTER COLUMN crem_code SET NOT NULL;
ALTER TABLE sc_crem_master_gain ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_crem_master_gain ALTER COLUMN conceern_code SET NOT NULL;


