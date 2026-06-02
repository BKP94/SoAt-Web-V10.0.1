CREATE TABLE sc_dep_t_recalint_rep (
	deposit_account_no varchar(15) NOT NULL,
	operate_date timestamp NOT NULL,
	amount decimal(15,2) DEFAULT 0,
	balance decimal(15,2) DEFAULT 0,
	calc_deptype varchar(6) DEFAULT '00',
	calc_principal decimal(15,2) DEFAULT 0,
	calc_datefr timestamp,
	calc_dateto timestamp,
	calc_intcalc decimal(15,2) DEFAULT 0,
	intpaid decimal(15,2) DEFAULT 0,
	calc_intaccu decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_dep_t_recalint_rep ADD PRIMARY KEY (deposit_account_no,operate_date);


