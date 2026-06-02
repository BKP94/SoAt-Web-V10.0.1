CREATE TABLE sc_rep_mis_paid_loan_by_month (
	loan_type varchar(6) NOT NULL,
	count_01 bigint,
	amout_01 decimal(15,2),
	count_02 bigint,
	amout_02 decimal(15,2),
	count_03 bigint,
	amout_03 decimal(15,2),
	count_04 bigint,
	amout_04 decimal(15,2),
	count_05 bigint,
	amout_05 decimal(15,2),
	count_06 bigint,
	amout_06 decimal(15,2),
	count_07 bigint,
	amout_07 decimal(15,2),
	count_08 bigint,
	amout_08 decimal(15,2),
	count_09 bigint,
	amout_09 decimal(15,2),
	count_10 bigint,
	amout_10 decimal(15,2),
	count_11 bigint,
	amout_11 decimal(15,2),
	count_12 bigint,
	amout_12 decimal(15,2)
) ;
ALTER TABLE sc_rep_mis_paid_loan_by_month ADD PRIMARY KEY (loan_type);
ALTER TABLE sc_rep_mis_paid_loan_by_month ALTER COLUMN loan_type SET NOT NULL;


