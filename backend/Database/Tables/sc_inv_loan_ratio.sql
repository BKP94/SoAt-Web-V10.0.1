CREATE TABLE sc_inv_loan_ratio (
	ratio_seq double precision NOT NULL,
	ratio_desc varchar(500),
	ratio_remark varchar(500),
	soat_note varchar(500)
) ;
ALTER TABLE sc_inv_loan_ratio ADD PRIMARY KEY (ratio_seq);
ALTER TABLE sc_inv_loan_ratio ALTER COLUMN ratio_seq SET NOT NULL;


