CREATE TABLE sc_lon_m_ucf_loan_coll_crsable (
	loan_type varchar(6) NOT NULL DEFAULT '00',
	group_no smallint NOT NULL DEFAULT 0,
	collateral_type_code varchar(6) NOT NULL DEFAULT '00'
) ;
ALTER TABLE sc_lon_m_ucf_loan_coll_crsable ADD PRIMARY KEY (loan_type,group_no,collateral_type_code);


