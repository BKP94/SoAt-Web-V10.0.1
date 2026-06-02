CREATE TABLE sc_mem_kep_return_detail (
	membership_no char(7),
	receive_year double precision,
	recieve_month double precision,
	recieve_seq double precision,
	keeping_type_code char(5),
	receive_description char(20),
	period double precision,
	principal_of_loan decimal(15,2),
	interest decimal(15,2),
	money_amount decimal(15,2),
	principal_balance decimal(15,2),
	loan_type char(2),
	intarr_pay decimal(15,2),
	int_share_coll decimal(15,2),
	status char(1),
	principal_arrear decimal(15,2),
	interest_arrear decimal(15,2),
	principal_pay decimal(15,2),
	interest_pay decimal(15,2),
	money_pay decimal(15,2),
	doc_no char(15),
	posting_status char(1),
	keeping_item_no char(15),
	receipt_no_pay varchar(15)
) ;


