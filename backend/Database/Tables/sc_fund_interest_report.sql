CREATE TABLE sc_fund_interest_report (
	calculate_year double precision NOT NULL,
	calculate_month double precision NOT NULL,
	calculate_date timestamp,
	membership_no varchar(15) NOT NULL,
	loan_type varchar(6) NOT NULL,
	last_contract_no varchar(50),
	begin_balance decimal(15,2),
	balance decimal(15,2),
	keep_month_amt decimal(15,2),
	keep_total_amt decimal(15,2),
	keep_status double precision,
	last_access_date timestamp,
	last_period double precision,
	begin_interest decimal(15,2),
	year_interest decimal(15,2),
	total_interest decimal(15,2),
	interest_rate decimal(15,2)
) ;
ALTER TABLE sc_fund_interest_report ADD PRIMARY KEY (calculate_year,calculate_month,membership_no,loan_type);


