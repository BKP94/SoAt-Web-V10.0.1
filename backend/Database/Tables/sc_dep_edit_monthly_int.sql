CREATE TABLE sc_dep_edit_monthly_int (
	deposit_account_no varchar(15) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	entry_br varchar(6) NOT NULL,
	operate_date timestamp NOT NULL,
	pre_monthly_int_status char(1) DEFAULT '0',
	monthly_int_status char(1) DEFAULT '0',
	pre_method_int_month char(1) DEFAULT '0',
	method_int_month char(1) DEFAULT '0',
	pre_deposit_account_no_other varchar(15),
	deposit_account_no_other varchar(15),
	pre_account_bank varchar(30),
	account_bank varchar(30)
) ;
ALTER TABLE sc_dep_edit_monthly_int ADD PRIMARY KEY (deposit_account_no,entry_date);
ALTER TABLE sc_dep_edit_monthly_int ALTER COLUMN deposit_account_no SET NOT NULL;
ALTER TABLE sc_dep_edit_monthly_int ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_dep_edit_monthly_int ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_dep_edit_monthly_int ALTER COLUMN entry_br SET NOT NULL;
ALTER TABLE sc_dep_edit_monthly_int ALTER COLUMN operate_date SET NOT NULL;


