CREATE TABLE sc_cnt_m_salary_paid (
	account_year double precision NOT NULL DEFAULT 0,
	account_month double precision NOT NULL DEFAULT 0,
	salary_paid timestamp
) ;
COMMENT ON TABLE sc_cnt_m_salary_paid IS E'!NN!';
COMMENT ON COLUMN sc_cnt_m_salary_paid.account_month IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_cnt_m_salary_paid.account_year IS E'!N???????N!!MM!';
COMMENT ON COLUMN sc_cnt_m_salary_paid.salary_paid IS E'!N??????????????????N!!MM!';
ALTER TABLE sc_cnt_m_salary_paid ADD PRIMARY KEY (account_year,account_month);


