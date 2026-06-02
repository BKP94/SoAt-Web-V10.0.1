CREATE TABLE sc_rep_level_head (
	level_date timestamp NOT NULL,
	membership_no varchar(15) NOT NULL,
	member_group_no varchar(15),
	member_status_code char(1),
	resign_date timestamp,
	share_stock decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_rep_level_head ADD PRIMARY KEY (level_date,membership_no);
ALTER TABLE sc_rep_level_head ALTER COLUMN level_date SET NOT NULL;
ALTER TABLE sc_rep_level_head ALTER COLUMN membership_no SET NOT NULL;


