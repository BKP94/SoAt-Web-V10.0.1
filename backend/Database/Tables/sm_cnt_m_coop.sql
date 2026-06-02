CREATE TABLE sm_cnt_m_coop (
	coop_registered_no varchar(15) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_cnt_m_coop ADD PRIMARY KEY (coop_registered_no,sm_seq);
ALTER TABLE sm_cnt_m_coop ALTER COLUMN sm_seq SET NOT NULL;


