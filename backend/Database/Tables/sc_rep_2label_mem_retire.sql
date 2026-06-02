CREATE TABLE sc_rep_2label_mem_retire (
	seq_no integer NOT NULL DEFAULT 0,
	memno_1 varchar(15),
	memno_2 varchar(15)
) ;
ALTER TABLE sc_rep_2label_mem_retire ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_rep_2label_mem_retire ALTER COLUMN seq_no SET NOT NULL;


