CREATE TABLE sc_law_asset_coll (
	asset_no varchar(10) NOT NULL,
	membership_no varchar(15) NOT NULL,
	coll_ref varchar(50),
	loan_contract_no varchar(15),
	prosec_no varchar(15) NOT NULL,
	status char(1) NOT NULL DEFAULT '0'
) ;
ALTER TABLE sc_law_asset_coll ADD PRIMARY KEY (asset_no,prosec_no);
ALTER TABLE sc_law_asset_coll ALTER COLUMN asset_no SET NOT NULL;
ALTER TABLE sc_law_asset_coll ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_law_asset_coll ALTER COLUMN prosec_no SET NOT NULL;
ALTER TABLE sc_law_asset_coll ALTER COLUMN status SET NOT NULL;


