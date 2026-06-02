CREATE TABLE sc_atm_ucf_file_code (
	bank_code varchar(6) NOT NULL,
	file_code varchar(15) NOT NULL,
	file_type char(1),
	file_desc varchar(100)
) ;
ALTER TABLE sc_atm_ucf_file_code ADD PRIMARY KEY (bank_code,file_code);


