CREATE TABLE si_security_apps (
	app_name varchar(15),
	app_text varchar(50),
	order_no double precision,
	icon_name varchar(40),
	active char(1),
	shot_app char(3),
	postto_fin char(1),
	app_text_english varchar(100),
	app_text_menu varchar(1000),
	i_level double precision DEFAULT 0,
	i_sequence double precision DEFAULT 0,
	s_url varchar(40),
	i_menu_id double precision NOT NULL DEFAULT 0,
	i_parent_id double precision DEFAULT 0,
	c_begin_group char(1) DEFAULT '0',
	sub_app_name varchar(15),
	remark varchar(100)
) ;
ALTER TABLE si_security_apps ADD PRIMARY KEY (i_menu_id);
ALTER TABLE si_security_apps ALTER COLUMN i_menu_id SET NOT NULL;


