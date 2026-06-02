CREATE TABLE sc_edoc_mem_oth (
	membership_no varchar(15),
	page_no double precision NOT NULL DEFAULT 0,
	doc_type varchar(6) NOT NULL,
	entry_id varchar(16),
	entry_br varchar(6),
	entry_date timestamp,
	entry_pc varchar(3),
	cancel_status char(1) DEFAULT '0',
	cancel_id varchar(16),
	cancel_br varchar(6),
	cancel_date timestamp,
	cancel_pc varchar(3),
	remark varchar(300),
	filename varchar(150),
	application_form_no varchar(15) NOT NULL
) ;
ALTER TABLE sc_edoc_mem_oth ADD PRIMARY KEY (application_form_no,page_no,doc_type);


