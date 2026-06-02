CREATE TABLE sc_lon_m_contract_coll (
	loan_contract_no varchar(15) NOT NULL DEFAULT 'cnv',
	collateral_no varchar(15) NOT NULL,
	collateral_type_code varchar(4),
	ref_own_no varchar(20) DEFAULT 'cnv',
	collateral_description varchar(100),
	collateral_amount decimal(15,2),
	evaluate_amount decimal(15,2),
	used_amount decimal(15,2),
	owner varchar(50),
	remark varchar(1000),
	status varchar(3),
	loan_code varchar(3),
	begin_date timestamp,
	last_date timestamp,
	entry_date timestamp,
	entry_id varchar(16),
	grt_status varchar(3) DEFAULT '0',
	grt_principle decimal(15,2),
	grt_period_paid decimal(15,2),
	grt_paid_period double precision,
	grt_total_period double precision,
	grt_last_active timestamp,
	grt_paid_amt decimal(15,2),
	grt_int_paid decimal(15,2),
	grt_paid_status varchar(3) DEFAULT '0',
	mem_coll varchar(15),
	support_coll varchar(3),
	entry_branch varchar(6),
	change_doc_no varchar(10),
	change_approve_date timestamp,
	full_amount decimal(15,2) DEFAULT 0,
	mustcoll_loan varchar(3) DEFAULT '0',
	date_value timestamp,
	to_sybase char(1) DEFAULT '0',
	loan_32 char(1) DEFAULT '0',
	keep_coll_status char(1) DEFAULT '0',
	keep_coll_amount decimal(15,2) DEFAULT 0.00,
	tax_reduce_amount decimal(15,2) DEFAULT 0,
	tax_amount decimal(15,2),
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
COMMENT ON TABLE sc_lon_m_contract_coll IS E'!N???????????? - ??????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_contract_coll.begin_date IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.change_approve_date IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.change_doc_no IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.collateral_amount IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.collateral_description IS E'!N????????????????????N!';
COMMENT ON COLUMN sc_lon_m_contract_coll.collateral_no IS E'!N??????????????????N!';
COMMENT ON COLUMN sc_lon_m_contract_coll.collateral_type_code IS E'!N??????????N!!M?????????????????????M!';
COMMENT ON COLUMN sc_lon_m_contract_coll.entry_branch IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.entry_date IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.entry_id IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.evaluate_amount IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_contract_coll.grt_int_paid IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.grt_last_active IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.grt_paid_amt IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.grt_paid_period IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.grt_paid_status IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.grt_period_paid IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.grt_principle IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.grt_status IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.grt_total_period IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.last_date IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.loan_code IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.loan_contract_no IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_contract_coll.mem_coll IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.owner IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.ref_own_no IS E'!N?????????????N!';
COMMENT ON COLUMN sc_lon_m_contract_coll.remark IS E'!N????????N!';
COMMENT ON COLUMN sc_lon_m_contract_coll.status IS E'!N?????N!!MM!';
COMMENT ON COLUMN sc_lon_m_contract_coll.support_coll IS E'!NN!';
COMMENT ON COLUMN sc_lon_m_contract_coll.used_amount IS E'!N???????????????N!!MM!';
CREATE INDEX idx_concoll_conrefcoll ON sc_lon_m_contract_coll (loan_contract_no, ref_own_no, collateral_type_code);
CREATE INDEX idx_conno_status ON sc_lon_m_contract_coll (loan_contract_no);
CREATE INDEX idx_contraxt_coll_ref ON sc_lon_m_contract_coll (ref_own_no);
CREATE INDEX idx_lon_coll_status ON sc_lon_m_contract_coll (status);
CREATE INDEX idx_lon_contract_coll ON sc_lon_m_contract_coll (collateral_no);
CREATE INDEX idx_lon_contract_coll_typecode ON sc_lon_m_contract_coll (collateral_type_code);
CREATE INDEX ix_sc_lon_m_contract_coll ON sc_lon_m_contract_coll (ref_own_no, status);
ALTER TABLE sc_lon_m_contract_coll ADD PRIMARY KEY (loan_contract_no,collateral_no);
ALTER TABLE sc_lon_m_contract_coll ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_lon_m_contract_coll ALTER COLUMN collateral_no SET NOT NULL;


