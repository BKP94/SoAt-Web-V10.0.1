CREATE TABLE temp_up_conno (
	conno varchar(15) NOT NULL,
	startkeep timestamp,
	amt decimal(15,2),
	drop_payment_status char(1),
	active_chgloan_docno varchar(15),
	period_compomise double precision,
	date_compomise timestamp,
	old_arr decimal(15,2)
) ;
ALTER TABLE temp_up_conno ADD PRIMARY KEY (conno);
ALTER TABLE temp_up_conno ALTER COLUMN conno SET NOT NULL;


