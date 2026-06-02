CREATE TABLE sc_lon_m_req_coll (
	loan_requestment_no varchar(15) NOT NULL DEFAULT 'cnv',
	seq_no double precision NOT NULL,
	collateral_type_code varchar(6),
	ref_own_no varchar(15) DEFAULT 'cnv',
	collateral_description varchar(100),
	collateral_amount decimal(15,2),
	evaluate_amount decimal(15,2),
	req_amount decimal(15,2),
	owner varchar(50),
	remark varchar(250),
	status char(1),
	intstall_retire double precision,
	mem_coll varchar(7),
	support_coll char(1) DEFAULT '0',
	ref_membership_no varchar(15),
	ref_deposit_account_no varchar(15),
	full_amount decimal(15,2) DEFAULT 0,
	mustcoll_loan char(1) DEFAULT '0',
	salary_amount decimal(15,2) DEFAULT 0,
	salary_bal_percent decimal(10,6) DEFAULT 0,
	salary_bal_amount decimal(15,2) DEFAULT 0,
	to_sybase char(1) DEFAULT '0',
	loan_32 char(1) DEFAULT '0',
	coll_loan_petmit decimal(15,2),
	coll_use_amount decimal(15,2),
	coll_evaluate_balance decimal(15,2),
	collateral_type char(1),
	tax_reduce_amount decimal(15,2) DEFAULT 0,
	address_no varchar(50),
	moo varchar(50),
	moo_ban varchar(50),
	road varchar(50),
	tambol varchar(50),
	district_code char(4),
	province_code char(3),
	postcode varchar(10),
	telephone varchar(50),
	soi varchar(50)
) ;
COMMENT ON TABLE sc_lon_m_req_coll IS E'!N??????? - ??????????N!';
COMMENT ON COLUMN sc_lon_m_req_coll.collateral_description IS E'!N??????????????/??????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_req_coll.collateral_type_code IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_req_coll.evaluate_amount IS E'!N???????N!!M??????????????????????M!';
COMMENT ON COLUMN sc_lon_m_req_coll.loan_requestment_no IS E'!N???????N!!MM!';
COMMENT ON COLUMN sc_lon_m_req_coll.ref_deposit_account_no IS E'!N????????????N!!M??????????????????(??????????) ????????????M!';
COMMENT ON COLUMN sc_lon_m_req_coll.ref_membership_no IS E'!N???????N!!M???????(?????,???????) ????????????????????????????M!';
COMMENT ON COLUMN sc_lon_m_req_coll.ref_own_no IS E'!N?????????????N!!M?????????????????M!';
COMMENT ON COLUMN sc_lon_m_req_coll.remark IS E'!N????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_req_coll.req_amount IS E'!N??????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_req_coll.seq_no IS E'!N?????N!!MM!';
CREATE INDEX idx_lon_reqcoll_colltype_code ON sc_lon_m_req_coll (collateral_type_code);
CREATE INDEX idx_lon_req_coll_ref_deposit_a ON sc_lon_m_req_coll (ref_deposit_account_no);
CREATE INDEX idx_lon_req_coll_ref_membershi ON sc_lon_m_req_coll (ref_membership_no);
CREATE INDEX idx_req_coll ON sc_lon_m_req_coll (loan_requestment_no);
CREATE INDEX idx_req_coll_ref ON sc_lon_m_req_coll (ref_own_no);
ALTER TABLE sc_lon_m_req_coll ADD PRIMARY KEY (loan_requestment_no,seq_no);
ALTER TABLE sc_lon_m_req_coll ALTER COLUMN loan_requestment_no SET NOT NULL;
ALTER TABLE sc_lon_m_req_coll ALTER COLUMN seq_no SET NOT NULL;


