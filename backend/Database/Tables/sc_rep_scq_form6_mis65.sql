CREATE TABLE sc_rep_scq_form6_mis65 (
	operate_date timestamp NOT NULL,
	seq_no double precision NOT NULL,
	col_01 varchar(100),
	col_02 varchar(100),
	col_03 varchar(100),
	col_04 varchar(100),
	col_05 varchar(100),
	col_06 varchar(100),
	col_07 varchar(100),
	col_08 varchar(100),
	col_09 varchar(100),
	col_10 varchar(100)
) ;
ALTER TABLE sc_rep_scq_form6_mis65 ADD PRIMARY KEY (operate_date,seq_no);
ALTER TABLE sc_rep_scq_form6_mis65 ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_rep_scq_form6_mis65 ALTER COLUMN seq_no SET NOT NULL;


