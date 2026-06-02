CREATE TABLE si_page_menu_items (
	page_id varchar(30) NOT NULL,
	menu_id varchar(15) NOT NULL,
	menu_desc varchar(50),
	group_id varchar(15),
	order_no double precision DEFAULT 0,
	menu_name varchar(30)
) ;
ALTER TABLE si_page_menu_items ADD PRIMARY KEY (page_id,menu_id);
ALTER TABLE si_page_menu_items ALTER COLUMN page_id SET NOT NULL;
ALTER TABLE si_page_menu_items ALTER COLUMN menu_id SET NOT NULL;


