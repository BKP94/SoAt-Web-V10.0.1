CREATE TABLE sc_acc_m_expire_estimate (
	meterial_id varchar(10) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	operate_date timestamp,
	item_type varchar(3),
	amount decimal(15,2) DEFAULT 0,
	total_amount decimal(15,2) DEFAULT 0,
	present_value decimal(15,2) DEFAULT 0,
	cal_expire_date timestamp,
	entry_id varchar(15),
	entry_date timestamp,
	branch_id varchar(6),
	rate_expire decimal(6,4) DEFAULT 0,
	acc_exp decimal(15,2) DEFAULT 0,
	day_cal double precision DEFAULT 0,
	begin_exp decimal(15,2) DEFAULT 0,
	type_exp varchar(3),
	ending_of_account_cal_current timestamp,
	cal_expire_date_from timestamp,
	bf_value decimal(15,2) DEFAULT 0,
	remark varchar(100),
	buy_in_year decimal(15,2) DEFAULT 0,
	sale_amount decimal(15,2)
) ;
ALTER TABLE sc_acc_m_expire_estimate ADD PRIMARY KEY (meterial_id,seq_no);
ALTER TABLE sc_acc_m_expire_estimate ALTER COLUMN meterial_id SET NOT NULL;
ALTER TABLE sc_acc_m_expire_estimate ALTER COLUMN seq_no SET NOT NULL;


