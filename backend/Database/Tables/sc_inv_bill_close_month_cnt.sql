CREATE TABLE sc_inv_bill_close_month_cnt (
	monthly_date timestamp NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL
) ;
ALTER TABLE sc_inv_bill_close_month_cnt ADD PRIMARY KEY (monthly_date);
ALTER TABLE sc_inv_bill_close_month_cnt ALTER COLUMN monthly_date SET NOT NULL;
ALTER TABLE sc_inv_bill_close_month_cnt ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_inv_bill_close_month_cnt ALTER COLUMN entry_id SET NOT NULL;


