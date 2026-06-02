CREATE TABLE sc_inv_loan_sheet (
	sheet_seq double precision NOT NULL,
	group_sum varchar(15),
	sign_flag double precision,
	sheet_desc varchar(200),
	group_data varchar(15),
	soat_note varchar(100),
	close_1 char(1),
	close_2 char(1),
	bold char(1),
	underline char(1)
) ;
ALTER TABLE sc_inv_loan_sheet ADD PRIMARY KEY (sheet_seq);
ALTER TABLE sc_inv_loan_sheet ALTER COLUMN sheet_seq SET NOT NULL;


