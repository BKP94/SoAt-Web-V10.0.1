CREATE TABLE sc_lon_m_ucf_collateral_type (
	collateral_type_code varchar(6) NOT NULL,
	collateral_description varchar(100),
	estimate_value decimal(6,4),
	base_collateral_status char(1),
	no_refownno char(1) DEFAULT '0',
	estimate_amount decimal(15,2) DEFAULT 0,
	salary_status char(1),
	group_report char(2),
	law_status char(1),
	refin_status char(1)
) ;
COMMENT ON TABLE sc_lon_m_ucf_collateral_type IS E'!N??????????????? - ????????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_ucf_collateral_type.collateral_description IS E'!N????????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_ucf_collateral_type.collateral_type_code IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_lon_m_ucf_collateral_type.estimate_value IS E'!N?????????( % ??????????????)N!!MM!';
ALTER TABLE sc_lon_m_ucf_collateral_type ADD PRIMARY KEY (collateral_type_code);


