CREATE TABLE sc_crem_dead_table (
	crem_code varchar(10) NOT NULL,
	receive_year double precision,
	receive_month double precision,
	dead_date timestamp,
	receive_status char(1) NOT NULL,
	entry_id varchar(50),
	entry_date timestamp
) ;
ALTER TABLE sc_crem_dead_table ADD PRIMARY KEY (crem_code);
ALTER TABLE sc_crem_dead_table ALTER COLUMN crem_code SET NOT NULL;
ALTER TABLE sc_crem_dead_table ALTER COLUMN receive_status SET NOT NULL;


