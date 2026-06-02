CREATE TABLE si_security_group_menu_permission (
	i_menu_id double precision NOT NULL DEFAULT 0,
	disable_save char(1) DEFAULT '0',
	disable_update char(1) DEFAULT '0',
	group_id varchar(16) NOT NULL
) ;
ALTER TABLE si_security_group_menu_permission ADD PRIMARY KEY (i_menu_id,group_id);
ALTER TABLE si_security_group_menu_permission ALTER COLUMN i_menu_id SET NOT NULL;
ALTER TABLE si_security_group_menu_permission ALTER COLUMN group_id SET NOT NULL;


