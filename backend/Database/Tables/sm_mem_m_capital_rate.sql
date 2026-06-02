CREATE TABLE sm_mem_m_capital_rate (
	lon_year bigint NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_capital_rate ADD PRIMARY KEY (lon_year,sm_seq);
ALTER TABLE sm_mem_m_capital_rate ALTER COLUMN sm_seq SET NOT NULL;


