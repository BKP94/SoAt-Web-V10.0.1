CREATE TABLE sc_lon_m_req_periodpay (
	loan_requestment_no varchar(15) NOT NULL,
	effect_date timestamp NOT NULL,
	period_payment decimal(15,2) DEFAULT 0,
	effect_balance decimal(15,2) DEFAULT 0,
	period_begin double precision DEFAULT 0,
	period_time double precision DEFAULT 0,
	last_period decimal(15,2) DEFAULT 0,
	share_balance decimal(15,2) DEFAULT 0,
	retire_status char(1) DEFAULT '0',
	principal_paid decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_lon_m_req_periodpay ADD PRIMARY KEY (loan_requestment_no,effect_date);


