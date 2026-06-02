CREATE TABLE sc_lon_m_req_salnet (
	loan_requestment_no varchar(15) NOT NULL,
	ot_month_1 decimal(15,2) DEFAULT 0,
	ot_month_2 decimal(15,2) DEFAULT 0,
	ot_month_3 decimal(15,2) DEFAULT 0,
	ot_percent_got decimal(5,2) DEFAULT 0,
	money_net_income decimal(15,2) DEFAULT 0,
	cut_money_amount decimal(15,2) DEFAULT 0,
	add_oldloan_amount decimal(15,2) DEFAULT 0,
	add_other_amount decimal(15,2) DEFAULT 0,
	cut_not_keep_amount decimal(15,2) DEFAULT 0,
	cut_other_amount decimal(15,2) DEFAULT 0,
	total_balance decimal(15,2) DEFAULT 0,
	period_pay_new decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_lon_m_req_salnet ADD PRIMARY KEY (loan_requestment_no);
ALTER TABLE sc_lon_m_req_salnet ALTER COLUMN loan_requestment_no SET NOT NULL;


