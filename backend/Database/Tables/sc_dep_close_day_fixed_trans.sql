CREATE TABLE sc_dep_close_day_fixed_trans (
	deposit_account_no varchar(15) NOT NULL,
	ref_seq_no integer NOT NULL DEFAULT 0,
	transfer_date timestamp NOT NULL,
	transfer_amount decimal(15,2) NOT NULL DEFAULT 0,
	transfer_depno varchar(15) NOT NULL
) ;
ALTER TABLE sc_dep_close_day_fixed_trans ADD PRIMARY KEY (deposit_account_no,ref_seq_no,transfer_date);
ALTER TABLE sc_dep_close_day_fixed_trans ALTER COLUMN deposit_account_no SET NOT NULL;
ALTER TABLE sc_dep_close_day_fixed_trans ALTER COLUMN ref_seq_no SET NOT NULL;
ALTER TABLE sc_dep_close_day_fixed_trans ALTER COLUMN transfer_date SET NOT NULL;
ALTER TABLE sc_dep_close_day_fixed_trans ALTER COLUMN transfer_amount SET NOT NULL;
ALTER TABLE sc_dep_close_day_fixed_trans ALTER COLUMN transfer_depno SET NOT NULL;


