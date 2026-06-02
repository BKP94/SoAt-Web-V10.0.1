CREATE TABLE sc_rep_6n_up (
	receive_year double precision NOT NULL,
	receive_month double precision NOT NULL,
	member_group_no varchar(15) NOT NULL,
	seq_no integer NOT NULL DEFAULT 0,
	memno_1 varchar(15),
	memno_2 varchar(15),
	memno_3 varchar(15),
	memno_4 varchar(15),
	memno_5 varchar(15),
	memno_6 varchar(15)
) ;
ALTER TABLE sc_rep_6n_up ADD PRIMARY KEY (receive_year,receive_month,member_group_no,seq_no);
ALTER TABLE sc_rep_6n_up ALTER COLUMN receive_year SET NOT NULL;
ALTER TABLE sc_rep_6n_up ALTER COLUMN receive_month SET NOT NULL;
ALTER TABLE sc_rep_6n_up ALTER COLUMN member_group_no SET NOT NULL;
ALTER TABLE sc_rep_6n_up ALTER COLUMN seq_no SET NOT NULL;


