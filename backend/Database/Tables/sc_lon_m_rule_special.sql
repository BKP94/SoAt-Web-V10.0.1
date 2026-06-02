CREATE TABLE sc_lon_m_rule_special (
	loan_type varchar(6) NOT NULL,
	seq_no double precision NOT NULL,
	use_total_value_of_collateral decimal(15,2),
	loan_by_salary decimal(15,4),
	loan_by_deposit decimal(15,4),
	loan_by_other_coll decimal(15,4),
	loan_by_share decimal(15,4),
	loan_by_land decimal(15,4),
	amt_by_human decimal(15,2),
	loan_by_salary_coll decimal(15,4),
	use_salary_status double precision,
	use_objective_status double precision,
	use_deposit_status double precision,
	use_collateral_status double precision,
	use_other_coll_status double precision,
	use_share_holding_status double precision,
	entry_id varchar(10),
	entry_date timestamp,
	loan_by_townbuilding decimal(15,4) DEFAULT 0
) ;
COMMENT ON TABLE sc_lon_m_rule_special IS E'!NN!';
ALTER TABLE sc_lon_m_rule_special ADD PRIMARY KEY (loan_type,seq_no);


