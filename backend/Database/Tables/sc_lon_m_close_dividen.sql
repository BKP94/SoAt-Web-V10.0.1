CREATE TABLE sc_lon_m_close_dividen (
	div_year numeric(38) NOT NULL DEFAULT 0,
	close_status char(1) DEFAULT '0',
	open_id varchar(16),
	open_time timestamp,
	open_pc varchar(3),
	close_id varchar(16),
	close_time timestamp,
	close_pc varchar(3)
) ;
ALTER TABLE sc_lon_m_close_dividen ADD PRIMARY KEY (div_year);


