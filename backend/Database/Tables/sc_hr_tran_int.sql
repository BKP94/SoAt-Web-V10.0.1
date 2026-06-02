CREATE TABLE sc_hr_tran_int (
	c_month double precision NOT NULL,
	c_year double precision NOT NULL,
	c_int decimal(15,2)
) ;
ALTER TABLE sc_hr_tran_int ADD PRIMARY KEY (c_month,c_year);


