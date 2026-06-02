CREATE TABLE sc_mem_m_chg_paymethod (
	document_no char(15),
	mproc_datatype char(3),
	seq_no double precision,
	mproc_deposit_account_no char(15),
	mproc_loan_contract_no char(15),
	keepfrom_method char(3),
	keepfrom_memno char(7),
	keepfrom_depno char(15),
	payment_type char(1),
	payment_amount decimal(15,2),
	principal_only char(1),
	start_keeping_date timestamp,
	endtime_status char(1),
	end_keeping_date timestamp,
	period_install double precision,
	keepfrom_desc varchar(100)
) ;


