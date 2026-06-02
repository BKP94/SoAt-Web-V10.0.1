CREATE TABLE sc_lon_req_coll_law_movement (
	doc_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	operate_date timestamp NOT NULL,
	item_type varchar(6) NOT NULL,
	ref_doc_no varchar(15) NOT NULL,
	borrow_id varchar(16) NOT NULL,
	entry_id varchar(16) NOT NULL,
	entry_date timestamp NOT NULL,
	remark varchar(100)
) ;
ALTER TABLE sc_lon_req_coll_law_movement ADD PRIMARY KEY (doc_no,seq_no);
ALTER TABLE sc_lon_req_coll_law_movement ALTER COLUMN doc_no SET NOT NULL;
ALTER TABLE sc_lon_req_coll_law_movement ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_lon_req_coll_law_movement ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_lon_req_coll_law_movement ALTER COLUMN item_type SET NOT NULL;
ALTER TABLE sc_lon_req_coll_law_movement ALTER COLUMN ref_doc_no SET NOT NULL;
ALTER TABLE sc_lon_req_coll_law_movement ALTER COLUMN borrow_id SET NOT NULL;
ALTER TABLE sc_lon_req_coll_law_movement ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_lon_req_coll_law_movement ALTER COLUMN entry_date SET NOT NULL;


