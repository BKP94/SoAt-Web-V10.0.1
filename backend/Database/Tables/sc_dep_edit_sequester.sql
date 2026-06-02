CREATE TABLE sc_dep_edit_sequester (
	deposit_account_no varchar(15) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	entry_br varchar(6) NOT NULL,
	operate_date timestamp NOT NULL,
	pre_sequester_status char(1),
	sequester_status char(1),
	pre_sequester_amount decimal(15,2) DEFAULT 0.00,
	sequester_amount decimal(15,2) DEFAULT 0.00,
	pre_remark_seques varchar(200),
	remark_seques varchar(200)
) ;
ALTER TABLE sc_dep_edit_sequester ADD PRIMARY KEY (deposit_account_no,entry_date);
ALTER TABLE sc_dep_edit_sequester ALTER COLUMN deposit_account_no SET NOT NULL;
ALTER TABLE sc_dep_edit_sequester ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_dep_edit_sequester ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_dep_edit_sequester ALTER COLUMN entry_br SET NOT NULL;
ALTER TABLE sc_dep_edit_sequester ALTER COLUMN operate_date SET NOT NULL;


