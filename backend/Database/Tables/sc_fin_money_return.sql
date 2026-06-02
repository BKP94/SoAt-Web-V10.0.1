CREATE TABLE sc_fin_money_return (
	membership_no varchar(15) NOT NULL,
	item_no double precision NOT NULL DEFAULT 0,
	operate_date timestamp,
	return_method char(3),
	money_return double precision DEFAULT 0,
	refno1 varchar(15),
	refno2 varchar(15),
	cancel_status char(1) DEFAULT '0',
	return_status char(1) DEFAULT '0',
	item_i double precision DEFAULT 0,
	item_p double precision DEFAULT 0,
	remark varchar(4000),
	manual_status char(1) NOT NULL DEFAULT '0',
	manual_type char(3),
	paid_method char(3),
	owner_name varchar(100),
	paid_id varchar(16),
	request_method varchar(3),
	request_bankid varchar(6),
	request_bankbr varchar(6),
	request_bankac varchar(15),
	request_status char(1),
	by_other char(1) DEFAULT '0',
	remark_desc varchar(100),
	tran_status char(1) DEFAULT '2',
	mrt_able char(1) DEFAULT '0',
	rkeep_memno varchar(15),
	rkeep_year integer,
	rkeep_month integer,
	rkeep_seqno integer,
	rkeep_recno integer,
	cancel_date timestamp,
	paid_date timestamp,
	request_id varchar(16),
	request_date timestamp,
	div_amount decimal(15,2) DEFAULT 0,
	aver_amount decimal(15,2) DEFAULT 0,
	reward_amount decimal(15,2) DEFAULT 0,
	entry_id varchar(16),
	entry_date timestamp,
	receipt_no varchar(15)
) ;
ALTER TABLE sc_fin_money_return ADD PRIMARY KEY (membership_no,item_no);
ALTER TABLE sc_fin_money_return ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_fin_money_return ALTER COLUMN item_no SET NOT NULL;
ALTER TABLE sc_fin_money_return ALTER COLUMN manual_status SET NOT NULL;


