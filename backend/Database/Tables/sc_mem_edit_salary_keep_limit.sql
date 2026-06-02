CREATE TABLE sc_mem_edit_salary_keep_limit (
	membership_no varchar(15) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	operate_date timestamp NOT NULL,
	pre_salary_keep_limit decimal(15,2) DEFAULT 0,
	salary_keep_limit decimal(15,2) DEFAULT 0,
	entry_br varchar(6)
) ;
ALTER TABLE sc_mem_edit_salary_keep_limit ADD PRIMARY KEY (membership_no,entry_date);
ALTER TABLE sc_mem_edit_salary_keep_limit ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_edit_salary_keep_limit ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_mem_edit_salary_keep_limit ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_mem_edit_salary_keep_limit ALTER COLUMN operate_date SET NOT NULL;


