CREATE TABLE sc_fin_m_cheque_book_detail (
	bank_fin char(6),
	book_no char(15),
	cheque_no char(15),
	cheque_seqno double precision,
	used_system char(1),
	used_code char(2),
	used_remark varchar(100),
	entry_date timestamp,
	entry_id char(10),
	entry_branch char(2),
	cut_bookbank char(1),
	cut_bbdate timestamp,
	return_status char(1),
	age_expire char(1)
) ;


