CREATE TABLE sc_lon_m_close_year_lonint (
	lon_year double precision NOT NULL DEFAULT 0,
	loan_contract_no varchar(15) NOT NULL,
	year_total_interest double precision DEFAULT 0
) ;
ALTER TABLE sc_lon_m_close_year_lonint ADD PRIMARY KEY (lon_year,loan_contract_no);
ALTER TABLE sc_lon_m_close_year_lonint ALTER COLUMN lon_year SET NOT NULL;
ALTER TABLE sc_lon_m_close_year_lonint ALTER COLUMN loan_contract_no SET NOT NULL;


