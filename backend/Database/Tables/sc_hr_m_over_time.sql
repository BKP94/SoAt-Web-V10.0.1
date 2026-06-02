CREATE TABLE sc_hr_m_over_time (
	requestment_no varchar(15) NOT NULL,
	official_no varchar(15),
	membership_no varchar(15),
	salary decimal(15,2),
	rate_pay decimal(15,2),
	money_type_id varchar(6),
	bank_acc_no varchar(15),
	ot_date timestamp,
	operate_date timestamp,
	rate_1 decimal(15,2),
	rate_2 decimal(15,2),
	total_receive decimal(15,2),
	cancel_status char(1) DEFAULT '0',
	approve_status char(1) DEFAULT '0',
	approve_date timestamp,
	approve_id varchar(16),
	approve_time timestamp,
	approve_pc varchar(3),
	approve_br varchar(6),
	wait_payment_status char(1) DEFAULT '0',
	payment_date timestamp,
	money_type varchar(15),
	fin_status char(1) DEFAULT '0',
	paid_status char(1) DEFAULT '0',
	paid_date timestamp,
	entry_id varchar(16),
	entry_time timestamp,
	entry_br varchar(6),
	rate_3 decimal(15,2),
	tax_ot_rate decimal(15,2),
	tax_ot_total decimal(15,2)
) ;
ALTER TABLE sc_hr_m_over_time ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_hr_m_over_time ALTER COLUMN requestment_no SET NOT NULL;


