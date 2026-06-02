CREATE TABLE sc_share_m_ucf_monthly_loan (
	seq_no double precision NOT NULL DEFAULT 0,
	loan_amount decimal(15,2) DEFAULT 0,
	share_amount decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_share_m_ucf_monthly_loan ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_share_m_ucf_monthly_loan ALTER COLUMN seq_no SET NOT NULL;


