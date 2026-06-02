CREATE TABLE sc_law_tadnen_kadee_result (
	prosec_no varchar(15) NOT NULL,
	result varchar(250)
) ;
ALTER TABLE sc_law_tadnen_kadee_result ADD PRIMARY KEY (prosec_no);
ALTER TABLE sc_law_tadnen_kadee_result ALTER COLUMN prosec_no SET NOT NULL;


