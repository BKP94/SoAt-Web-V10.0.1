CREATE TABLE sc_dev_dbstr_indexes (
	index_name varchar(30) NOT NULL,
	table_name varchar(30),
	uniqueness varchar(9)
) ;
ALTER TABLE sc_dev_dbstr_indexes ADD PRIMARY KEY (index_name);


