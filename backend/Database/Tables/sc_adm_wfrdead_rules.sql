CREATE TABLE sc_adm_wfrdead_rules (
	rules_type char(2),
	membertogetolder double precision,
	rules_name char(100),
	paidpereach decimal(15,2),
	timeofwork_year double precision,
	deadline_day double precision,
	spr_age double precision,
	entry_id char(50),
	entry_branch char(2),
	entry_date timestamp,
	spr_date timestamp,
	group_code char(2),
	pre_paidpereach decimal(15,2)
) ;


