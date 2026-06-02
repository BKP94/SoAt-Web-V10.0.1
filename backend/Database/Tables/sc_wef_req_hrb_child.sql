CREATE TABLE sc_wef_req_hrb_child (
	requestment_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	membership_no varchar(8),
	hbd_date timestamp,
	pre_name varchar(8),
	child_name varchar(100),
	child_surname varchar(100),
	child_id_card varchar(15)
) ;
ALTER TABLE sc_wef_req_hrb_child ADD PRIMARY KEY (requestment_no,seq_no);
ALTER TABLE sc_wef_req_hrb_child ALTER COLUMN requestment_no SET NOT NULL;
ALTER TABLE sc_wef_req_hrb_child ALTER COLUMN seq_no SET NOT NULL;


