CREATE TABLE sc_mem_m_insure_det (
	insurance_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	operate_date timestamp,
	period double precision DEFAULT 0,
	item_type varchar(6) NOT NULL DEFAULT '00',
	ref_docno varchar(50),
	insurance_amount decimal(15,2) DEFAULT 0,
	insurance_balance decimal(15,2) DEFAULT 0,
	insurance_arrear decimal(15,2) DEFAULT 0,
	insurance_arrear_all decimal(15,2) DEFAULT 0,
	amount_pay_arrear decimal(15,2) DEFAULT 0,
	entry_id varchar(16),
	entry_pc varchar(6),
	entry_date timestamp,
	entry_br varchar(6),
	amount_pay_all decimal(15,2) DEFAULT 0,
	remark varchar(250),
	addvance_balance decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_mem_m_insure_det ADD PRIMARY KEY (insurance_no,seq_no);
ALTER TABLE sc_mem_m_insure_det ALTER COLUMN insurance_no SET NOT NULL;
ALTER TABLE sc_mem_m_insure_det ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_mem_m_insure_det ALTER COLUMN item_type SET NOT NULL;


