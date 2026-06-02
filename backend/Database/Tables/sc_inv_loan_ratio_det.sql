CREATE TABLE sc_inv_loan_ratio_det (
	membership_no varchar(15) NOT NULL,
	ratio_seq double precision NOT NULL,
	ratio_desc varchar(500),
	ratio_remark varchar(500),
	amt1 decimal(15,2) DEFAULT 0.00,
	amt2 decimal(15,2) DEFAULT 0.00,
	amt3 decimal(15,2) DEFAULT 0.00,
	amt4 decimal(15,2) DEFAULT 0.00,
	amt5 decimal(15,2) DEFAULT 0.00,
	amt6 decimal(15,2) DEFAULT 0.00,
	amt7 decimal(15,2) DEFAULT 0.00,
	amt8 decimal(15,2) DEFAULT 0.00,
	amt9 decimal(15,2) DEFAULT 0.00,
	amt10 decimal(15,2) DEFAULT 0.00
) ;
ALTER TABLE sc_inv_loan_ratio_det ADD PRIMARY KEY (membership_no,ratio_seq);
ALTER TABLE sc_inv_loan_ratio_det ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_inv_loan_ratio_det ALTER COLUMN ratio_seq SET NOT NULL;


