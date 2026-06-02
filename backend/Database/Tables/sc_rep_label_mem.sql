CREATE TABLE sc_rep_label_mem (
	seq_no integer NOT NULL DEFAULT 0,
	memno_1 varchar(15),
	memno_2 varchar(15),
	memno_3 varchar(15),
	memno_4 varchar(15)
) ;
ALTER TABLE sc_rep_label_mem ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_rep_label_mem ALTER COLUMN seq_no SET NOT NULL;


