CREATE TABLE si_cnt_regexp (
	col_name varchar(30) NOT NULL,
	str_pattern varchar(100) NOT NULL,
	str_replace varchar(30),
	str_position double precision,
	str_occurrence double precision,
	match_parameter varchar(30)
) ;
ALTER TABLE si_cnt_regexp ADD PRIMARY KEY (col_name);
ALTER TABLE si_cnt_regexp ALTER COLUMN col_name SET NOT NULL;
ALTER TABLE si_cnt_regexp ALTER COLUMN str_pattern SET NOT NULL;


