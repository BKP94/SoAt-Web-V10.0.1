CREATE TABLE sc_dep_ucf_book_remark (
	seq_no integer NOT NULL,
	item_remark varchar(500),
	sort_order integer DEFAULT 0
) ;
ALTER TABLE sc_dep_ucf_book_remark ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_dep_ucf_book_remark ALTER COLUMN seq_no SET NOT NULL;


