CREATE TABLE sc_lon_m_ucf_loan_approver (
	approver_code varchar(6) NOT NULL,
	approver_desc varchar(200),
	min_approve_amount decimal(15,2) DEFAULT 0,
	max_approve_amount decimal(15,2) DEFAULT 0,
	official_no varchar(15)
) ;
ALTER TABLE sc_lon_m_ucf_loan_approver ADD PRIMARY KEY (approver_code);
ALTER TABLE sc_lon_m_ucf_loan_approver ALTER COLUMN approver_code SET NOT NULL;


