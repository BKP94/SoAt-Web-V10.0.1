CREATE TABLE sc_acc_lon_ucf (
	acc_loan_type varchar(6) NOT NULL,
	acc_loan_desc varchar(200),
	acc_loan_group char(3)
) ;
ALTER TABLE sc_acc_lon_ucf ADD PRIMARY KEY (acc_loan_type);


