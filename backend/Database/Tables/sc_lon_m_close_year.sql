CREATE TABLE sc_lon_m_close_year (
	lon_year numeric(38) NOT NULL DEFAULT 0,
	start_date timestamp,
	end_date timestamp,
	close_status char(1),
	close_id varchar(16),
	close_time timestamp,
	dividend_closed char(1) DEFAULT '0'
) ;
COMMENT ON TABLE sc_lon_m_close_year IS E'!NN!';
ALTER TABLE sc_lon_m_close_year ADD PRIMARY KEY (lon_year);


