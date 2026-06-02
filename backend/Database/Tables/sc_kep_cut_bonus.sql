CREATE TABLE sc_kep_cut_bonus (
	account_year double precision NOT NULL,
	bonus_rate decimal(2,1),
	calint_date timestamp,
	entry_id varchar(16),
	entry_br varchar(6),
	entry_time timestamp
) ;
ALTER TABLE sc_kep_cut_bonus ADD PRIMARY KEY (account_year);
ALTER TABLE sc_kep_cut_bonus ALTER COLUMN account_year SET NOT NULL;


