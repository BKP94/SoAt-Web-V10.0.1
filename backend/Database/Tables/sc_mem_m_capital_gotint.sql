CREATE TABLE sc_mem_m_capital_gotint (
	account_year double precision NOT NULL DEFAULT 0,
	membership_no varchar(15) NOT NULL,
	m01 double precision DEFAULT 0,
	m02 double precision DEFAULT 0,
	m03 double precision DEFAULT 0,
	m04 double precision DEFAULT 0,
	m05 double precision DEFAULT 0,
	m06 double precision DEFAULT 0,
	m07 double precision DEFAULT 0,
	m08 double precision DEFAULT 0,
	m09 double precision DEFAULT 0,
	m10 double precision DEFAULT 0,
	m11 double precision DEFAULT 0,
	m12 double precision DEFAULT 0
) ;
ALTER TABLE sc_mem_m_capital_gotint ADD PRIMARY KEY (account_year,membership_no);
ALTER TABLE sc_mem_m_capital_gotint ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_mem_m_capital_gotint ALTER COLUMN membership_no SET NOT NULL;


