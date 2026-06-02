CREATE TABLE sc_lon_coll_rule_detail (
	loan_type varchar(6) NOT NULL,
	mem_level double precision NOT NULL,
	seqno double precision NOT NULL,
	share_amount decimal(15,2),
	salary_amount decimal(15,2),
	coll_num double precision,
	loan_amount decimal(15,2),
	member_term double precision,
	loan_by_salary decimal(15,4) DEFAULT 0,
	loan_by_share decimal(15,4) DEFAULT 0,
	cal_permit_style char(1) DEFAULT '0',
	per_salary decimal(5,2)
) ;
COMMENT ON TABLE sc_lon_coll_rule_detail IS E'!NN!';
COMMENT ON COLUMN sc_lon_coll_rule_detail.coll_num IS E'!N??????????????????????/??????N!!MM!';
COMMENT ON COLUMN sc_lon_coll_rule_detail.loan_amount IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_lon_coll_rule_detail.mem_level IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_lon_coll_rule_detail.salary_amount IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_lon_coll_rule_detail.share_amount IS E'!N????????????N!!MM!';
ALTER TABLE sc_lon_coll_rule_detail ADD PRIMARY KEY (loan_type,mem_level,seqno);


