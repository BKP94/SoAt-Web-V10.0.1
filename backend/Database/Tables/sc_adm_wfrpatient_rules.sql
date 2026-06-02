CREATE TABLE sc_adm_wfrpatient_rules (
	rules_type char(2),
	rules_name char(100),
	patient_type char(15),
	limitperyear double precision,
	paidpertime decimal(15,2),
	treat_day_amount double precision,
	deadline_day double precision,
	rules_name_mark char(100),
	entry_id char(50),
	entry_branch char(2),
	entry_date timestamp
) ;


