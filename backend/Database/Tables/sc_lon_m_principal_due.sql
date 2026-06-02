CREATE TABLE sc_lon_m_principal_due (
	sequence_no double precision,
	loan_contract_no char(15),
	due_date timestamp,
	loan_amount decimal(15,2),
	installment_date timestamp,
	installment_status char(1),
	entry_id varchar(15),
	entry_date timestamp,
	principal_balance decimal(15,2),
	docno char(15),
	last_access_date timestamp,
	last_calcint_date timestamp,
	interest_arrear decimal(15,2),
	branch_id char(2),
	loan_approve_amount decimal(15,2),
	paid_befor decimal(15,2),
	loan_can_paid decimal(15,2)
) ;


