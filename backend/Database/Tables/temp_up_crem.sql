CREATE TABLE temp_up_crem (
	memno varchar(15) NOT NULL,
	c_type char(2) NOT NULL,
	c_arr decimal(15,2),
	c_fee decimal(15,2),
	c_amt decimal(15,2),
	c_return decimal(15,2) DEFAULT 0.00
) ;
ALTER TABLE temp_up_crem ADD PRIMARY KEY (memno,c_type);
ALTER TABLE temp_up_crem ALTER COLUMN memno SET NOT NULL;
ALTER TABLE temp_up_crem ALTER COLUMN c_type SET NOT NULL;


