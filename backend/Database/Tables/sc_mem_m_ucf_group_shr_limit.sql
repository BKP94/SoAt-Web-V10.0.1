CREATE TABLE sc_mem_m_ucf_group_shr_limit (
	group_buy_shr_limit varchar(6) NOT NULL DEFAULT '00',
	group_buy_shr_des varchar(100),
	buy_limit_amount double precision DEFAULT 0,
	time_buy_share double precision DEFAULT 0
) ;
ALTER TABLE sc_mem_m_ucf_group_shr_limit ADD PRIMARY KEY (group_buy_shr_limit);
ALTER TABLE sc_mem_m_ucf_group_shr_limit ALTER COLUMN group_buy_shr_limit SET NOT NULL;


