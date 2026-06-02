CREATE TABLE si_page_group_menus (
	page_id varchar(30) NOT NULL,
	group_id varchar(15) NOT NULL,
	group_desc varchar(50),
	order_no double precision DEFAULT 0
) ;
ALTER TABLE si_page_group_menus ADD PRIMARY KEY (page_id,group_id);
ALTER TABLE si_page_group_menus ALTER COLUMN page_id SET NOT NULL;
ALTER TABLE si_page_group_menus ALTER COLUMN group_id SET NOT NULL;


