CREATE TABLE sc_mem_m_insur_gain (
	insurance_no varchar(15) NOT NULL,
	rec_no numeric(38) NOT NULL,
	prename_code varchar(6),
	gain_name varchar(50),
	gain_surname varchar(50),
	conceern_code varchar(50),
	gain_id_card varchar(15),
	gain_percent2 decimal(6,4),
	entry_id varchar(16),
	entry_date timestamp,
	entry_br varchar(6)
) ;
ALTER TABLE sc_mem_m_insur_gain ADD PRIMARY KEY (insurance_no,rec_no);
ALTER TABLE sc_mem_m_insur_gain ALTER COLUMN rec_no SET NOT NULL;


