CREATE TABLE sc_dev_dbstr_constraints (
	constraint_name varchar(30) NOT NULL,
	constraint_type varchar(1),
	table_name varchar(30),
	r_constraint_name varchar(30),
	deferrable varchar(14),
	delete_rule varchar(9),
	search_condition varchar(100)
) ;
ALTER TABLE sc_dev_dbstr_constraints ADD PRIMARY KEY (constraint_name);


