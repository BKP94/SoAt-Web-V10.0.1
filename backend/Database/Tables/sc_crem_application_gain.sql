CREATE TABLE sc_crem_application_gain (
	application_form_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	prename_code varchar(6) DEFAULT '000',
	gain_name varchar(50),
	gain_surname varchar(50),
	conceern_code varchar(6) NOT NULL,
	gain_percent decimal(18,4),
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
ALTER TABLE sc_crem_application_gain ADD PRIMARY KEY (application_form_no,seq_no);
ALTER TABLE sc_crem_application_gain ALTER COLUMN application_form_no SET NOT NULL;
ALTER TABLE sc_crem_application_gain ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_crem_application_gain ALTER COLUMN conceern_code SET NOT NULL;


