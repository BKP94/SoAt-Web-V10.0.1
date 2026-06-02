CREATE TABLE sm_com_m_receipt_item (
	receipt_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_com_m_receipt_item ADD PRIMARY KEY (receipt_no,seq_no,sm_seq);
ALTER TABLE sm_com_m_receipt_item ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_com_m_receipt_item ALTER COLUMN receipt_no SET NOT NULL;
ALTER TABLE sm_com_m_receipt_item ALTER COLUMN seq_no SET NOT NULL;


