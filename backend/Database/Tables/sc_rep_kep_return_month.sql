CREATE TABLE sc_rep_kep_return_month (
	membership_no varchar(7) NOT NULL,
	count_month integer DEFAULT 0,
	last_month double precision,
	last_year double precision,
	book_date timestamp,
	rep_type varchar(3) NOT NULL,
	last_return timestamp,
	prin_arr decimal(15,2),
	period_arr bigint
) ;
ALTER TABLE sc_rep_kep_return_month ADD PRIMARY KEY (membership_no,rep_type);
ALTER TABLE sc_rep_kep_return_month ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_rep_kep_return_month ALTER COLUMN rep_type SET NOT NULL;


