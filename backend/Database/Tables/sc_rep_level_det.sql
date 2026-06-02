CREATE TABLE sc_rep_level_det (
	level_date timestamp NOT NULL,
	membership_no varchar(15) NOT NULL,
	loan_contract_no varchar(15) NOT NULL,
	balance_begin decimal(15,2) DEFAULT 0,
	pay_prin decimal(15,2) DEFAULT 0,
	pay_int decimal(15,2) DEFAULT 0,
	balance_forward decimal(15,2) DEFAULT 0,
	loan_code char(1) DEFAULT '0',
	last_access_date timestamp,
	last_calint_date timestamp,
	int_arrear decimal(15,2) DEFAULT 0,
	int_arrear_card decimal(15,2) DEFAULT 0,
	period_law decimal(15,2) DEFAULT 0,
	period_real decimal(15,2) DEFAULT 0,
	period_miss decimal(15,2) DEFAULT 0,
	amount_law decimal(15,2) DEFAULT 0,
	amount_real decimal(15,2) DEFAULT 0,
	amount_miss decimal(15,2) DEFAULT 0,
	level_status char(1) DEFAULT '0',
	process_status char(1) DEFAULT '0',
	last_pay_prin decimal(15,2) DEFAULT 0,
	last_pay_int decimal(15,2) DEFAULT 0,
	principal_arr decimal(15,2) DEFAULT 0,
	level_status_in_year char(1) DEFAULT '0',
	period_miss_in_year decimal(15,2) DEFAULT 0,
	int_arrear_in_year decimal(15,2),
	share_amt decimal(15,2) DEFAULT 0,
	dep_amt decimal(15,2) DEFAULT 0,
	coll_amt decimal(15,2) DEFAULT 0,
	prin_arrear decimal(15,2) DEFAULT 0.00,
	pay_prin_in_year decimal(15,2) DEFAULT 0,
	pay_int_in_year decimal(15,2) DEFAULT 0,
	period_law_in_year decimal(15,2) DEFAULT 0,
	period_real_in_year decimal(15,2) DEFAULT 0,
	amount_law_in_year decimal(15,2) DEFAULT 0,
	amount_real_in_year decimal(15,2) DEFAULT 0,
	amount_miss_in_year decimal(15,2) DEFAULT 0,
	drop_payment_status char(1)
) ;
ALTER TABLE sc_rep_level_det ADD PRIMARY KEY (level_date,membership_no,loan_contract_no);
ALTER TABLE sc_rep_level_det ALTER COLUMN level_date SET NOT NULL;
ALTER TABLE sc_rep_level_det ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_rep_level_det ALTER COLUMN loan_contract_no SET NOT NULL;


