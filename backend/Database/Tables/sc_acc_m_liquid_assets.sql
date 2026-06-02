CREATE TABLE sc_acc_m_liquid_assets (
	assets_type varchar(6) NOT NULL DEFAULT '00',
	account_id varchar(8) NOT NULL
) ;
ALTER TABLE sc_acc_m_liquid_assets ADD PRIMARY KEY (assets_type,account_id);
ALTER TABLE sc_acc_m_liquid_assets ALTER COLUMN assets_type SET NOT NULL;
ALTER TABLE sc_acc_m_liquid_assets ALTER COLUMN account_id SET NOT NULL;


