CREATE TABLE sc_acc_m_ucf_doc_type (
	doc_type varchar(6) NOT NULL,
	doc_name varchar(100)
) ;
COMMENT ON TABLE sc_acc_m_ucf_doc_type IS E'!NN!';
ALTER TABLE sc_acc_m_ucf_doc_type ADD PRIMARY KEY (doc_type);


