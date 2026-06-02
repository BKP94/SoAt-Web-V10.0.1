CREATE TABLE sc_lon_m_req_fee (
	loan_requestment_no varchar(15) NOT NULL,
	fee_type varchar(3) NOT NULL,
	amount decimal(15,2),
	receipt char(1),
	real_amount decimal(15,2),
	prakan_atm decimal(15,2) DEFAULT 0,
	fee_amount decimal(15,2) DEFAULT 0,
	remark varchar(100),
	to_sybase char(1) DEFAULT '0',
	loan_32 char(1) DEFAULT '0',
	deposit_account_name varchar(200),
	deposit_account_no varchar(15),
	prakan_period integer
) ;
COMMENT ON TABLE sc_lon_m_req_fee IS E'!N??????? - ?????????????????N!';
COMMENT ON COLUMN sc_lon_m_req_fee.fee_amount IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_req_fee.fee_type IS E'!N??????N!!MM!';
COMMENT ON COLUMN sc_lon_m_req_fee.loan_requestment_no IS E'!N???????N!!MM!';
CREATE INDEX idx_lon_req_fee_reqno ON sc_lon_m_req_fee (loan_requestment_no);
ALTER TABLE sc_lon_m_req_fee ADD PRIMARY KEY (loan_requestment_no,fee_type);


