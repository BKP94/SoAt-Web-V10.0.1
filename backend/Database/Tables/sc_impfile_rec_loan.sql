CREATE TABLE sc_impfile_rec_loan (
	paid_date timestamp NOT NULL,
	keeping_type_group varchar(3) NOT NULL,
	loan_contract_no varchar(15) NOT NULL,
	membership_no varchar(15) NOT NULL,
	amount decimal(15,2) NOT NULL DEFAULT 0,
	amount_yes decimal(15,2) NOT NULL DEFAULT 0,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	status char(1) NOT NULL DEFAULT '0',
	type_page varchar(15) NOT NULL,
	receipt_no varchar(15)
) ;
ALTER TABLE sc_impfile_rec_loan ADD PRIMARY KEY (paid_date,loan_contract_no);
ALTER TABLE sc_impfile_rec_loan ALTER COLUMN paid_date SET NOT NULL;
ALTER TABLE sc_impfile_rec_loan ALTER COLUMN keeping_type_group SET NOT NULL;
ALTER TABLE sc_impfile_rec_loan ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_impfile_rec_loan ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_impfile_rec_loan ALTER COLUMN amount SET NOT NULL;
ALTER TABLE sc_impfile_rec_loan ALTER COLUMN amount_yes SET NOT NULL;
ALTER TABLE sc_impfile_rec_loan ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_impfile_rec_loan ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_impfile_rec_loan ALTER COLUMN status SET NOT NULL;
ALTER TABLE sc_impfile_rec_loan ALTER COLUMN type_page SET NOT NULL;


