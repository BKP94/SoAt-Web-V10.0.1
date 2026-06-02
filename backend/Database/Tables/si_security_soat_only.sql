CREATE TABLE si_security_soat_only (
	table_name varchar(30) NOT NULL,
	column_name varchar(30) NOT NULL
) ;
ALTER TABLE si_security_soat_only ADD PRIMARY KEY (table_name,column_name);
ALTER TABLE si_security_soat_only ALTER COLUMN table_name SET NOT NULL;
ALTER TABLE si_security_soat_only ALTER COLUMN column_name SET NOT NULL;


