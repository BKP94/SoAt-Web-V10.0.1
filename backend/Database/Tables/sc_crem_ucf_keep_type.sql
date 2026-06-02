CREATE TABLE sc_crem_ucf_keep_type (
	keep_type varchar(6) NOT NULL,
	keep_desc varchar(100)
) ;
ALTER TABLE sc_crem_ucf_keep_type ADD PRIMARY KEY (keep_type);
ALTER TABLE sc_crem_ucf_keep_type ALTER COLUMN keep_type SET NOT NULL;


