CREATE TABLE sm_mem_m_insure (
	insurance_no varchar(15) NOT NULL DEFAULT '<NEW>',
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_insure ADD PRIMARY KEY (insurance_no,sm_seq);
ALTER TABLE sm_mem_m_insure ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_mem_m_insure ALTER COLUMN insurance_no SET NOT NULL;


