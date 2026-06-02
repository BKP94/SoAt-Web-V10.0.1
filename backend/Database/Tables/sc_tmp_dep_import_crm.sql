CREATE TABLE sc_tmp_dep_import_crm (
	time_id varchar(16) NOT NULL,
	seq_no double precision NOT NULL,
	deposit_account_no varchar(15),
	item_amount double precision
) ;
ALTER TABLE sc_tmp_dep_import_crm ADD PRIMARY KEY (time_id,seq_no);
ALTER TABLE sc_tmp_dep_import_crm ALTER COLUMN time_id SET NOT NULL;
ALTER TABLE sc_tmp_dep_import_crm ALTER COLUMN seq_no SET NOT NULL;


