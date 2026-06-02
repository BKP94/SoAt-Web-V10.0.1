CREATE TABLE sc_kep_m_ucf_group_pay_bk (
	group_pay_code char(3) NOT NULL,
	group_pay_des char(50),
	order_list double precision NOT NULL,
	reb_acc_bank char(1) NOT NULL,
	tran_to_dep char(1) NOT NULL,
	fin_item_type char(6),
	paid_cheque char(1) NOT NULL,
	money_type_id varchar(3)
) ;
ALTER TABLE sc_kep_m_ucf_group_pay_bk ADD PRIMARY KEY (group_pay_code);
ALTER TABLE sc_kep_m_ucf_group_pay_bk ALTER COLUMN group_pay_code SET NOT NULL;
ALTER TABLE sc_kep_m_ucf_group_pay_bk ALTER COLUMN order_list SET NOT NULL;
ALTER TABLE sc_kep_m_ucf_group_pay_bk ALTER COLUMN reb_acc_bank SET NOT NULL;
ALTER TABLE sc_kep_m_ucf_group_pay_bk ALTER COLUMN tran_to_dep SET NOT NULL;
ALTER TABLE sc_kep_m_ucf_group_pay_bk ALTER COLUMN paid_cheque SET NOT NULL;


