CREATE TABLE sc_adm_tun_reward (
	form_no varchar(10),
	membership_no varchar(7),
	req_date timestamp,
	pay_day timestamp,
	money_pay decimal(10,2),
	lastpay_day timestamp,
	firstpay_date timestamp,
	footnote varchar(50),
	pay_by char(1),
	entry_id varchar(10),
	entry_date timestamp,
	entry_branch varchar(10),
	paid_amount decimal(10,2),
	paid_entry_id varchar(10),
	paid_entry_date timestamp,
	account_no varchar(20),
	detail_pay varchar(100),
	total_pay decimal(10,2),
	total_mem_age smallint,
	remain_pay decimal(10,2),
	paid_status char(1),
	rew_type varchar(6),
	rew_code char(1),
	cal_date timestamp
) ;


