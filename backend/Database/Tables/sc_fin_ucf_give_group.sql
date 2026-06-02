CREATE TABLE sc_fin_ucf_give_group (
	give_group varchar(15) NOT NULL,
	give_name varchar(200),
	receive_name varchar(200),
	give_rep varchar(6) NOT NULL,
	by_mem char(1) NOT NULL DEFAULT '0',
	own decimal(15,2) DEFAULT 0.00,
	kep1 decimal(15,2) DEFAULT 0.00,
	kep2 decimal(15,2) DEFAULT 0.00,
	kep3 decimal(15,2) DEFAULT 0.00,
	amount decimal(15,2) DEFAULT 0.00
) ;
ALTER TABLE sc_fin_ucf_give_group ADD PRIMARY KEY (give_group);
ALTER TABLE sc_fin_ucf_give_group ALTER COLUMN give_group SET NOT NULL;
ALTER TABLE sc_fin_ucf_give_group ALTER COLUMN give_rep SET NOT NULL;
ALTER TABLE sc_fin_ucf_give_group ALTER COLUMN by_mem SET NOT NULL;


