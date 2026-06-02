CREATE TABLE sc_fin_m_bank_lookup (
	item_desc varchar(15) NOT NULL,
	lookup_data varchar(20) NOT NULL
) ;
ALTER TABLE sc_fin_m_bank_lookup ADD PRIMARY KEY (item_desc);
ALTER TABLE sc_fin_m_bank_lookup ALTER COLUMN item_desc SET NOT NULL;
ALTER TABLE sc_fin_m_bank_lookup ALTER COLUMN lookup_data SET NOT NULL;


