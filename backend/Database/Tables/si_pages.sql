CREATE TABLE si_pages (
	page_id varchar(5) NOT NULL,
	page_path varchar(50),
	page_desc varchar(30)
) ;
ALTER TABLE si_pages ADD PRIMARY KEY (page_id);
ALTER TABLE si_pages ALTER COLUMN page_id SET NOT NULL;


