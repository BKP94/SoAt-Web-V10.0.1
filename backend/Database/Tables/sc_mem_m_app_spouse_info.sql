CREATE TABLE sc_mem_m_app_spouse_info (
	application_form_no varchar(15) NOT NULL,
	seq_no double precision DEFAULT 0,
	prename_code varchar(6) DEFAULT '000',
	spouse_name varchar(50),
	spouse_surname varchar(50),
	salary_calloan decimal(15,2) DEFAULT 0,
	occupation_code varchar(6),
	position_code varchar(6),
	level_code smallint DEFAULT 0,
	salary_amount decimal(15,2) DEFAULT 0,
	work_branch varchar(6),
	work_address varchar(50),
	work_road varchar(50),
	work_soi varchar(50),
	work_moo varchar(50),
	work_tambol varchar(50),
	work_district_code varchar(6),
	work_province_code varchar(6),
	work_postcode varchar(10),
	work_telephone varchar(50),
	spouse_member_no varchar(15),
	date_of_birth timestamp,
	tax_id varchar(15),
	id_card varchar(15),
	workname varchar(50),
	department_code char(2),
	section_code char(2),
	employee_status char(1),
	salary_id char(15),
	salary_rate_code decimal(3,1),
	working_date timestamp,
	retire_date timestamp,
	retire_status char(1)
) ;
COMMENT ON TABLE sc_mem_m_app_spouse_info IS E'!N?????????????N!';
COMMENT ON COLUMN sc_mem_m_app_spouse_info.application_form_no IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_spouse_info.level_code IS E'!NN!!MM!';
COMMENT ON COLUMN sc_mem_m_app_spouse_info.occupation_code IS E'!N?????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_spouse_info.position_code IS E'!N???????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_spouse_info.prename_code IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_spouse_info.salary_amount IS E'!N????????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_spouse_info.salary_calloan IS E'!N????????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_spouse_info.spouse_name IS E'!N????N!!M???????????M!';
COMMENT ON COLUMN sc_mem_m_app_spouse_info.spouse_surname IS E'!N????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_spouse_info.work_address IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_spouse_info.work_branch IS E'!NN!!MM!';
COMMENT ON COLUMN sc_mem_m_app_spouse_info.work_district_code IS E'!N?????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_spouse_info.work_moo IS E'!N???????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_spouse_info.work_postcode IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_spouse_info.work_province_code IS E'!N???????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_spouse_info.work_road IS E'!N???N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_spouse_info.work_soi IS E'!N???N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_spouse_info.work_tambol IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_mem_m_app_spouse_info.work_telephone IS E'!N?????????????N!!MM!';
CREATE INDEX idx_mem_app_spouse_district ON sc_mem_m_app_spouse_info (work_district_code, work_province_code);
CREATE INDEX idx_mem_app_spouse_occupation ON sc_mem_m_app_spouse_info (occupation_code);
CREATE INDEX idx_mem_app_spouse_position ON sc_mem_m_app_spouse_info (position_code);
CREATE INDEX idx_mem_app_spouse_prename ON sc_mem_m_app_spouse_info (prename_code);
CREATE INDEX idx_mem_app_spouse_province ON sc_mem_m_app_spouse_info (work_province_code);
CREATE INDEX idx_mem_app_spouse_salary_leve ON sc_mem_m_app_spouse_info (level_code);
ALTER TABLE sc_mem_m_app_spouse_info ADD PRIMARY KEY (application_form_no);


