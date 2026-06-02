CREATE TABLE sc_mobile_ucf_error_code (
	code_coop varchar(50) NOT NULL,
	code_desc varchar(100) NOT NULL,
	code_bank varchar(15) NOT NULL
) ;
ALTER TABLE sc_mobile_ucf_error_code ADD PRIMARY KEY (code_coop);
ALTER TABLE sc_mobile_ucf_error_code ALTER COLUMN code_coop SET NOT NULL;
ALTER TABLE sc_mobile_ucf_error_code ALTER COLUMN code_desc SET NOT NULL;
ALTER TABLE sc_mobile_ucf_error_code ALTER COLUMN code_bank SET NOT NULL;


