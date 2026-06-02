CREATE TABLE sc_mem_m_ucf_district (
	district_code varchar(6) NOT NULL,
	province_code varchar(6) NOT NULL,
	district_name varchar(50),
	post_code varchar(5)
) ;
COMMENT ON TABLE sc_mem_m_ucf_district IS E'!N?????????????? - ????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_district.district_code IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_district.district_name IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_district.post_code IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_district.province_code IS E'!N???????????N!!MM!';
CREATE INDEX idx_mem_ucf_district_province_ ON sc_mem_m_ucf_district (province_code);
ALTER TABLE sc_mem_m_ucf_district ADD PRIMARY KEY (province_code,district_code);


