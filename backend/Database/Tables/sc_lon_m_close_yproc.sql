CREATE TABLE sc_lon_m_close_yproc (
	lon_year double precision NOT NULL DEFAULT 0,
	yproc_code varchar(6),
	entry_id varchar(16),
	entry_br varchar(6),
	entry_pc varchar(3),
	entry_time timestamp,
	seq_no double precision NOT NULL DEFAULT 0
) ;
ALTER TABLE sc_lon_m_close_yproc ADD PRIMARY KEY (lon_year,seq_no);
ALTER TABLE sc_lon_m_close_yproc ALTER COLUMN seq_no SET NOT NULL;


