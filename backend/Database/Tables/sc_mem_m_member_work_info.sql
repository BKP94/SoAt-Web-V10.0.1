CREATE TABLE sc_mem_m_member_work_info (
	membership_no varchar(15) NOT NULL DEFAULT 'cnv',
	occupation_code varchar(6) DEFAULT '00',
	department_code varchar(6) DEFAULT '00',
	section_code varchar(6) DEFAULT '00',
	position_code varchar(6) DEFAULT '00',
	level_code smallint DEFAULT 0,
	employee_status char(1),
	salary_id varchar(15),
	salary_rate_code decimal(3,1) DEFAULT 0,
	salary_amount decimal(15,2) DEFAULT 0,
	working_date timestamp,
	work_branch varchar(6) DEFAULT '00',
	retire_date timestamp,
	retire_status char(1),
	endingcontract_date timestamp,
	group_position varchar(6) DEFAULT '00',
	experiment_work_date timestamp,
	gov_id varchar(15),
	coop_card_no varchar(50),
	subsection_code varchar(6) DEFAULT '00',
	position_long varchar(150),
	occupation_long varchar(100),
	section_long varchar(100),
	subsection_long varchar(100),
	department_long varchar(100),
	work_branch_long varchar(100),
	seq_no double precision,
	work_address varchar(30),
	work_road varchar(30),
	work_soi varchar(30),
	work_moo varchar(10),
	work_tambol varchar(30),
	work_district_code varchar(6) DEFAULT '00',
	work_province_code varchar(6) DEFAULT '00',
	work_postcode varchar(10),
	work_telephone varchar(50),
	keeping_group_no varchar(6),
	active_status char(1) DEFAULT '0',
	academic_salary decimal(15,2) DEFAULT 0,
	salary_keep_limit decimal(15,2) DEFAULT 999999,
	remuneration_amount decimal(15,2),
	work_01000 varchar(15) DEFAULT '00',
	work_01100 varchar(15) DEFAULT '00',
	work_01110 varchar(15) DEFAULT '00',
	work_01111 varchar(15) DEFAULT '00',
	salary_id_group char(3),
	salary_net decimal(15,2),
	long_group varchar(150),
	long_line varchar(150),
	long_department varchar(150),
	long_office varchar(150),
	long_division varchar(150),
	long_workgroup varchar(150),
	long_subdivision varchar(150),
	long_section varchar(150),
	branch_id char(2),
	salary_real decimal(15,2) DEFAULT (0)
) ;
COMMENT ON TABLE sc_mem_m_member_work_info IS E'!N??????????????N!';
COMMENT ON COLUMN sc_mem_m_member_work_info.department_code IS E'!N???????N!!MM!';
COMMENT ON COLUMN sc_mem_m_member_work_info.employee_status IS E'!N???????????N!!M??????????????M!!V1=???????????,0=??????????????V!';
COMMENT ON COLUMN sc_mem_m_member_work_info.endingcontract_date IS E'!N????????????????N!!M??????????????????????M!';
COMMENT ON COLUMN sc_mem_m_member_work_info.experiment_work_date IS E'!N????????N!!M??????????????M!';
COMMENT ON COLUMN sc_mem_m_member_work_info.gov_id IS E'!N?????????? ???.N!!M???????????????????M!';
COMMENT ON COLUMN sc_mem_m_member_work_info.group_position IS E'!N????????????N!';
COMMENT ON COLUMN sc_mem_m_member_work_info.level_code IS E'!N?????N!!M??????????????M!';
COMMENT ON COLUMN sc_mem_m_member_work_info.membership_no IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_member_work_info.occupation_code IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_member_work_info.position_code IS E'!N???????N!!MM!';
COMMENT ON COLUMN sc_mem_m_member_work_info.retire_date IS E'!N????????????????N!';
COMMENT ON COLUMN sc_mem_m_member_work_info.retire_status IS E'!N??????????N!!M???????????M!!V1=??????,0=????????????V!';
COMMENT ON COLUMN sc_mem_m_member_work_info.salary_amount IS E'!N??????????N!';
COMMENT ON COLUMN sc_mem_m_member_work_info.salary_id IS E'!N??????????????????N!';
COMMENT ON COLUMN sc_mem_m_member_work_info.salary_rate_code IS E'!N????N!!M?????????????M!';
COMMENT ON COLUMN sc_mem_m_member_work_info.section_code IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_mem_m_member_work_info.work_branch IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_member_work_info.working_date IS E'!N???????????N!';
CREATE INDEX idx_mem_work_branch ON sc_mem_m_member_work_info (work_branch);
CREATE INDEX idx_mem_work_department ON sc_mem_m_member_work_info (department_code);
CREATE INDEX idx_mem_work_group_pos ON sc_mem_m_member_work_info (group_position);
CREATE INDEX idx_mem_work_occupation ON sc_mem_m_member_work_info (occupation_code);
CREATE INDEX idx_mem_work_position ON sc_mem_m_member_work_info (position_code);
CREATE INDEX idx_mem_work_salary_level ON sc_mem_m_member_work_info (level_code);
CREATE INDEX idx_mem_work_salary_rate ON sc_mem_m_member_work_info (level_code, salary_rate_code);
CREATE INDEX idx_mem_work_section ON sc_mem_m_member_work_info (section_code);
ALTER TABLE sc_mem_m_member_work_info ADD PRIMARY KEY (membership_no);


