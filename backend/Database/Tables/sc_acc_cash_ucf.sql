CREATE TABLE sc_acc_cash_ucf (
	acc_cash_type char(3) NOT NULL,
	acc_cash_desc varchar(200),
	acc_cash_group char(3)
) ;
ALTER TABLE sc_acc_cash_ucf ADD PRIMARY KEY (acc_cash_type);


