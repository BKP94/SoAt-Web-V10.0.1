CREATE TABLE temp_up_div_npl (
	memno varchar(15) NOT NULL,
	old_amt decimal(15,2),
	new_amt decimal(15,2),
	remark varchar(100)
) ;
ALTER TABLE temp_up_div_npl ADD PRIMARY KEY (memno);
ALTER TABLE temp_up_div_npl ALTER COLUMN memno SET NOT NULL;


