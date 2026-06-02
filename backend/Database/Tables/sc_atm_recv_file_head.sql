CREATE TABLE sc_atm_recv_file_head (
	operate_date timestamp NOT NULL,
	item_no smallint NOT NULL DEFAULT 0,
	operate_time varchar(23),
	bank_code varchar(6),
	file_name varchar(100),
	file_code varchar(15),
	entry_id varchar(16),
	entry_br varchar(6),
	entry_pc varchar(3),
	entry_date timestamp,
	total_recode smallint DEFAULT 0,
	total_detail smallint DEFAULT 0,
	analy_status char(1) DEFAULT '0',
	analy_tot_success smallint DEFAULT 0,
	analy_tot_failure smallint DEFAULT 0,
	post_status char(1) DEFAULT '0',
	post_tot_success smallint DEFAULT 0,
	post_tot_failure smallint DEFAULT 0,
	cancel_status char(1) DEFAULT '0',
	cancel_id varchar(16),
	cancel_br varchar(6)
) ;
ALTER TABLE sc_atm_recv_file_head ADD PRIMARY KEY (operate_date,item_no);


