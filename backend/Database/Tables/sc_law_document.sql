CREATE TABLE sc_law_document (
	document_no varchar(15) NOT NULL,
	file_desc varchar(1000),
	entry_id varchar(16),
	entry_date timestamp,
	entry_br varchar(6)
) ;
ALTER TABLE sc_law_document ADD PRIMARY KEY (document_no);
ALTER TABLE sc_law_document ALTER COLUMN document_no SET NOT NULL;


