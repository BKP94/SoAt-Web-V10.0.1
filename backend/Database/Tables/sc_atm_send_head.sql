CREATE TABLE sc_atm_send_head (
	operate_date timestamp NOT NULL,
	item_no smallint NOT NULL DEFAULT 0,
	bank_code varchar(6) NOT NULL,
	entry_id varchar(16),
	entry_date timestamp,
	entry_br varchar(6),
	entry_pc varchar(3),
	item_new char(1) DEFAULT '0',
	item_mod char(1) DEFAULT '0',
	item_del char(1) DEFAULT '0',
	item_chg char(1) DEFAULT '0',
	item_drop char(1) DEFAULT '0',
	item_req char(1) DEFAULT '0',
	item_cdf char(1) DEFAULT '0',
	item_replace char(1) DEFAULT '0',
	item_zero char(1) DEFAULT '0',
	send_lon char(1) DEFAULT '0',
	send_dep char(1) DEFAULT '0',
	file_name varchar(100),
	count_all smallint DEFAULT 0,
	count_lon smallint DEFAULT 0,
	count_dep smallint DEFAULT 0,
	sum_amount_all decimal(15,2) DEFAULT 0,
	sum_amount_lon decimal(15,2) DEFAULT 0,
	sum_amount_dep decimal(15,2) DEFAULT 0,
	sum_approve_all decimal(15,2) DEFAULT 0,
	sum_approve_lon decimal(15,2) DEFAULT 0,
	sum_approve_dep decimal(15,2) DEFAULT 0,
	file_code char(15) DEFAULT 'PMT',
	item_month char(1) DEFAULT '0'
) ;
ALTER TABLE sc_atm_send_head ADD PRIMARY KEY (operate_date,item_no,bank_code);
ALTER TABLE sc_atm_send_head ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_atm_send_head ALTER COLUMN item_no SET NOT NULL;
ALTER TABLE sc_atm_send_head ALTER COLUMN bank_code SET NOT NULL;


