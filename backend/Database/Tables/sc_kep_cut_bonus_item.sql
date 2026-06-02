CREATE TABLE sc_kep_cut_bonus_item (
	account_year double precision NOT NULL,
	keeping_type_group varchar(3) NOT NULL,
	membership_no varchar(15) NOT NULL,
	loan_contract_no varchar(15) NOT NULL,
	loan_type varchar(6) NOT NULL,
	salary_amount decimal(15,2),
	bonus_amount decimal(15,2),
	bonus_percent decimal(15,2),
	loan_balance decimal(15,2),
	loan_percent decimal(15,2),
	cal_int_amt decimal(15,2),
	item_amount decimal(15,2) NOT NULL,
	real_keep decimal(15,2),
	paid_loan_amt decimal(15,2),
	paid_loan_recno varchar(15),
	ret_deposit_amt decimal(15,2),
	ret_deposit_depno varchar(15),
	ret_deposit_group varchar(15)
) ;
ALTER TABLE sc_kep_cut_bonus_item ADD PRIMARY KEY (account_year,loan_contract_no);
ALTER TABLE sc_kep_cut_bonus_item ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_kep_cut_bonus_item ALTER COLUMN keeping_type_group SET NOT NULL;
ALTER TABLE sc_kep_cut_bonus_item ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_kep_cut_bonus_item ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_kep_cut_bonus_item ALTER COLUMN loan_type SET NOT NULL;
ALTER TABLE sc_kep_cut_bonus_item ALTER COLUMN item_amount SET NOT NULL;


