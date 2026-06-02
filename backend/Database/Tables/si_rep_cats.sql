CREATE TABLE si_rep_cats (
	cat_id varchar(30) NOT NULL,
	cat_text varchar(50),
	cat_app varchar(15),
	sort_no double precision DEFAULT 0,
	active char(1) DEFAULT '0',
	mis_status char(1) DEFAULT '0'
) ;
ALTER TABLE si_rep_cats ADD PRIMARY KEY (cat_id);


