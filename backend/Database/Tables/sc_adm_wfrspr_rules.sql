CREATE TABLE sc_adm_wfrspr_rules (
	rules_type char(2),
	rules_name char(100),
	membertogetolder double precision,
	paidpereach decimal(15,2),
	deadline_day double precision,
	spr_age double precision,
	entry_id char(50),
	entry_branch char(2),
	entry_date timestamp
) ;


