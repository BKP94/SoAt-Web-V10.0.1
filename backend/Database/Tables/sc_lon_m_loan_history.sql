CREATE TABLE sc_lon_m_loan_history (
	loan_requestment_no varchar(15) NOT NULL DEFAULT 'cnv',
	sequence_no double precision NOT NULL,
	loan_contract_no varchar(15),
	principal_balance_of_loan decimal(15,2),
	principal_of_loan decimal(15,2),
	interest_arrear decimal(15,2),
	remark varchar(100),
	interest_amount decimal(15,2),
	payment_amount decimal(15,2),
	last_period double precision,
	loan_type varchar(6),
	clear_target char(1),
	clear_focus char(1),
	interest_return decimal(15,2) DEFAULT 0,
	principal_pending_holding decimal(15,2) DEFAULT 0,
	loan_installment smallint DEFAULT 0,
	monthly_pay decimal(15,2) DEFAULT 0,
	loan_approve_amount decimal(15,2) DEFAULT 0,
	salary_time double precision DEFAULT 1,
	monthly_pay_p decimal(15,2) DEFAULT 0,
	monthly_pay_i decimal(15,2) DEFAULT 0,
	fund_return decimal(15,2) DEFAULT 0,
	to_sybase char(1) DEFAULT '0',
	loan_32 char(1) DEFAULT '0'
) ;
COMMENT ON TABLE sc_lon_m_loan_history IS E'!N??????? - ???????????????????N!';
COMMENT ON COLUMN sc_lon_m_loan_history.interest_amount IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_history.interest_arrear IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_history.interest_return IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_history.last_period IS E'!N?????????N!!M????????? ? ???????????M!';
COMMENT ON COLUMN sc_lon_m_loan_history.loan_contract_no IS E'!N????????????N!!M[??????? FK ??? Loan Card ??????????????????????????????????]M!';
COMMENT ON COLUMN sc_lon_m_loan_history.loan_installment IS E'!N???N!!M????????????????M!';
COMMENT ON COLUMN sc_lon_m_loan_history.loan_requestment_no IS E'!N???????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_history.payment_amount IS E'!N????/???N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_history.principal_balance_of_loan IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_history.principal_of_loan IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_history.principal_pending_holding IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_history.remark IS E'!NN!!MM!';
COMMENT ON COLUMN sc_lon_m_loan_history.sequence_no IS E'!N?????N!!MM!';
CREATE INDEX idx_history_001 ON sc_lon_m_loan_history (loan_requestment_no);
CREATE INDEX idx_his_conno ON sc_lon_m_loan_history (loan_contract_no);
CREATE INDEX idx_lon_his_loantype ON sc_lon_m_loan_history (loan_type);
CREATE UNIQUE INDEX idx_lon_req_history_reqcon ON sc_lon_m_loan_history (loan_requestment_no, loan_contract_no);
ALTER TABLE sc_lon_m_loan_history ADD PRIMARY KEY (loan_requestment_no,sequence_no);


