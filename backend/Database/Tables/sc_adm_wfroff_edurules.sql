CREATE TABLE sc_adm_wfroff_edurules (
	rules_type char(2),
	rules_name char(100),
	level_edu char(2),
	type_edu char(1),
	limitofson double precision,
	agenotover double precision,
	birthdaynotover timestamp,
	salaryover decimal(15,2),
	salarynotover_paid decimal(15,2),
	salaryover_paid decimal(15,2),
	rules_name_mark char(100),
	entry_id char(50),
	entry_branch char(2),
	entry_date timestamp,
	pay_amount decimal(15,2)
) ;


