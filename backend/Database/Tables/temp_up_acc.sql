CREATE TABLE temp_up_acc (
	acc_old varchar(8) NOT NULL,
	acc_new varchar(8) NOT NULL,
	remark varchar(50)
) ;
ALTER TABLE temp_up_acc ADD PRIMARY KEY (acc_old);
ALTER TABLE temp_up_acc ALTER COLUMN acc_old SET NOT NULL;
ALTER TABLE temp_up_acc ALTER COLUMN acc_new SET NOT NULL;


