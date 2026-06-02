CREATE TABLE sc_law_tad_nenkadee_operate (
	prosec_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	operate_date timestamp,
	operate_time timestamp,
	description varchar(50),
	remark varchar(100)
) ;
ALTER TABLE sc_law_tad_nenkadee_operate ADD PRIMARY KEY (prosec_no,seq_no);
ALTER TABLE sc_law_tad_nenkadee_operate ALTER COLUMN prosec_no SET NOT NULL;
ALTER TABLE sc_law_tad_nenkadee_operate ALTER COLUMN seq_no SET NOT NULL;


