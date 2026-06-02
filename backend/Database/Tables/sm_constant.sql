CREATE TABLE sm_constant (
	coop_no varchar(15) NOT NULL,
	coop_name varchar(100),
	start_date timestamp,
	reset_date timestamp,
	last_update timestamp,
	receive_year double precision,
	receive_month double precision,
	account_year double precision,
	div_year double precision
) ;
ALTER TABLE sm_constant ADD PRIMARY KEY (coop_no);
ALTER TABLE sm_constant ALTER COLUMN coop_no SET NOT NULL;


