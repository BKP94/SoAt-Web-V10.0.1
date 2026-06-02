CREATE TABLE sc_mem_m_member_aml (
	aml_date timestamp NOT NULL,
	seq_no integer NOT NULL,
	aml_prename varchar(50),
	aml_name varchar(50),
	aml_surname varchar(50),
	aml_id varchar(15),
	aml_birth varchar(50),
	aml_bookno varchar(200),
	aml_remark varchar(100),
	aml_status char(1) NOT NULL DEFAULT '0',
	entry_id varchar(16) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_br varchar(6) NOT NULL
) ;
ALTER TABLE sc_mem_m_member_aml ADD PRIMARY KEY (aml_date,seq_no);
ALTER TABLE sc_mem_m_member_aml ALTER COLUMN aml_date SET NOT NULL;
ALTER TABLE sc_mem_m_member_aml ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_mem_m_member_aml ALTER COLUMN aml_status SET NOT NULL;
ALTER TABLE sc_mem_m_member_aml ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_mem_m_member_aml ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_mem_m_member_aml ALTER COLUMN entry_br SET NOT NULL;


