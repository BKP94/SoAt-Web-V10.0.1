CREATE TABLE sc_fin_ucf_gero_group (
	member_group_gr varchar(15) NOT NULL,
	member_group_gr_name varchar(250),
	member_group_gr_control varchar(15)
) ;
ALTER TABLE sc_fin_ucf_gero_group ADD PRIMARY KEY (member_group_gr);
ALTER TABLE sc_fin_ucf_gero_group ALTER COLUMN member_group_gr SET NOT NULL;


