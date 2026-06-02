CREATE TABLE sm_com_m_receipt (
	receipt_no varchar(15) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_com_m_receipt ADD PRIMARY KEY (receipt_no,sm_seq);
ALTER TABLE sm_com_m_receipt ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_com_m_receipt ALTER COLUMN receipt_no SET NOT NULL;


