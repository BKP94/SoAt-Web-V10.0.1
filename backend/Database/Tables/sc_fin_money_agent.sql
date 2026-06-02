CREATE TABLE sc_fin_money_agent (
	agent_no varchar(15) NOT NULL,
	item_no double precision NOT NULL DEFAULT 0,
	operate_date timestamp,
	return_method char(3) DEFAULT 'AGN',
	money_return decimal(15,2) DEFAULT 0,
	receive_year double precision NOT NULL DEFAULT 0,
	receive_month double precision NOT NULL DEFAULT 0,
	cancel_status char(1) DEFAULT '0',
	return_status char(1) DEFAULT '0',
	remark varchar(100),
	paid_method char(3),
	owner_name varchar(100),
	paid_id varchar(16),
	request_method varchar(3),
	request_bankid varchar(6),
	request_bankbr varchar(6),
	request_bankac varchar(15),
	request_status char(1),
	remark_desc varchar(100),
	tran_status char(1) DEFAULT '2',
	paid_date timestamp,
	request_id varchar(16),
	request_date timestamp,
	entry_id varchar(16),
	entry_date timestamp
) ;
ALTER TABLE sc_fin_money_agent ADD PRIMARY KEY (agent_no,item_no);
ALTER TABLE sc_fin_money_agent ALTER COLUMN agent_no SET NOT NULL;
ALTER TABLE sc_fin_money_agent ALTER COLUMN item_no SET NOT NULL;
ALTER TABLE sc_fin_money_agent ALTER COLUMN receive_year SET NOT NULL;
ALTER TABLE sc_fin_money_agent ALTER COLUMN receive_month SET NOT NULL;


