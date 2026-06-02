CREATE TABLE sc_rep_level_ucf (
	level_status char(1) NOT NULL DEFAULT '0',
	level_desc varchar(50),
	allowance_rate decimal(6,2)
) ;
ALTER TABLE sc_rep_level_ucf ADD PRIMARY KEY (level_status);
ALTER TABLE sc_rep_level_ucf ALTER COLUMN level_status SET NOT NULL;


