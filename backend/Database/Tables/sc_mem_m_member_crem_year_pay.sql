CREATE TABLE sc_mem_m_member_crem_year_pay (
	crem_round varchar(6) NOT NULL,
	crem_type varchar(6) NOT NULL DEFAULT '00',
	crem_year double precision NOT NULL DEFAULT 0,
	crem_special char(1) NOT NULL DEFAULT '0',
	crem_date timestamp,
	crem_amount decimal(15,2) DEFAULT 0,
	fee_register decimal(15,2) DEFAULT 0,
	fee_repair decimal(15,2) DEFAULT 0,
	crem_unpaid decimal(15,2) DEFAULT 0,
	fee_donat decimal(15,2) DEFAULT 0,
	crem_total decimal(15,2) DEFAULT 0,
	protec_fr timestamp,
	protec_to timestamp
) ;
ALTER TABLE sc_mem_m_member_crem_year_pay ADD PRIMARY KEY (crem_round,crem_type,crem_year,crem_special);
ALTER TABLE sc_mem_m_member_crem_year_pay ALTER COLUMN crem_round SET NOT NULL;
ALTER TABLE sc_mem_m_member_crem_year_pay ALTER COLUMN crem_type SET NOT NULL;
ALTER TABLE sc_mem_m_member_crem_year_pay ALTER COLUMN crem_year SET NOT NULL;
ALTER TABLE sc_mem_m_member_crem_year_pay ALTER COLUMN crem_special SET NOT NULL;


