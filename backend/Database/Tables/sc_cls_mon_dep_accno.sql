CREATE TABLE sc_cls_mon_dep_accno (
	monthly_date timestamp NOT NULL,
	deposit_account_no varchar(15) NOT NULL,
	deposit_type_code varchar(6) DEFAULT '00',
	membership_no varchar(15),
	deposit_opened_date timestamp,
	deposit_account_name varchar(200),
	deposit_balance double precision DEFAULT 0,
	withdrawable_amount double precision DEFAULT 0,
	cheque_pending_amount double precision DEFAULT 0,
	loan_holding_amount double precision DEFAULT 0,
	deposit_standsecurity_amount double precision DEFAULT 0,
	sequester_status char(1) DEFAULT '0',
	accumulate_interest double precision DEFAULT 0,
	last_calcint_date timestamp,
	close_status char(1) DEFAULT '0',
	deposit_closing_date timestamp,
	int_arrear decimal(15,2) DEFAULT 0.00,
	begin_balance decimal(15,2) DEFAULT 0,
	dca_amount decimal(15,2) DEFAULT 0,
	wca_amount decimal(15,2) DEFAULT 0,
	int_amount decimal(15,2) DEFAULT 0,
	tax_amount decimal(15,2) DEFAULT 0,
	oth_add_amount decimal(15,2) DEFAULT 0,
	oth_down_amount decimal(15,2) DEFAULT 0,
	deposit_account_no_other varchar(15),
	last_movement timestamp,
	last_item_type varchar(3)
) ;
ALTER TABLE sc_cls_mon_dep_accno ADD PRIMARY KEY (monthly_date,deposit_account_no);
ALTER TABLE sc_cls_mon_dep_accno ALTER COLUMN monthly_date SET NOT NULL;
ALTER TABLE sc_cls_mon_dep_accno ALTER COLUMN deposit_account_no SET NOT NULL;


