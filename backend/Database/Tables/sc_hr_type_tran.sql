CREATE TABLE sc_hr_type_tran (
	c_type_tran_code char(3) NOT NULL,
	c_type_desc varchar(50),
	c_flage double precision
) ;
ALTER TABLE sc_hr_type_tran ADD PRIMARY KEY (c_type_tran_code);


