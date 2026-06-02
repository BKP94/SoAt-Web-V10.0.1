CREATE TABLE sc_crem_ucf_resign (
	resign_code varchar(6) NOT NULL DEFAULT '00',
	resign_desc varchar(100)
) ;
ALTER TABLE sc_crem_ucf_resign ADD PRIMARY KEY (resign_code);
ALTER TABLE sc_crem_ucf_resign ALTER COLUMN resign_code SET NOT NULL;


