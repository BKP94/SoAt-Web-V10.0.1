CREATE TABLE sc_inv_bill_market_value (
	bill_no varchar(15) NOT NULL,
	operate_date timestamp NOT NULL,
	unit_market_price decimal(15,6) NOT NULL,
	market_value decimal(15,2) NOT NULL,
	differ decimal(15,2) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	client_name varchar(20) NOT NULL,
	branch_id varchar(6) NOT NULL,
	status char(1) NOT NULL
) ;
ALTER TABLE sc_inv_bill_market_value ADD PRIMARY KEY (bill_no,operate_date);
ALTER TABLE sc_inv_bill_market_value ALTER COLUMN bill_no SET NOT NULL;
ALTER TABLE sc_inv_bill_market_value ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_inv_bill_market_value ALTER COLUMN unit_market_price SET NOT NULL;
ALTER TABLE sc_inv_bill_market_value ALTER COLUMN market_value SET NOT NULL;
ALTER TABLE sc_inv_bill_market_value ALTER COLUMN differ SET NOT NULL;
ALTER TABLE sc_inv_bill_market_value ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_inv_bill_market_value ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_inv_bill_market_value ALTER COLUMN client_name SET NOT NULL;
ALTER TABLE sc_inv_bill_market_value ALTER COLUMN branch_id SET NOT NULL;
ALTER TABLE sc_inv_bill_market_value ALTER COLUMN status SET NOT NULL;


