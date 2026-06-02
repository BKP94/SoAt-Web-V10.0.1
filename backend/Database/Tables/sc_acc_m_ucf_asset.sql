CREATE TABLE sc_acc_m_ucf_asset (
	asset_group varchar(3) NOT NULL,
	asset_des varchar(200),
	asset_group_con varchar(3)
) ;
ALTER TABLE sc_acc_m_ucf_asset ADD PRIMARY KEY (asset_group);
ALTER TABLE sc_acc_m_ucf_asset ALTER COLUMN asset_group SET NOT NULL;


