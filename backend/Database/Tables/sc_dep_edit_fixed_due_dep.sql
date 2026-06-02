CREATE TABLE sc_dep_edit_fixed_due_dep (
	deposit_account_no varchar(15) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	operate_date timestamp NOT NULL,
	pre_fixed_due_dep varchar(15),
	fixed_due_dep varchar(15),
	entry_br varchar(6)
) ;
ALTER TABLE sc_dep_edit_fixed_due_dep ADD PRIMARY KEY (deposit_account_no,entry_date);
ALTER TABLE sc_dep_edit_fixed_due_dep ALTER COLUMN deposit_account_no SET NOT NULL;
ALTER TABLE sc_dep_edit_fixed_due_dep ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_dep_edit_fixed_due_dep ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_dep_edit_fixed_due_dep ALTER COLUMN operate_date SET NOT NULL;


