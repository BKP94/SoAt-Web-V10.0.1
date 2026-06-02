CREATE TABLE sc_law_document_det (
	document_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	file_name varchar(1000),
	full_path varchar(100)
) ;
ALTER TABLE sc_law_document_det ALTER COLUMN document_no SET NOT NULL;
ALTER TABLE sc_law_document_det ALTER COLUMN seq_no SET NOT NULL;


