CREATE TABLE si_ucf_combos (
	combo_name varchar(40) NOT NULL,
	last_update varchar(15)
) ;
ALTER TABLE si_ucf_combos ADD PRIMARY KEY (combo_name);
ALTER TABLE si_ucf_combos ALTER COLUMN combo_name SET NOT NULL;


