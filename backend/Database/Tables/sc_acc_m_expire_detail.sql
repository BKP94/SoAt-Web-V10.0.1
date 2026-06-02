CREATE TABLE sc_acc_m_expire_detail (
	meterial_id varchar(10) NOT NULL,
	seq_no double precision NOT NULL,
	operate_date timestamp,
	item_type varchar(3),
	amount decimal(15,2),
	total_amount decimal(15,2),
	present_value decimal(15,2),
	cal_expire_date timestamp,
	entry_id varchar(15),
	entry_date timestamp,
	branch_id varchar(6),
	rate_expire decimal(12,10),
	acc_exp decimal(15,2),
	day_cal double precision,
	begin_exp decimal(15,2),
	type_exp varchar(3),
	ending_of_account_cal_current timestamp,
	cal_expire_date_from timestamp,
	bf_value decimal(15,2) DEFAULT 0,
	remark varchar(100),
	buy_in_year decimal(15,2) DEFAULT 0,
	sale_amount decimal(15,2)
) ;
COMMENT ON TABLE sc_acc_m_expire_detail IS E'!NN!';
CREATE INDEX idx_acc_expire_det_meter_id ON sc_acc_m_expire_detail (meterial_id);
CREATE INDEX idx_acc_expire_det_operdate ON sc_acc_m_expire_detail (operate_date);
CREATE INDEX idx_acc_expire_det_seqno ON sc_acc_m_expire_detail (seq_no);
ALTER TABLE sc_acc_m_expire_detail ADD PRIMARY KEY (meterial_id,seq_no);


