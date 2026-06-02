CREATE TABLE sc_eoff_ucf_keep_placement (
	keep_placement varchar(6) NOT NULL,
	keep_location varchar(100),
	keep_branch_id varchar(6),
	keep_building varchar(100),
	keep_room varchar(100),
	keep_floor double precision DEFAULT 0,
	keep_cabinets varchar(100)
) ;
ALTER TABLE sc_eoff_ucf_keep_placement ADD PRIMARY KEY (keep_placement);
ALTER TABLE sc_eoff_ucf_keep_placement ALTER COLUMN keep_placement SET NOT NULL;


