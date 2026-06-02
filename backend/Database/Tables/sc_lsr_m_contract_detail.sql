CREATE TABLE sc_lsr_m_contract_detail (
	insurance_no char(15) NOT NULL,
	seq_no double precision NOT NULL,
	operate_date timestamp NOT NULL,
	doc_no char(15) NOT NULL,
	item_type char(3) NOT NULL,
	insurance_amount decimal(15,2) NOT NULL,
	total_balance decimal(15,2) NOT NULL,
	status double precision NOT NULL,
	entry_id char(10) NOT NULL,
	entry_date timestamp NOT NULL,
	remark char(50),
	post_status char(2)
) ;
CREATE UNIQUE INDEX sc_lsr_m_contract_detail_x ON sc_lsr_m_contract_detail (insurance_no, seq_no);
ALTER TABLE sc_lsr_m_contract_detail ALTER COLUMN insurance_no SET NOT NULL;
ALTER TABLE sc_lsr_m_contract_detail ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_lsr_m_contract_detail ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_lsr_m_contract_detail ALTER COLUMN doc_no SET NOT NULL;
ALTER TABLE sc_lsr_m_contract_detail ALTER COLUMN item_type SET NOT NULL;
ALTER TABLE sc_lsr_m_contract_detail ALTER COLUMN insurance_amount SET NOT NULL;
ALTER TABLE sc_lsr_m_contract_detail ALTER COLUMN total_balance SET NOT NULL;
ALTER TABLE sc_lsr_m_contract_detail ALTER COLUMN status SET NOT NULL;
ALTER TABLE sc_lsr_m_contract_detail ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_lsr_m_contract_detail ALTER COLUMN entry_date SET NOT NULL;


