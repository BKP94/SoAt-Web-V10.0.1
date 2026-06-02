CREATE TABLE sc_fin_ucf_company (
	company_id varchar(15) NOT NULL,
	company_type varchar(6) DEFAULT '00',
	company_prename varchar(6),
	company_name varchar(100),
	company_surname varchar(100),
	address_no varchar(60),
	mooban varchar(100),
	moo varchar(50),
	soi varchar(50),
	tambol varchar(50),
	province_code varchar(6) DEFAULT '00',
	telephone varchar(50),
	tax_id varchar(15),
	road varchar(50),
	district_code varchar(6) DEFAULT '00',
	postcode varchar(10),
	service_des varchar(100),
	tax_rate decimal(6,2) DEFAULT 0,
	sort_order integer DEFAULT 0,
	vat_rate decimal(6,2) DEFAULT 0,
	bank_id varchar(6),
	bank_acc_no varchar(15),
	cancel_status char(1) DEFAULT '0'
) ;
ALTER TABLE sc_fin_ucf_company ADD PRIMARY KEY (company_id);
ALTER TABLE sc_fin_ucf_company ALTER COLUMN company_id SET NOT NULL;


