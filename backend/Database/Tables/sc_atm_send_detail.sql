CREATE TABLE sc_atm_send_detail (
	operate_date timestamp NOT NULL,
	item_no smallint NOT NULL DEFAULT 0,
	bank_code varchar(6) NOT NULL,
	seq_no integer NOT NULL DEFAULT 0,
	membership_no varchar(15),
	trans_type varchar(3),
	item_type varchar(3),
	item_ref_no varchar(15),
	trans_amount decimal(15,2) DEFAULT 0,
	approve_amount decimal(15,2) DEFAULT 0,
	send_last_no double precision DEFAULT 0,
	bank_confirm char(1) DEFAULT '0',
	chg_docno varchar(15),
	coop_confirm char(1) DEFAULT '0',
	account_no varchar(15),
	seq_no_atm numeric(38) DEFAULT 0,
	modify_status char(1) DEFAULT '0',
	dep_activate char(1) DEFAULT '0',
	lon_activate char(1) DEFAULT '0',
	remark varchar(250)
) ;
ALTER TABLE sc_atm_send_detail ADD PRIMARY KEY (operate_date,item_no,bank_code,seq_no);
ALTER TABLE sc_atm_send_detail ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_atm_send_detail ALTER COLUMN item_no SET NOT NULL;
ALTER TABLE sc_atm_send_detail ALTER COLUMN bank_code SET NOT NULL;
ALTER TABLE sc_atm_send_detail ALTER COLUMN seq_no SET NOT NULL;


