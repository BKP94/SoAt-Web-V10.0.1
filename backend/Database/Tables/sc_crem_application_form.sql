CREATE TABLE sc_crem_application_form (
	application_form_no varchar(15) NOT NULL,
	apply_date timestamp,
	membership_no varchar(15),
	crem_type varchar(6) DEFAULT '00',
	member_status char(1) DEFAULT '0',
	prename_code varchar(6) DEFAULT '000',
	memname varchar(50),
	surname varchar(50),
	keep_type varchar(6) DEFAULT '00',
	date_of_birth timestamp,
	id_card varchar(15),
	sex char(1) DEFAULT '0',
	salary_id varchar(15),
	position_long varchar(100),
	bank_id varchar(6),
	bank_acc_no varchar(15),
	marriage_status char(1),
	spouse_name varchar(100),
	officer_id varchar(16),
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
	telephone varchar(50),
	remark varchar(200)
) ;
ALTER TABLE sc_crem_application_form ADD PRIMARY KEY (application_form_no);
ALTER TABLE sc_crem_application_form ALTER COLUMN application_form_no SET NOT NULL;


