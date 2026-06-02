CREATE TABLE sc_acc_m_expire_detail_edit (
	meterial_id char(10),
	sequence_no double precision,
	seq_no double precision,
	operate_date timestamp,
	item_type char(3),
	amount decimal(15,2),
	total_amount decimal(15,2),
	present_value decimal(15,2),
	cal_expire_date timestamp,
	entry_id char(15),
	entry_date timestamp,
	type_expire char(10),
	operate_date_new timestamp,
	amount_new decimal(15,2),
	total_amount_new decimal(15,2),
	present_value_new decimal(15,2),
	cal_expire_date_new timestamp,
	edit_id varchar(50),
	edit_date timestamp,
	branch_id varchar(6),
	edit_branch_id varchar(6),
	rate_expire decimal(15,2)
) ;
CREATE INDEX idx_acc_expire_det_e_date ON sc_acc_m_expire_detail_edit (operate_date);
CREATE INDEX idx_acc_expire_det_e_metid ON sc_acc_m_expire_detail_edit (meterial_id);
CREATE INDEX idx_acc_expire_det_e_seqno ON sc_acc_m_expire_detail_edit (seq_no);


