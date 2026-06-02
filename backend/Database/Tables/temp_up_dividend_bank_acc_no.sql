CREATE TABLE temp_up_dividend_bank_acc_no (
	membership_no varchar(15) NOT NULL,
	method_recieve_dividend varchar(3),
	bank_id varchar(6),
	bank_acc_no varchar(15)
) ;
ALTER TABLE temp_up_dividend_bank_acc_no ADD PRIMARY KEY (membership_no);
ALTER TABLE temp_up_dividend_bank_acc_no ALTER COLUMN membership_no SET NOT NULL;


