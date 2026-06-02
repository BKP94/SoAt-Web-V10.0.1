CREATE TABLE sc_fin_m_print_cheque_cpx (
	cheque_cpx_code char(20),
	seq_no double precision,
	cheque_no char(15),
	bank_fin char(6),
	paid_name varchar(100),
	item_amount decimal(15,2),
	print_id char(10),
	print_date timestamp,
	print_branch char(2),
	print_client varchar(30),
	print_status char(1)
) ;


