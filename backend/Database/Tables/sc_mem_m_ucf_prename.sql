CREATE TABLE sc_mem_m_ucf_prename (
	prename_code varchar(6) NOT NULL DEFAULT '000',
	prename varchar(30),
	sex char(1) DEFAULT 'M',
	marriage_status char(1) DEFAULT '0',
	group_rank char(1) DEFAULT 'E',
	invest_status char(1) DEFAULT '0'
) ;
COMMENT ON TABLE sc_mem_m_ucf_prename IS E'!N?????????????? - ????????????N!';
COMMENT ON COLUMN sc_mem_m_ucf_prename.marriage_status IS E'!N????N!!M0 - ???, 1 - ????M!';
COMMENT ON COLUMN sc_mem_m_ucf_prename.prename IS E'!N????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_prename.prename_code IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_prename.sex IS E'!N???N!!MM - ???, F - ????M!';
ALTER TABLE sc_mem_m_ucf_prename ADD PRIMARY KEY (prename_code);


