CREATE TABLE si_ucf_tables (
	table_name varchar(30) NOT NULL,
	last_update varchar(15)
) ;
ALTER TABLE si_ucf_tables ADD PRIMARY KEY (table_name);
ALTER TABLE si_ucf_tables ALTER COLUMN table_name SET NOT NULL;


