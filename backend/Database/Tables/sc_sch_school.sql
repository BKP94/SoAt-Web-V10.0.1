CREATE TABLE sc_sch_school (
	seq_no varchar(3) NOT NULL,
	name_school varchar(50),
	addr varchar(40),
	tel varchar(30)
) ;
ALTER TABLE sc_sch_school ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_sch_school ALTER COLUMN seq_no SET NOT NULL;


