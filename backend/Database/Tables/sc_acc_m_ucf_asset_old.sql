CREATE TABLE sc_acc_m_ucf_asset_old (
	asset_old_group varchar(3) NOT NULL,
	asset_des varchar(200),
	asset_old_group_con varchar(3)
) ;
ALTER TABLE sc_acc_m_ucf_asset_old ADD PRIMARY KEY (asset_old_group);
ALTER TABLE sc_acc_m_ucf_asset_old ALTER COLUMN asset_old_group SET NOT NULL;


