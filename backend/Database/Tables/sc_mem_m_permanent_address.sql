CREATE TABLE sc_mem_m_permanent_address (
	membership_no char(7) NOT NULL,
	permanent_address char(200),
	permanent_road char(30),
	permanent_tambol char(50),
	permanent_district_code char(2),
	permanent_province_code char(2),
	permanent_postcode char(10),
	permanent_soi char(50),
	permanent_moo char(10),
	permanent_telephone char(50)
) ;
ALTER TABLE sc_mem_m_permanent_address ALTER COLUMN membership_no SET NOT NULL;


