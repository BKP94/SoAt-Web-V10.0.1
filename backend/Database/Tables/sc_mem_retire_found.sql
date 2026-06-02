CREATE TABLE sc_mem_retire_found (
	system varchar(2) NOT NULL,
	name_of_system varchar(100) NOT NULL,
	age_member double precision NOT NULL,
	dead_status char(1) NOT NULL,
	begin_date_dead timestamp NOT NULL,
	end_date_dead timestamp NOT NULL,
	begin_of_member timestamp NOT NULL,
	account_year double precision NOT NULL,
	payment_share_status char(1) NOT NULL,
	payment_date_def timestamp,
	percent_of_age decimal(15,4) NOT NULL,
	percent_of_share decimal(15,4) NOT NULL
) ;
ALTER TABLE sc_mem_retire_found ADD PRIMARY KEY (system);
ALTER TABLE sc_mem_retire_found ALTER COLUMN system SET NOT NULL;
ALTER TABLE sc_mem_retire_found ALTER COLUMN name_of_system SET NOT NULL;
ALTER TABLE sc_mem_retire_found ALTER COLUMN age_member SET NOT NULL;
ALTER TABLE sc_mem_retire_found ALTER COLUMN dead_status SET NOT NULL;
ALTER TABLE sc_mem_retire_found ALTER COLUMN begin_date_dead SET NOT NULL;
ALTER TABLE sc_mem_retire_found ALTER COLUMN end_date_dead SET NOT NULL;
ALTER TABLE sc_mem_retire_found ALTER COLUMN begin_of_member SET NOT NULL;
ALTER TABLE sc_mem_retire_found ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_mem_retire_found ALTER COLUMN payment_share_status SET NOT NULL;
ALTER TABLE sc_mem_retire_found ALTER COLUMN percent_of_age SET NOT NULL;
ALTER TABLE sc_mem_retire_found ALTER COLUMN percent_of_share SET NOT NULL;


