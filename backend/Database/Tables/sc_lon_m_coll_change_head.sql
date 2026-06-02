CREATE TABLE sc_lon_m_coll_change_head (
	change_doc_no varchar(10),
	membership_no varchar(15),
	loan_contract_no varchar(15),
	change_date timestamp,
	principal_balance decimal(15,2),
	last_access_date timestamp,
	change_status char(1) DEFAULT '2',
	entry_id varchar(16),
	entry_date timestamp,
	remark varchar(100),
	approve_id varchar(16),
	approve_date timestamp,
	last_calint_date timestamp,
	member_name varchar(100),
	member_group_no varchar(15),
	loan_installment double precision DEFAULT 0,
	loan_type varchar(6) DEFAULT '00',
	entry_br varchar(6),
	cancel_date timestamp,
	cancel_id varchar(16),
	cancel_status char(1)
) ;
COMMENT ON TABLE sc_lon_m_coll_change_head IS E'!N??????????????????? HN!!MM!';


