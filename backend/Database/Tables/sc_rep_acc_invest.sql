CREATE TABLE sc_rep_acc_invest (
	operate_date timestamp NOT NULL,
	seq_no double precision NOT NULL,
	percent_group varchar(5),
	col_01 varchar(800),
	col_02 decimal(15,2),
	col_03 decimal(15,2),
	col_04 decimal(15,6),
	col_05 decimal(15,6),
	col_06 decimal(15,6)
) ;
ALTER TABLE sc_rep_acc_invest ADD PRIMARY KEY (operate_date,seq_no);
ALTER TABLE sc_rep_acc_invest ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_rep_acc_invest ALTER COLUMN seq_no SET NOT NULL;


