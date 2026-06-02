CREATE TABLE sc_cnv_cnt (
	seq_no decimal(15,2) NOT NULL,
	note varchar(1000),
	sql_command varchar(1000),
	note2 varchar(1000)
) ;
ALTER TABLE sc_cnv_cnt ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_cnv_cnt ALTER COLUMN seq_no SET NOT NULL;


