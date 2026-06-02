CREATE TABLE sc_acc_t_trial_balance_rep (
	account_id varchar(8) NOT NULL,
	account_name varchar(100),
	dr_bb decimal(15,2),
	cr_bb decimal(15,2),
	dr_between decimal(15,2),
	cr_between decimal(15,2),
	dr_amount decimal(15,2),
	cr_amount decimal(15,2),
	dr_adj decimal(15,2) DEFAULT 0,
	cr_adj decimal(15,2) DEFAULT 0,
	balsheet_group char(10)
) ;
COMMENT ON TABLE sc_acc_t_trial_balance_rep IS E'!NN!';
ALTER TABLE sc_acc_t_trial_balance_rep ADD PRIMARY KEY (account_id);


