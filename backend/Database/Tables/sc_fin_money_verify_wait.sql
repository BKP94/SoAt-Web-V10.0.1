CREATE TABLE sc_fin_money_verify_wait (
	bank_fin varchar(6) NOT NULL,
	operate_date timestamp NOT NULL,
	seq_no numeric(38) NOT NULL DEFAULT 0,
	verify_amount decimal(15,2) DEFAULT 0,
	entry_id varchar(16),
	entry_date timestamp,
	entry_pc varchar(3),
	entry_br varchar(6),
	cancel_status char(1) DEFAULT '0',
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_pc varchar(3),
	cancel_br varchar(6),
	post_fin char(1) DEFAULT '0',
	vourcher_no varchar(15),
	count_item numeric(38) DEFAULT 0
) ;
ALTER TABLE sc_fin_money_verify_wait ADD PRIMARY KEY (bank_fin,operate_date,seq_no);


