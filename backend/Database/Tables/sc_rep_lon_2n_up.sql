CREATE TABLE sc_rep_lon_2n_up (
	seq_no integer NOT NULL DEFAULT 0,
	conno_1 varchar(15),
	conno_2 varchar(15)
) ;
ALTER TABLE sc_rep_lon_2n_up ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_rep_lon_2n_up ALTER COLUMN seq_no SET NOT NULL;


