CREATE TABLE sc_law_asset_coop (
	doc_no varchar(10) NOT NULL,
	membership_no varchar(15),
	asset_no varchar(10),
	purchase_date timestamp,
	purchase_price double precision DEFAULT 0,
	original_price double precision DEFAULT 0,
	market_price double precision DEFAULT 0,
	estimate_price double precision DEFAULT 0,
	operate_date timestamp NOT NULL,
	entry_id varchar(16),
	entry_date timestamp,
	branch_id varchar(6),
	cancel_status char(1) DEFAULT '0',
	cancel_id varchar(16),
	cancel_br varchar(6),
	cancel_date timestamp
) ;
ALTER TABLE sc_law_asset_coop ADD PRIMARY KEY (doc_no);
ALTER TABLE sc_law_asset_coop ALTER COLUMN doc_no SET NOT NULL;
ALTER TABLE sc_law_asset_coop ALTER COLUMN operate_date SET NOT NULL;


