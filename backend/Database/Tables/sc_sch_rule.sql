CREATE TABLE sc_sch_rule (
	scholarship_type varchar(6) NOT NULL,
	scholarship_group varchar(6),
	description varchar(100),
	scholarship_budget decimal(15,2),
	status_adopter_receive char(1),
	status_one_receive char(1),
	status_recieve_continue char(1),
	mem_salary_min decimal(15,2),
	mem_salary_max decimal(15,2)
) ;
ALTER TABLE sc_sch_rule ADD PRIMARY KEY (scholarship_type);


