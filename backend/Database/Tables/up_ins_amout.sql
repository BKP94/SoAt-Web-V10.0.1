CREATE TABLE up_ins_amout (
	membership_no varchar(15) NOT NULL,
	advance_amount decimal(15,2)
) ;
ALTER TABLE up_ins_amout ADD PRIMARY KEY (membership_no);
ALTER TABLE up_ins_amout ALTER COLUMN membership_no SET NOT NULL;
