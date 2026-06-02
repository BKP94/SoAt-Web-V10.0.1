CREATE TABLE sc_crem_month_constant (
	year_process double precision NOT NULL,
	month_process double precision NOT NULL,
	crem_type char(2) NOT NULL,
	crem_same_amount decimal(18,2),
	crem_diff_amount bigint,
	crem_same_dead bigint,
	crem_diff_dead bigint
) ;
ALTER TABLE sc_crem_month_constant ADD PRIMARY KEY (year_process,month_process,crem_type);
ALTER TABLE sc_crem_month_constant ALTER COLUMN year_process SET NOT NULL;
ALTER TABLE sc_crem_month_constant ALTER COLUMN month_process SET NOT NULL;
ALTER TABLE sc_crem_month_constant ALTER COLUMN crem_type SET NOT NULL;


