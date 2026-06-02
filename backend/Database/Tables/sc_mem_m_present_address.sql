CREATE TABLE sc_mem_m_present_address (
	membership_no char(15) NOT NULL,
	present_address char(50),
	present_moo char(50),
	present_road char(50),
	present_soi char(50),
	present_tambol char(50),
	present_district_code char(2),
	present_province_code char(2),
	present_postcode char(10),
	present_telephone char(50)
) ;
CREATE UNIQUE INDEX sc_mem_m_present_address_x ON sc_mem_m_present_address (membership_no);
ALTER TABLE sc_mem_m_present_address ALTER COLUMN membership_no SET NOT NULL;


