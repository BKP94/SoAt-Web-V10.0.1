CREATE TABLE sc_inv_loan_ratio_graph (
	membership_no varchar(15) NOT NULL,
	ratio_seq double precision NOT NULL,
	ratio_desc varchar(100),
	ratio_amount decimal(15,2) DEFAULT 0.00,
	ratio_color varchar(50)
) ;
ALTER TABLE sc_inv_loan_ratio_graph ADD PRIMARY KEY (membership_no,ratio_seq);
ALTER TABLE sc_inv_loan_ratio_graph ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_inv_loan_ratio_graph ALTER COLUMN ratio_seq SET NOT NULL;


