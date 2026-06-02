CREATE TABLE sc_eoff_ucf_trans_type (
	trans_type char(1) NOT NULL,
	trans_desc varchar(100),
	status_in char(1) DEFAULT '0',
	status_out char(1) DEFAULT '0'
) ;
ALTER TABLE sc_eoff_ucf_trans_type ADD PRIMARY KEY (trans_type);
ALTER TABLE sc_eoff_ucf_trans_type ALTER COLUMN trans_type SET NOT NULL;


