CREATE TABLE sc_hr_doc_inout_edoc (
	doc_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	page_no double precision DEFAULT 0,
	entry_id varchar(16),
	entry_br varchar(6),
	entry_date timestamp,
	entry_pc varchar(6),
	cancel_status char(1) DEFAULT '0',
	cancel_id varchar(16),
	cancel_br varchar(6),
	cancel_date timestamp,
	cancel_pc varchar(6)
) ;
ALTER TABLE sc_hr_doc_inout_edoc ADD PRIMARY KEY (doc_no,seq_no);
ALTER TABLE sc_hr_doc_inout_edoc ALTER COLUMN doc_no SET NOT NULL;
ALTER TABLE sc_hr_doc_inout_edoc ALTER COLUMN seq_no SET NOT NULL;


