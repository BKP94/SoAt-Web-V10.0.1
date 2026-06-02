CREATE TABLE sc_mem_m_app_book_receive (
	application_form_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	doc_no varchar(30),
	book_code varchar(3)
) ;
COMMENT ON TABLE sc_mem_m_app_book_receive IS E'!N???????????????N!';
COMMENT ON COLUMN sc_mem_m_app_book_receive.application_form_no IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_book_receive.book_code IS E'!N??????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_book_receive.doc_no IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_book_receive.seq_no IS E'!NN!!MM!';
CREATE INDEX idx_mem_app_book ON sc_mem_m_app_book_receive (application_form_no);
CREATE INDEX idx_mem_app_book_code ON sc_mem_m_app_book_receive (book_code);
ALTER TABLE sc_mem_m_app_book_receive ADD PRIMARY KEY (application_form_no,seq_no);


