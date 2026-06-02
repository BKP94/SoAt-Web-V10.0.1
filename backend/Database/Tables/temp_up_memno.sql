CREATE TABLE temp_up_memno (
	memno varchar(15) NOT NULL,
	amt decimal(15,2),
	amt2 decimal(15,2),
	remark varchar(1000),
	loan_contract_no varchar(15)
) ;
ALTER TABLE temp_up_memno ADD PRIMARY KEY (memno);
ALTER TABLE temp_up_memno ALTER COLUMN memno SET NOT NULL;


