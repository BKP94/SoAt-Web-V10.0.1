CREATE TABLE sc_lon_m_coll_change (
	loan_contract_no char(15),
	seq_no double precision,
	collateral_type_code char(2),
	collateral_no char(15),
	ref_own_no char(15),
	collateral_description varchar(100),
	collateral_amount decimal(15,2),
	evaluate_amount decimal(15,2),
	used_amount decimal(15,2),
	owner varchar(50),
	remark varchar(100),
	entry_id varchar(15),
	entry_date timestamp,
	approve_status char(1),
	approve_id varchar(50),
	approve_date timestamp,
	old_ref_own_no varchar(15),
	operate_date timestamp
) ;


