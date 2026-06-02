CREATE TABLE sc_mem_m_ucf_crem_debtor (
	debtor_code char(3) NOT NULL,
	debtor_desc varchar(50),
	marktype varchar(6) DEFAULT '00'
) ;
ALTER TABLE sc_mem_m_ucf_crem_debtor ADD PRIMARY KEY (debtor_code);
ALTER TABLE sc_mem_m_ucf_crem_debtor ALTER COLUMN debtor_code SET NOT NULL;


