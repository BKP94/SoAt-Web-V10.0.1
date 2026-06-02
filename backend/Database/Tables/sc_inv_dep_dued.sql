CREATE TABLE sc_inv_dep_dued (
	deposit_account_no varchar(15) NOT NULL,
	ref_seq_no double precision NOT NULL,
	vourcher_no varchar(15) NOT NULL,
	fixed_date timestamp,
	fixed_dued_date timestamp,
	fixed_withdraw decimal(15,2),
	fixed_dued_int decimal(15,2),
	fixed_monthly_int decimal(15,2),
	fixed_next_monthly_dued timestamp,
	interest_rate decimal(8,6),
	int_paid_fw decimal(15,2),
	entry_id varchar(16),
	entry_date timestamp,
	cancel_status char(1),
	cancel_id varchar(16),
	cancel_date timestamp
) ;
ALTER TABLE sc_inv_dep_dued ADD PRIMARY KEY (deposit_account_no,ref_seq_no,vourcher_no);
ALTER TABLE sc_inv_dep_dued ALTER COLUMN deposit_account_no SET NOT NULL;
ALTER TABLE sc_inv_dep_dued ALTER COLUMN ref_seq_no SET NOT NULL;
ALTER TABLE sc_inv_dep_dued ALTER COLUMN vourcher_no SET NOT NULL;


