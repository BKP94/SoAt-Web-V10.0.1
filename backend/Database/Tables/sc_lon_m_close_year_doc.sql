CREATE TABLE sc_lon_m_close_year_doc (
	lon_year double precision NOT NULL DEFAULT 0,
	document_code varchar(22) NOT NULL,
	last_document_no varchar(15),
	document_year varchar(15)
) ;
ALTER TABLE sc_lon_m_close_year_doc ADD PRIMARY KEY (lon_year,document_code);
ALTER TABLE sc_lon_m_close_year_doc ALTER COLUMN lon_year SET NOT NULL;
ALTER TABLE sc_lon_m_close_year_doc ALTER COLUMN document_code SET NOT NULL;


