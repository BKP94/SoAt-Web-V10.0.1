CREATE TABLE sm_lon_m_ucf_loan_card_item (
	item_type_code varchar(15) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_lon_m_ucf_loan_card_item ADD PRIMARY KEY (item_type_code,sm_seq);
ALTER TABLE sm_lon_m_ucf_loan_card_item ALTER COLUMN sm_seq SET NOT NULL;


