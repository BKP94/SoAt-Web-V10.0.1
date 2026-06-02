CREATE TABLE sm_lsr_m_contract (
	insurance_no char(15) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_lsr_m_contract ADD PRIMARY KEY (insurance_no,sm_seq);
ALTER TABLE sm_lsr_m_contract ALTER COLUMN sm_seq SET NOT NULL;


