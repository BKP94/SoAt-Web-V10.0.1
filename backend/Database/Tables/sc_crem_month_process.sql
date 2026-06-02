CREATE TABLE sc_crem_month_process (
	year_process double precision NOT NULL,
	month_process double precision NOT NULL,
	carcass_count double precision,
	process_date timestamp,
	receipt_date timestamp,
	post_date timestamp,
	post_status char(1),
	entry_id varchar(10)
) ;
ALTER TABLE sc_crem_month_process ADD PRIMARY KEY (year_process,month_process);
ALTER TABLE sc_crem_month_process ALTER COLUMN year_process SET NOT NULL;
ALTER TABLE sc_crem_month_process ALTER COLUMN month_process SET NOT NULL;


