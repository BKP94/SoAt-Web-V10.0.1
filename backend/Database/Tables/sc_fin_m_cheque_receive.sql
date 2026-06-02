CREATE TABLE sc_fin_m_cheque_receive (
	bank_id char(6),
	branch_id char(6),
	seq_no double precision,
	cheque_no char(15),
	operate_date timestamp,
	bank_fin char(6),
	item_amount decimal(15,2),
	paychq_status char(1),
	entry_date timestamp,
	entry_id char(10),
	entry_branchid char(2),
	entry_client varchar(20),
	cheque_type char(3),
	membership_no char(7),
	doc_ref_no char(15),
	item_ref_no char(15)
) ;


