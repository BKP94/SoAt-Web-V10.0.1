CREATE TABLE sc_lon_property_insurance (
	loan_requestment_no varchar(15) NOT NULL,
	insurance_no varchar(15) NOT NULL DEFAULT 'cnv',
	company_code varchar(6),
	insurance_amount decimal(15,2) DEFAULT 0,
	insurance_real decimal(15,2) DEFAULT 0,
	paid_status char(1),
	paid_date timestamp,
	keeping_status varchar(6) DEFAULT '00',
	return_over_status char(1),
	retrun_over_date timestamp,
	begin_date timestamp,
	end_date timestamp,
	principal_amount decimal(15,2) DEFAULT 0,
	address_no varchar(200),
	last_period bigint DEFAULT 0,
	insurance_principal decimal(15,2) DEFAULT 0,
	coll_ref varchar(50),
	home_amount bigint,
	remark varchar(200)
) ;
COMMENT ON TABLE sc_lon_property_insurance IS E'!NN!';
ALTER TABLE sc_lon_property_insurance ADD PRIMARY KEY (loan_requestment_no,insurance_no);


