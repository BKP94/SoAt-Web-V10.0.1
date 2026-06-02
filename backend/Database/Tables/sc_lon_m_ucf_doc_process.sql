CREATE TABLE sc_lon_m_ucf_doc_process (
	process_id char(2) NOT NULL,
	process_name varchar(150),
	sort_order varchar(15)
) ;
ALTER TABLE sc_lon_m_ucf_doc_process ADD PRIMARY KEY (process_id);
ALTER TABLE sc_lon_m_ucf_doc_process ALTER COLUMN process_id SET NOT NULL;


