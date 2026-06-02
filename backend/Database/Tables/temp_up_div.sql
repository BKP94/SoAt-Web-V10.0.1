CREATE TABLE temp_up_div (
	memno varchar(15) NOT NULL,
	memname varchar(100),
	div_amt decimal(15,2) DEFAULT 0.00,
	aver_amt decimal(15,2) DEFAULT 0.00,
	sum_amt decimal(15,2) DEFAULT 0.00,
	conno varchar(15),
	fee_amt decimal(15,2) DEFAULT 0.00,
	npl_amt decimal(15,2) DEFAULT 0.00,
	crem_amt decimal(15,2) DEFAULT 0.00,
	crem_to_dep decimal(15,2) DEFAULT 0.00,
	loan_amt decimal(15,2) DEFAULT 0.00,
	sze_amt decimal(15,2) DEFAULT 0.00,
	rsv_amt decimal(15,2) DEFAULT 0.00,
	coll_amt decimal(15,2) DEFAULT 0.00,
	dead_amt decimal(15,2) DEFAULT 0.00,
	net_amt decimal(15,2) DEFAULT 0.00,
	accno varchar(15),
	method_div varchar(3),
	bank_id varchar(6)
) ;
ALTER TABLE temp_up_div ADD PRIMARY KEY (memno);
ALTER TABLE temp_up_div ALTER COLUMN memno SET NOT NULL;


