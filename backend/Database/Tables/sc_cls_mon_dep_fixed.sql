CREATE TABLE sc_cls_mon_dep_fixed (
	monthly_date timestamp NOT NULL,
	deposit_account_no varchar(15) NOT NULL,
	ref_seq_no double precision NOT NULL DEFAULT 0,
	fixed_date timestamp,
	fixed_amount double precision DEFAULT 0,
	fixed_dued_date timestamp,
	fixed_dued_month_count double precision DEFAULT 0,
	fixed_dued_int double precision DEFAULT 0,
	fixed_monthly_int double precision DEFAULT 0,
	fixed_paid_monthly_int double precision DEFAULT 0,
	fixed_next_monthly_dued timestamp,
	interest_rate double precision DEFAULT 0,
	int_arrear decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_cls_mon_dep_fixed ADD PRIMARY KEY (monthly_date,deposit_account_no,ref_seq_no);
ALTER TABLE sc_cls_mon_dep_fixed ALTER COLUMN monthly_date SET NOT NULL;
ALTER TABLE sc_cls_mon_dep_fixed ALTER COLUMN deposit_account_no SET NOT NULL;
ALTER TABLE sc_cls_mon_dep_fixed ALTER COLUMN ref_seq_no SET NOT NULL;


