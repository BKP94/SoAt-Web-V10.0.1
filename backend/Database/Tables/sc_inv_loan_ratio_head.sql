CREATE TABLE sc_inv_loan_ratio_head (
	membership_no varchar(15) NOT NULL,
	date1 timestamp,
	date2 timestamp,
	date3 timestamp,
	date4 timestamp,
	date5 timestamp,
	date6 timestamp,
	date7 timestamp,
	date8 timestamp,
	date9 timestamp,
	date10 timestamp
) ;
ALTER TABLE sc_inv_loan_ratio_head ADD PRIMARY KEY (membership_no);
ALTER TABLE sc_inv_loan_ratio_head ALTER COLUMN membership_no SET NOT NULL;


