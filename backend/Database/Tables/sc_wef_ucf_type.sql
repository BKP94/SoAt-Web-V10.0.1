CREATE TABLE sc_wef_ucf_type (
	wef_type varchar(3) NOT NULL,
	wef_desc varchar(100),
	active_status char(1) DEFAULT '0',
	doc_code varchar(6),
	doc_prefix char(3),
	order_by numeric(38) DEFAULT 0,
	account_id varchar(8),
	method_count_age char(1) DEFAULT '0',
	method_bf_count_age char(1) DEFAULT '0',
	end_count_age_date timestamp,
	paid_amount_max_in_year double precision DEFAULT 0,
	count_pay_year numeric(38) DEFAULT 0,
	age_not_over numeric(38) DEFAULT 0,
	field_permit varchar(50),
	soat_comment varchar(100),
	shot_name varchar(100),
	hr_active_status char(1) DEFAULT '0'
) ;
ALTER TABLE sc_wef_ucf_type ADD PRIMARY KEY (wef_type);


