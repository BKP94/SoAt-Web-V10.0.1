CREATE TABLE sc_dep_m_signature_card (
	deposit_account_no char(15) NOT NULL,
	seq_no double precision NOT NULL
) ;
CREATE UNIQUE INDEX sc_dep_m_signature_card_x ON sc_dep_m_signature_card (deposit_account_no, seq_no);
ALTER TABLE sc_dep_m_signature_card ALTER COLUMN deposit_account_no SET NOT NULL;
ALTER TABLE sc_dep_m_signature_card ALTER COLUMN seq_no SET NOT NULL;


