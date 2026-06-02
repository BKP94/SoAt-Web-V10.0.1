CREATE TABLE sc_inv_loan_sheet_det (
	membership_no varchar(15) NOT NULL,
	sheet_date timestamp NOT NULL,
	sheet_seq double precision NOT NULL,
	amount1 decimal(15,2) DEFAULT 0.00,
	amount2 decimal(15,2) DEFAULT 0.00
) ;
ALTER TABLE sc_inv_loan_sheet_det ADD PRIMARY KEY (membership_no,sheet_date,sheet_seq);
ALTER TABLE sc_inv_loan_sheet_det ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_inv_loan_sheet_det ALTER COLUMN sheet_date SET NOT NULL;
ALTER TABLE sc_inv_loan_sheet_det ALTER COLUMN sheet_seq SET NOT NULL;


