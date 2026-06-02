CREATE TABLE si_rep_reps (
	cat_id varchar(30) NOT NULL,
	rep_id varchar(30) NOT NULL,
	rep_text varchar(100),
	sort_no double precision DEFAULT 0,
	vs_path varchar(100),
	active char(1) DEFAULT '0',
	procedure_name varchar(100),
	mis_status char(1) DEFAULT '0'
) ;
ALTER TABLE si_rep_reps ADD PRIMARY KEY (cat_id,rep_id);


