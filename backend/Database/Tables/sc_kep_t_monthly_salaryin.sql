CREATE TABLE sc_kep_t_monthly_salaryin (
	membership_no varchar(15) NOT NULL,
	receive_year double precision NOT NULL DEFAULT 0,
	receive_month double precision NOT NULL DEFAULT 0,
	salary_time double precision NOT NULL DEFAULT 0,
	salary_total decimal(15,2) DEFAULT 0,
	income_total decimal(15,2) DEFAULT 0,
	expend_total decimal(15,2) DEFAULT 0,
	salary_balance decimal(15,2) DEFAULT 0,
	keeping_real decimal(15,2) DEFAULT 0,
	kep_method varchar(3),
	operate_date timestamp,
	entry_id varchar(16),
	entry_date timestamp
) ;
ALTER TABLE sc_kep_t_monthly_salaryin ADD PRIMARY KEY (membership_no,receive_year,receive_month,salary_time);


