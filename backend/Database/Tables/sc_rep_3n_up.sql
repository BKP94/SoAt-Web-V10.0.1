CREATE TABLE sc_rep_3n_up (
	seq_no integer NOT NULL DEFAULT 0,
	memno_1 varchar(15),
	memno_2 varchar(15),
	memno_3 varchar(15)
) ;
ALTER TABLE sc_rep_3n_up ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_rep_3n_up ALTER COLUMN seq_no SET NOT NULL;


