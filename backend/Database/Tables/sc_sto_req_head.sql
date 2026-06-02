CREATE TABLE sc_sto_req_head (
	doc_no varchar(15) NOT NULL,
	date_rec timestamp,
	human_name_rec varchar(50),
	remark varchar(50),
	apart varchar(6),
	propose varchar(100),
	branch double precision,
	status char(1),
	approve_name varchar(50),
	membership_no varchar(15)
) ;
ALTER TABLE sc_sto_req_head ADD PRIMARY KEY (doc_no);
ALTER TABLE sc_sto_req_head ALTER COLUMN doc_no SET NOT NULL;


