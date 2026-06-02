CREATE TABLE sc_dev_dbstr_execute (
	seq_no bigint NOT NULL DEFAULT 0,
	execute_type varchar(6),
	execute_string varchar(1000),
	execute_result char(1) DEFAULT '0',
	error_text varchar(1000)
) ;
ALTER TABLE sc_dev_dbstr_execute ADD PRIMARY KEY (seq_no);


