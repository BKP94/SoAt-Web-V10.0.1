CREATE TABLE sc_mem_m_app_work_info (
	application_form_no varchar(15) NOT NULL,
	seq_no double precision DEFAULT 0,
	occupation_code varchar(6),
	department_code varchar(6),
	section_code varchar(6),
	position_code varchar(6),
	level_code smallint DEFAULT 0,
	employee_status char(1) DEFAULT '0',
	salary_id varchar(15),
	salary_rate_code decimal(3,1) DEFAULT 0,
	salary_amount decimal(15,2) DEFAULT 0,
	working_date timestamp,
	work_branch varchar(6),
	work_address varchar(30),
	work_road varchar(30),
	work_soi varchar(30),
	work_moo varchar(10),
	work_tambol varchar(30),
	work_district_code varchar(6),
	work_province_code varchar(6),
	work_postcode varchar(10),
	work_telephone varchar(50),
	retire_date timestamp,
	retire_status char(1),
	endingcontract_date timestamp,
	group_position varchar(6),
	experiment_work_date timestamp,
	subsection_code varchar(6) DEFAULT '00',
	gov_id varchar(15),
	position_long varchar(100),
	occupation_long varchar(100),
	section_long varchar(100),
	subsection_long varchar(100),
	department_long varchar(100),
	work_branch_long varchar(100),
	keeping_group_no varchar(6),
	level_code_string varchar(100),
	academic_salary decimal(15,2) DEFAULT 0,
	remuneration_amount decimal(15,2) DEFAULT 0.00,
	group_other varchar(100),
	salary_real decimal(15,2) DEFAULT (0)
) ;
COMMENT ON TABLE sc_mem_m_app_work_info IS E'!N??????????????N!';
COMMENT ON COLUMN sc_mem_m_app_work_info.application_form_no IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_work_info.department_code IS E'!N???????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_work_info.employee_status IS E'!N??????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_work_info.endingcontract_date IS E'!N??????????????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_work_info.experiment_work_date IS E'!N??????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_work_info.group_position IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_work_info.level_code IS E'!N?????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_work_info.occupation_code IS E'!N?????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_work_info.position_code IS E'!N???????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_work_info.retire_date IS E'!N????????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_work_info.salary_amount IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_work_info.salary_id IS E'!N?????????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_work_info.salary_rate_code IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_work_info.section_code IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_work_info.work_telephone IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_work_info.working_date IS E'!N??????????????????????N!!MM!';
CREATE INDEX idx_mem_app_work_branch ON sc_mem_m_app_work_info (work_branch);
CREATE INDEX idx_mem_app_work_department ON sc_mem_m_app_work_info (occupation_code, department_code);
CREATE INDEX idx_mem_app_work_distinct ON sc_mem_m_app_work_info (work_district_code, work_province_code);
CREATE INDEX idx_mem_app_work_group_pos ON sc_mem_m_app_work_info (group_position);
CREATE INDEX idx_mem_app_work_occupation ON sc_mem_m_app_work_info (occupation_code);
CREATE INDEX idx_mem_app_work_position ON sc_mem_m_app_work_info (position_code);
CREATE INDEX idx_mem_app_work_province ON sc_mem_m_app_work_info (work_province_code);
CREATE INDEX idx_mem_app_work_salary_level ON sc_mem_m_app_work_info (level_code);
CREATE INDEX idx_mem_app_work_salary_rate ON sc_mem_m_app_work_info (level_code, salary_rate_code);
CREATE INDEX idx_mem_app_work_section ON sc_mem_m_app_work_info (occupation_code, department_code, section_code);
ALTER TABLE sc_mem_m_app_work_info ADD PRIMARY KEY (application_form_no);


