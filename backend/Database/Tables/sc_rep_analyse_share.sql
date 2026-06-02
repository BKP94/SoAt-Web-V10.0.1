CREATE TABLE sc_rep_analyse_share (
	seq_no double precision NOT NULL,
	begin_condition decimal(15,2),
	end_condition decimal(15,2),
	count_member decimal(15,2),
	sum_share_stock decimal(15,2),
	sum_share_amount decimal(15,2),
	deposit_type char(2),
	rpt varchar(20),
	date_fr timestamp,
	count_share decimal(15,2),
	count_loan_emer decimal(15,2),
	sum_loan_emer decimal(15,2),
	count_loan_norm decimal(15,2),
	sum_loan_norm decimal(15,2),
	count_loan_special decimal(15,2),
	sum_loan_special decimal(15,2),
	loan_balance decimal(15,2),
	age_fr double precision,
	age_to double precision
) ;
ALTER TABLE sc_rep_analyse_share ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_rep_analyse_share ALTER COLUMN seq_no SET NOT NULL;


