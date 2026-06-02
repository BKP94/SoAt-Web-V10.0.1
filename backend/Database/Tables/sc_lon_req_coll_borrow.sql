CREATE TABLE sc_lon_req_coll_borrow (
	loan_requestment_no char(15),
	coll_ref varchar(100),
	seq_no double precision,
	borrow_date timestamp,
	borrow_remark varchar(50),
	borrow_req_id char(16),
	borrow_apv_id char(16),
	return_send_id char(16),
	return_recv_id char(16),
	return_date timestamp
) ;


