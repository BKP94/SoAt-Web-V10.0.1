CREATE TABLE sc_kep_m_monthly_process (
	receive_year double precision NOT NULL,
	receive_month double precision NOT NULL,
	process_date timestamp,
	receipt_date timestamp,
	calint_date timestamp,
	posting_date timestamp,
	comfirm_id varchar(10),
	comfirm_date timestamp,
	salary_time smallint DEFAULT 1,
	comfirm_status char(1)
) ;
COMMENT ON TABLE sc_kep_m_monthly_process IS E'!NN!';
ALTER TABLE sc_kep_m_monthly_process ADD PRIMARY KEY (receive_year,receive_month);


