CREATE TABLE sc_dep_edit_monthly_deposit (
	deposit_account_no varchar(15) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	operate_date timestamp NOT NULL,
	pre_monthly_deposit_amount decimal(15,2) DEFAULT 0,
	monthly_deposit_amount decimal(15,2) DEFAULT 0,
	entry_br varchar(6),
	pre_monthly_deposit_status char(1) DEFAULT '0',
	monthly_deposit_status char(1) DEFAULT '0'
) ;
ALTER TABLE sc_dep_edit_monthly_deposit ADD PRIMARY KEY (deposit_account_no,entry_date);
ALTER TABLE sc_dep_edit_monthly_deposit ALTER COLUMN deposit_account_no SET NOT NULL;
ALTER TABLE sc_dep_edit_monthly_deposit ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_dep_edit_monthly_deposit ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_dep_edit_monthly_deposit ALTER COLUMN operate_date SET NOT NULL;


