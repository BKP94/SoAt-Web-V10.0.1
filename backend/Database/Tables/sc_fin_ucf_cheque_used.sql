CREATE TABLE sc_fin_ucf_cheque_used (
	used_code char(1) NOT NULL DEFAULT '0',
	used_desc varchar(100)
) ;
ALTER TABLE sc_fin_ucf_cheque_used ADD PRIMARY KEY (used_code);
ALTER TABLE sc_fin_ucf_cheque_used ALTER COLUMN used_code SET NOT NULL;


