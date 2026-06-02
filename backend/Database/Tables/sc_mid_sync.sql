CREATE TABLE sc_mid_sync (
	operate_time varchar(23) NOT NULL,
	id_card varchar(15) NOT NULL,
	operate_date timestamp NOT NULL,
	app_name varchar(15) NOT NULL,
	s_url varchar(40) NOT NULL,
	ref_docno varchar(30) NOT NULL,
	entry_id varchar(16) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_branch varchar(6) NOT NULL,
	id_msg varchar(4000)
) ;
ALTER TABLE sc_mid_sync ADD PRIMARY KEY (operate_time,id_card);
ALTER TABLE sc_mid_sync ALTER COLUMN operate_time SET NOT NULL;
ALTER TABLE sc_mid_sync ALTER COLUMN id_card SET NOT NULL;
ALTER TABLE sc_mid_sync ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_mid_sync ALTER COLUMN app_name SET NOT NULL;
ALTER TABLE sc_mid_sync ALTER COLUMN s_url SET NOT NULL;
ALTER TABLE sc_mid_sync ALTER COLUMN ref_docno SET NOT NULL;
ALTER TABLE sc_mid_sync ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_mid_sync ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_mid_sync ALTER COLUMN entry_branch SET NOT NULL;


