CREATE TABLE sc_rep_scq_form13_mis65 (
	operate_date timestamp NOT NULL,
	loan_group char(1) NOT NULL,
	loan_item double precision NOT NULL,
	loan_desc varchar(100),
	principal_balance double precision,
	short_due double precision,
	short_3lt double precision,
	short_3gt double precision,
	long_due double precision,
	long_3lt double precision,
	long_3gt double precision,
	principal_unloan double precision,
	emer_due decimal(15,2),
	emer_3gt decimal(15,2),
	emer_3lt decimal(15,2),
	norm_due decimal(15,2),
	norm_3gt decimal(15,2),
	norm_3lt decimal(15,2),
	spec_due decimal(15,2),
	spec_3gt decimal(15,2),
	spec_3lt decimal(15,2)
) ;
ALTER TABLE sc_rep_scq_form13_mis65 ADD PRIMARY KEY (operate_date,loan_group,loan_item);
ALTER TABLE sc_rep_scq_form13_mis65 ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_rep_scq_form13_mis65 ALTER COLUMN loan_group SET NOT NULL;
ALTER TABLE sc_rep_scq_form13_mis65 ALTER COLUMN loan_item SET NOT NULL;


