CREATE TABLE sc_lon_m_contract_coll_old (
	loan_contract_no char(15) NOT NULL,
	collateral_no char(15) NOT NULL,
	collateral_type_code char(2),
	ref_own_no char(20),
	collateral_description char(100),
	collateral_amount decimal(15,2),
	evaluate_amount decimal(15,2),
	used_amount decimal(15,2),
	owner char(50),
	remark char(1000),
	status char(1) NOT NULL,
	loan_code char(1),
	begin_date timestamp,
	last_date timestamp,
	entry_date timestamp,
	entry_id char(16),
	grt_status char(1),
	grt_principle decimal(15,2),
	grt_period_paid decimal(15,2),
	grt_paid_period double precision,
	grt_total_period double precision,
	grt_last_active timestamp,
	grt_paid_amt decimal(15,2),
	grt_int_paid decimal(15,2),
	grt_paid_status char(1),
	mem_coll char(7),
	support_coll char(1),
	entry_branch char(2),
	change_doc_no char(10),
	change_approve_date timestamp,
	full_amount decimal(15,2) NOT NULL,
	mustcoll_loan char(1) NOT NULL,
	address_no char(50),
	moo char(50),
	moo_ban char(50),
	road char(50),
	tambol char(50),
	district_code char(2),
	province_code char(2),
	postcode char(10),
	telephone char(50),
	soi char(50)
) ;
CREATE UNIQUE INDEX sc_lon_m_contract_coll_x ON sc_lon_m_contract_coll_old (loan_contract_no, collateral_no);
ALTER TABLE sc_lon_m_contract_coll_old ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_lon_m_contract_coll_old ALTER COLUMN collateral_no SET NOT NULL;
ALTER TABLE sc_lon_m_contract_coll_old ALTER COLUMN status SET NOT NULL;
ALTER TABLE sc_lon_m_contract_coll_old ALTER COLUMN full_amount SET NOT NULL;
ALTER TABLE sc_lon_m_contract_coll_old ALTER COLUMN mustcoll_loan SET NOT NULL;


