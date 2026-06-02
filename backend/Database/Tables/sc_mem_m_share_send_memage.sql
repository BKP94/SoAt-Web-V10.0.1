CREATE TABLE sc_mem_m_share_send_memage (
	mem_age numeric(38) NOT NULL DEFAULT 0,
	max_share_salalry decimal(10,6) DEFAULT 0
) ;
ALTER TABLE sc_mem_m_share_send_memage ADD PRIMARY KEY (mem_age);


