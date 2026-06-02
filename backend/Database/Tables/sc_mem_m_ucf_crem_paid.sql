CREATE TABLE sc_mem_m_ucf_crem_paid (
	paid_type varchar(6) NOT NULL DEFAULT '00',
	paid_name varchar(50)
) ;
ALTER TABLE sc_mem_m_ucf_crem_paid ADD PRIMARY KEY (paid_type);
ALTER TABLE sc_mem_m_ucf_crem_paid ALTER COLUMN paid_type SET NOT NULL;


