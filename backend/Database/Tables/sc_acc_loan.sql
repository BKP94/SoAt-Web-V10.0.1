CREATE TABLE sc_acc_loan (
	year integer NOT NULL,
	month integer NOT NULL,
	acc_loan_type varchar(6) NOT NULL,
	loan_sum decimal(15,2) DEFAULT 0,
	shot_0 decimal(15,2) DEFAULT 0,
	shot_3 decimal(15,2) DEFAULT 0,
	shot_6 decimal(15,2) DEFAULT 0,
	long_0 decimal(15,2) DEFAULT 0,
	long_3 decimal(15,2) DEFAULT 0,
	long_6 decimal(15,2) DEFAULT 0,
	c_shot_0 integer,
	c_shot_3 integer,
	c_shot_6 integer,
	c_long_0 integer,
	c_long_3 integer,
	c_long_6 integer
) ;
ALTER TABLE sc_acc_loan ADD PRIMARY KEY (year,month,acc_loan_type);


