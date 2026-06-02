CREATE TABLE sc_cnv_dbtabs (
	tab_name varchar(128) NOT NULL,
	not_transfer char(1) NOT NULL DEFAULT '0',
	date_name varchar(50) DEFAULT '',
	tab_master varchar(128) DEFAULT '',
	sql_master varchar(200),
	note varchar(200),
	note2 varchar(200),
	note3 varchar(200),
	note4 varchar(200),
	count_row bigint,
	not_transfer_round0 char(1),
	not_transfer_round1 char(1),
	not_transfer_round2 char(1),
	del_status char(1) DEFAULT '0'
) ;
ALTER TABLE sc_cnv_dbtabs ADD PRIMARY KEY (tab_name);
ALTER TABLE sc_cnv_dbtabs ALTER COLUMN tab_name SET NOT NULL;
ALTER TABLE sc_cnv_dbtabs ALTER COLUMN not_transfer SET NOT NULL;


