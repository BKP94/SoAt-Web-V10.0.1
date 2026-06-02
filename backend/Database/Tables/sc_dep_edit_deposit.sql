CREATE TABLE sc_dep_edit_deposit (
	deposit_account_no varchar(15) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	operate_date timestamp NOT NULL,
	pre_deposit_account_name varchar(200),
	deposit_account_name varchar(200),
	pre_deposit_objective varchar(200),
	deposit_objective varchar(200),
	pre_remark varchar(1000),
	remark varchar(1000)
) ;
ALTER TABLE sc_dep_edit_deposit ADD PRIMARY KEY (deposit_account_no,entry_date);
ALTER TABLE sc_dep_edit_deposit ALTER COLUMN deposit_account_no SET NOT NULL;
ALTER TABLE sc_dep_edit_deposit ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_dep_edit_deposit ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_dep_edit_deposit ALTER COLUMN operate_date SET NOT NULL;


