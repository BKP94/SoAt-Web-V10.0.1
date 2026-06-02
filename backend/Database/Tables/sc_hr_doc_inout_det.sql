CREATE TABLE sc_hr_doc_inout_det (
	doc_no varchar(15) NOT NULL,
	seq_no integer NOT NULL DEFAULT 0,
	operate_date timestamp,
	from_department varchar(6),
	det_remark varchar(250),
	entry_id varchar(16),
	entry_date timestamp,
	entry_branch varchar(6),
	entry_clientid varchar(30)
) ;
ALTER TABLE sc_hr_doc_inout_det ADD PRIMARY KEY (doc_no,seq_no);
ALTER TABLE sc_hr_doc_inout_det ALTER COLUMN doc_no SET NOT NULL;
ALTER TABLE sc_hr_doc_inout_det ALTER COLUMN seq_no SET NOT NULL;


