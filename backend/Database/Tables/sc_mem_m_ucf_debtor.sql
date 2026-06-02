CREATE TABLE sc_mem_m_ucf_debtor (
	debtor_code varchar(6) NOT NULL,
	debtor_desc varchar(250),
	marktype varchar(6),
	sort_order decimal(15,2) DEFAULT 0
) ;
COMMENT ON TABLE sc_mem_m_ucf_debtor IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_ucf_debtor.debtor_code IS E'!N??????????????N!';
COMMENT ON COLUMN sc_mem_m_ucf_debtor.debtor_desc IS E'!N??????????N!';
COMMENT ON COLUMN sc_mem_m_ucf_debtor.marktype IS E'!NN!';
ALTER TABLE sc_mem_m_ucf_debtor ADD PRIMARY KEY (debtor_code);


