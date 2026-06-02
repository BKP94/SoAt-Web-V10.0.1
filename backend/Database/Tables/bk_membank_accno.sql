CREATE TABLE bk_membank_accno (
	membership_no varchar(15) NOT NULL,
	bank_id varchar(6) NOT NULL,
	bank_acc_no varchar(30)
) ;
ALTER TABLE bk_membank_accno ADD PRIMARY KEY (membership_no);
ALTER TABLE bk_membank_accno ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE bk_membank_accno ALTER COLUMN bank_id SET NOT NULL;


