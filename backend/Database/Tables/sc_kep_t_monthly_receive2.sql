CREATE TABLE sc_kep_t_monthly_receive2 (
	membership_no char(7) NOT NULL,
	receive_year double precision NOT NULL,
	receive_month double precision NOT NULL,
	total_share_value decimal(15,2),
	total_interest_value decimal(15,2),
	receipt_no char(10),
	receipt_date timestamp,
	process_date timestamp,
	receipt_effectdate timestamp,
	receipt_paytype double precision,
	receipt_status char(1) NOT NULL,
	receipt_old_status char(1) NOT NULL,
	posting_status char(1) NOT NULL,
	receive_amount decimal(15,2),
	new_receipt_no char(15),
	remark char(50),
	receipt_return_date timestamp,
	seq_no double precision NOT NULL,
	tt char(1),
	old_receipt_no char(10),
	clearloan_date timestamp,
	kep_method char(3),
	kep_method_ref char(15),
	return_date timestamp,
	transfer_to_hr char(1),
	transfer_group double precision,
	share_amount decimal(15,2),
	return_newrep_no char(15),
	mproc_id char(16),
	mproc_time timestamp,
	mproc_pc char(3),
	member_group_no char(15) NOT NULL,
	cal_old_int_type char(1) NOT NULL,
	reason_return char(50),
	total_keep_notinput decimal(15,2) NOT NULL,
	return_money_status char(1) NOT NULL,
	kep_method_transfer char(1) NOT NULL,
	money_return_total decimal(15,2) NOT NULL,
	return_money_refno char(15),
	return_money_method char(3) NOT NULL,
	money_return_post decimal(15,2) NOT NULL,
	kep_method_amount decimal(15,2) NOT NULL,
	receipt_print char(10),
	mproc_br char(2) NOT NULL,
	return_auto char(1) NOT NULL,
	return_id char(16),
	return_time timestamp,
	return_pc char(3),
	return_br char(2),
	return_transfer char(1) NOT NULL,
	calint_date timestamp,
	salary_time smallint NOT NULL,
	vourcher_no_money_return char(15),
	group_position char(2),
	agent_active char(1) NOT NULL,
	agent_no char(15),
	kep_method_trandate timestamp,
	posted_run char(1) NOT NULL,
	keep_befor_return decimal(15,2),
	salary_file decimal(15,2) NOT NULL
) ;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN receive_year SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN receive_month SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN receipt_status SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN receipt_old_status SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN posting_status SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN member_group_no SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN cal_old_int_type SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN total_keep_notinput SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN return_money_status SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN kep_method_transfer SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN money_return_total SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN return_money_method SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN money_return_post SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN kep_method_amount SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN mproc_br SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN return_auto SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN return_transfer SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN salary_time SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN agent_active SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN posted_run SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_receive2 ALTER COLUMN salary_file SET NOT NULL;


