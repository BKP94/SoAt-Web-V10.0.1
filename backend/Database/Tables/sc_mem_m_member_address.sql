CREATE TABLE sc_mem_m_member_address (
	membership_no varchar(15) NOT NULL,
	address_type char(1) NOT NULL,
	address_no varchar(100),
	moo varchar(50),
	road varchar(50),
	soi varchar(50),
	tambol varchar(50),
	district_code varchar(6) DEFAULT '00',
	province_code varchar(6),
	postcode varchar(10),
	telephone varchar(50),
	mooban varchar(100),
	address_no_back varchar(100),
	bk_tambol varchar(50),
	bk_distinct varchar(6),
	bk_province varchar(6)
) ;
COMMENT ON TABLE sc_mem_m_member_address IS E'!N?????????????N!';
COMMENT ON COLUMN sc_mem_m_member_address.address_no IS E'!N??????N!';
COMMENT ON COLUMN sc_mem_m_member_address.address_type IS E'!N????????????????N!!M0=???????????????,1=?????????????????????,2=????????????????????????M!';
COMMENT ON COLUMN sc_mem_m_member_address.district_code IS E'!N?????N!';
COMMENT ON COLUMN sc_mem_m_member_address.membership_no IS E'!N?????????????N!';
COMMENT ON COLUMN sc_mem_m_member_address.moo IS E'!N???????N!';
COMMENT ON COLUMN sc_mem_m_member_address.mooban IS E'!N????????N!';
COMMENT ON COLUMN sc_mem_m_member_address.postcode IS E'!N????????????N!';
COMMENT ON COLUMN sc_mem_m_member_address.province_code IS E'!N???????N!';
COMMENT ON COLUMN sc_mem_m_member_address.road IS E'!N???N!';
COMMENT ON COLUMN sc_mem_m_member_address.soi IS E'!N???N!';
COMMENT ON COLUMN sc_mem_m_member_address.tambol IS E'!N????N!';
COMMENT ON COLUMN sc_mem_m_member_address.telephone IS E'!N?????????????N!';
CREATE INDEX idx_mem_addr ON sc_mem_m_member_address (membership_no);
CREATE INDEX idx_mem_addr_address_type ON sc_mem_m_member_address (address_type);
CREATE INDEX idx_mem_addr_district ON sc_mem_m_member_address (district_code);
CREATE INDEX idx_mem_addr_province ON sc_mem_m_member_address (province_code);
ALTER TABLE sc_mem_m_member_address ADD PRIMARY KEY (membership_no,address_type);


