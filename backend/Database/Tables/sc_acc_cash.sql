CREATE TABLE sc_acc_cash (
	year integer NOT NULL,
	month integer NOT NULL,
	acc_cash_type char(3) NOT NULL,
	n_1d decimal(15,2),
	n_7d decimal(15,2),
	n_1m decimal(15,2),
	n_3m decimal(15,2),
	n_6m decimal(15,2),
	n_12m decimal(15,2),
	n_60m decimal(15,2),
	n_120m decimal(15,2),
	n_999m decimal(15,2),
	n_noterm decimal(15,2),
	n_1di decimal(15,2),
	n_7di decimal(15,2),
	n_1mi decimal(15,2),
	n_3mi decimal(15,2),
	n_6mi decimal(15,2),
	n_12mi decimal(15,2),
	n_60mi decimal(15,2),
	n_120mi decimal(15,2),
	n_999mi decimal(15,2),
	n_notermi decimal(15,2)
) ;
ALTER TABLE sc_acc_cash ADD PRIMARY KEY (year,month,acc_cash_type);


