CREATE TABLE sc_acc_m_account_budget (
	account_year double precision,
	account_id varchar(8),
	account_budget decimal(15,2),
	month1_amount decimal(15,2),
	month2_amount decimal(15,2),
	month3_amount decimal(15,2),
	month4_amount decimal(15,2),
	month5_amount decimal(15,2),
	month6_amount decimal(15,2),
	month7_amount decimal(15,2),
	month8_amount decimal(15,2),
	month9_amount decimal(15,2),
	month10_amount decimal(15,2),
	month11_amount decimal(15,2),
	month12_amount decimal(15,2),
	branch_id varchar(6),
	budget_id varchar(6) DEFAULT '01',
	month_status char(1) DEFAULT '0',
	transfer_budget decimal(15,2) DEFAULT 0,
	money_exp varchar(100),
	money_desc varchar(50),
	sort_order integer DEFAULT 0,
	budget_desc varchar(4000),
	budget_req decimal(15,2) DEFAULT 0
) ;
COMMENT ON TABLE sc_acc_m_account_budget IS E'!NN!';


