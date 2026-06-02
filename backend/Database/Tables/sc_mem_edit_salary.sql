CREATE TABLE sc_mem_edit_salary (
	membership_no varchar(15) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	operate_date timestamp NOT NULL,
	pre_salary_amount decimal(15,2) DEFAULT 0,
	salary_amount decimal(15,2) DEFAULT 0,
	entry_br varchar(6),
	pre_academic_salary decimal(15,2) DEFAULT (0),
	academic_salary decimal(15,2) DEFAULT (0),
	pre_remuneration_amount decimal(15,2) DEFAULT (0),
	remuneration_amount decimal(15,2) DEFAULT (0),
	pre_salary_real decimal(15,2) DEFAULT (0),
	salary_real decimal(15,2) DEFAULT (0)
) ;
ALTER TABLE sc_mem_edit_salary ADD PRIMARY KEY (membership_no,entry_date);
ALTER TABLE sc_mem_edit_salary ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_edit_salary ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_mem_edit_salary ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_mem_edit_salary ALTER COLUMN operate_date SET NOT NULL;


