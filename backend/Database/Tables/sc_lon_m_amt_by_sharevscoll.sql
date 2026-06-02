CREATE TABLE sc_lon_m_amt_by_sharevscoll (
	loan_type varchar(6) NOT NULL,
	seq_no double precision NOT NULL,
	salary_amount_min decimal(15,2),
	share_holding_min decimal(15,2),
	collateral_price_min decimal(15,2),
	share_coll_amount_min decimal(15,2),
	loan_amount_max decimal(15,2),
	use_coll double precision,
	use_share double precision,
	entry_id varchar(15),
	entry_date timestamp
) ;
COMMENT ON TABLE sc_lon_m_amt_by_sharevscoll IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_amt_by_sharevscoll.collateral_price_min IS E'!N????????????????? (???)N!!MM!';
COMMENT ON COLUMN sc_lon_m_amt_by_sharevscoll.loan_amount_max IS E'!N??????????????? (???)N!!MM!';
COMMENT ON COLUMN sc_lon_m_amt_by_sharevscoll.loan_type IS E'!NN!!MM!';
COMMENT ON COLUMN sc_lon_m_amt_by_sharevscoll.salary_amount_min IS E'!N???????????????? (???)N!!MM!';
COMMENT ON COLUMN sc_lon_m_amt_by_sharevscoll.share_coll_amount_min IS E'!N??????????+???? ???????(???)N!!MM!';
COMMENT ON COLUMN sc_lon_m_amt_by_sharevscoll.share_holding_min IS E'!N??????????????????? (???)N!!MM!';
CREATE INDEX idx_lon_m_a_12236723761_loan_t ON sc_lon_m_amt_by_sharevscoll (loan_type);
ALTER TABLE sc_lon_m_amt_by_sharevscoll ADD PRIMARY KEY (loan_type,seq_no);


