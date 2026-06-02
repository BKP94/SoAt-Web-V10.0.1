CREATE TABLE sc_com_m_ucf_money_type (
	money_type_id varchar(3) NOT NULL,
	money_type_name varchar(50),
	sort_order double precision,
	fin_pay_type varchar(3),
	spp_able char(1),
	use_bank_status char(1),
	ref_detdep char(1) DEFAULT '0',
	finkep_able char(1) DEFAULT '0',
	receipt_status char(1) DEFAULT '0',
	payment_status char(1) DEFAULT '0',
	account_from varchar(8),
	account_type varchar(3),
	createloan_at_pay char(1) DEFAULT '0',
	dividen_status char(1) DEFAULT '0',
	link_bookbank char(1) DEFAULT '0',
	link_recvpay char(1) DEFAULT '0',
	share_withdraw_able char(1) DEFAULT '0',
	active_transdate char(1) DEFAULT '0',
	active_accbank char(1) DEFAULT '0',
	active_transmoney char(1) DEFAULT '0',
	money_return_able char(1) DEFAULT '0',
	welfare_active char(1) DEFAULT '0',
	bank_info char(1) DEFAULT '0',
	membank_status char(1),
	dividen_payment char(1),
	scfin_mrtpaid char(1),
	dividen_receipt char(1),
	dividen_locked char(1),
	crem_status char(1),
	invest_status char(1) DEFAULT '0',
	not_loan_div char(1) DEFAULT '0'
) ;
ALTER TABLE sc_com_m_ucf_money_type ADD PRIMARY KEY (money_type_id);
ALTER TABLE sc_com_m_ucf_money_type ALTER COLUMN money_type_id SET NOT NULL;


