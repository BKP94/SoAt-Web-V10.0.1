CREATE TABLE sc_lon_m_close_year_memint (
	lon_year double precision NOT NULL DEFAULT 0,
	membership_no varchar(15) NOT NULL,
	emer_loan_int double precision DEFAULT 0,
	norm_loan_int double precision DEFAULT 0,
	spec_loan_int double precision DEFAULT 0
) ;
ALTER TABLE sc_lon_m_close_year_memint ADD PRIMARY KEY (lon_year,membership_no);
ALTER TABLE sc_lon_m_close_year_memint ALTER COLUMN lon_year SET NOT NULL;
ALTER TABLE sc_lon_m_close_year_memint ALTER COLUMN membership_no SET NOT NULL;


