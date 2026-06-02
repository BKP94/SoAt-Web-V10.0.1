CREATE TABLE sc_acc_m_ucf_asset_2565 (
	asset_group varchar(6) NOT NULL,
	asset_des varchar(200),
	asset_group_con varchar(6)
) ;
ALTER TABLE sc_acc_m_ucf_asset_2565 ADD PRIMARY KEY (asset_group);
ALTER TABLE sc_acc_m_ucf_asset_2565 ALTER COLUMN asset_group SET NOT NULL;


