CREATE TABLE sc_rep_mis_business_volume (
	confirm_year bigint NOT NULL,
	confirm_date timestamp NOT NULL,
	seq_no bigint NOT NULL,
	count_mem bigint DEFAULT 0,
	month_emer decimal(15,2) DEFAULT 0,
	month_norm decimal(15,2) DEFAULT 0,
	month_spec decimal(15,2) DEFAULT 0,
	month_income decimal(15,2) DEFAULT 0,
	month_expenses decimal(15,2) DEFAULT 0,
	month_profit decimal(15,2) DEFAULT 0,
	month_reward decimal(15,2) DEFAULT 0,
	share_bal decimal(15,2) DEFAULT 0,
	dep_saving decimal(15,2) DEFAULT 0,
	dep_fixed decimal(15,2) DEFAULT 0,
	loan_all decimal(15,2) DEFAULT 0,
	income decimal(15,2) DEFAULT 0,
	expenses decimal(15,2) DEFAULT 0,
	profit decimal(15,2) DEFAULT 0,
	div_amount decimal(15,2) DEFAULT 0,
	aver_amount decimal(15,2) DEFAULT 0,
	bonus_amount decimal(15,2) DEFAULT 0,
	welfare_amount decimal(15,2) DEFAULT 0,
	asset decimal(15,2) DEFAULT 0,
	reserve decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_rep_mis_business_volume ADD PRIMARY KEY (confirm_year,confirm_date,seq_no);
ALTER TABLE sc_rep_mis_business_volume ALTER COLUMN confirm_year SET NOT NULL;
ALTER TABLE sc_rep_mis_business_volume ALTER COLUMN confirm_date SET NOT NULL;
ALTER TABLE sc_rep_mis_business_volume ALTER COLUMN seq_no SET NOT NULL;


