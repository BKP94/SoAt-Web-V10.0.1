CREATE TABLE sc_mem_m_ucf_application_type (
	appl_type_code char(1) NOT NULL,
	appl_type_name varchar(30),
	resign_month double precision,
	age_in_coop varchar(20),
	share_type_code varchar(6),
	share_restore decimal(15,2),
	application_fee decimal(15,2),
	member_status_code char(1),
	deposit_type_code varchar(6),
	deposit_amount decimal(15,2) DEFAULT 0,
	invest_status char(1) DEFAULT '0'
) ;
COMMENT ON TABLE sc_mem_m_ucf_application_type IS E'!N?????????????? - ??????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_application_type.appl_type_code IS E'!N??????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_application_type.appl_type_name IS E'!N????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_application_type.application_fee IS E'!N????????????N!!MM!';
ALTER TABLE sc_mem_m_ucf_application_type ADD PRIMARY KEY (appl_type_code);


