CREATE TABLE sc_mem_m_application_form (
	application_form_no varchar(15) NOT NULL,
	member_group_no varchar(15),
	apply_date timestamp,
	prename_code varchar(6) DEFAULT '000',
	member_name varchar(50),
	member_surname varchar(50),
	sex char(1) DEFAULT 'M',
	marriage_status char(1),
	date_of_birth timestamp,
	age double precision,
	nationality_code varchar(6) DEFAULT '01',
	race_code varchar(6),
	graduate_code varchar(6),
	occupation_code varchar(6),
	father varchar(50),
	mother varchar(50),
	spouse_name varchar(50),
	child_no double precision,
	marriage_register_district varchar(50),
	marriage_license varchar(15),
	marriage_date timestamp,
	living_status char(1),
	approve_status char(1) DEFAULT '2',
	cremation_member char(1),
	welfare_member char(1),
	appl_type_code char(1) DEFAULT '1',
	salary_id varchar(15),
	remark varchar(100),
	branch_id varchar(6),
	approve_date timestamp,
	approve_id varchar(16),
	hum_id varchar(15),
	mem_type varchar(6) DEFAULT '01',
	return_type_code varchar(3),
	working_date timestamp,
	tranapp_date timestamp,
	blood_code varchar(6),
	ending_contractdate timestamp,
	application_form_new char(15),
	crem_memno varchar(15),
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_branch varchar(6),
	cancel_code varchar(3),
	approve_branch varchar(6),
	drop_loanemer_status char(1) DEFAULT '0',
	drop_loanspec_status char(1) DEFAULT '0',
	drop_loannormal_status char(1) DEFAULT '0',
	drop_collactelral_status char(1) DEFAULT '0',
	doc_place_status varchar(6) DEFAULT '00',
	entry_date timestamp,
	entry_id varchar(16),
	cancel_status char(1) DEFAULT '0',
	resolutions varchar(6) DEFAULT '00',
	cancel_reason varchar(100),
	method_recieve_dividend varchar(3) DEFAULT '00',
	approve_memno varchar(15),
	eng_name varchar(50),
	mobile_number varchar(15),
	work_telephone varchar(50),
	bank_acc_no varchar(15),
	permanent_road varchar(30),
	bank_code varchar(6),
	permanent_tambol varchar(50),
	group_position varchar(6),
	keep_memno varchar(7),
	keep_gain_code varchar(6),
	email varchar(100),
	prename_eng varchar(50),
	name_eng varchar(50),
	surname_eng varchar(50),
	id_card_date timestamp,
	id_card_enddate timestamp,
	id_card_number varchar(50),
	id_card_organize varchar(100),
	election_group varchar(15) DEFAULT '00',
	retire_date timestamp
) ;
COMMENT ON TABLE sc_mem_m_application_form IS E'!N???????????????????N!';
COMMENT ON COLUMN sc_mem_m_application_form.appl_type_code IS E'!N??????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_application_form.application_form_no IS E'!N?????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_application_form.apply_date IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_application_form.approve_status IS E'!N????????????N!!V0-??????????,1-???????,2-?????????V!!MM!';
COMMENT ON COLUMN sc_mem_m_application_form.blood_code IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_application_form.cancel_status IS E'!N???????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_application_form.date_of_birth IS E'!N???????N!!MM!';
COMMENT ON COLUMN sc_mem_m_application_form.doc_place_status IS E'!N????????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_application_form.drop_collactelral_status IS E'!N??????N!!M???????????????????????M!';
COMMENT ON COLUMN sc_mem_m_application_form.drop_loanemer_status IS E'!N?? ?.N!!M????????????M!';
COMMENT ON COLUMN sc_mem_m_application_form.drop_loannormal_status IS E'!N?? ?.N!!M??????????M!';
COMMENT ON COLUMN sc_mem_m_application_form.drop_loanspec_status IS E'!N?? ?.N!!M??????????M!';
COMMENT ON COLUMN sc_mem_m_application_form.father IS E'!N????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_application_form.hum_id IS E'!N?????.?.?N!!M?????????????????????????M!';
COMMENT ON COLUMN sc_mem_m_application_form.marriage_status IS E'!N???????N!!MM!';
COMMENT ON COLUMN sc_mem_m_application_form.mem_type IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_application_form.member_group_no IS E'!N?????N!!MM!';
COMMENT ON COLUMN sc_mem_m_application_form.member_name IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_mem_m_application_form.member_surname IS E'!N????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_application_form.mother IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_application_form.nationality_code IS E'!N???????N!!MM!';
COMMENT ON COLUMN sc_mem_m_application_form.prename_code IS E'!N????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_application_form.remark IS E'!N????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_application_form.sex IS E'!N???N!!MM!';
CREATE INDEX idx_app_appdate ON sc_mem_m_application_form (apply_date);
CREATE INDEX idx_app_approve ON sc_mem_m_application_form (approve_status);
CREATE INDEX idx_app_group ON sc_mem_m_application_form (member_group_no);
CREATE INDEX idx_app_prename ON sc_mem_m_application_form (prename_code);
CREATE INDEX idx_mem_app_form_approve_br ON sc_mem_m_application_form (approve_branch);
CREATE INDEX idx_mem_app_form_approve_id ON sc_mem_m_application_form (approve_id);
CREATE INDEX idx_mem_app_form_apptype ON sc_mem_m_application_form (appl_type_code);
CREATE INDEX idx_mem_app_form_blood_code ON sc_mem_m_application_form (blood_code);
CREATE INDEX idx_mem_app_form_branch_id ON sc_mem_m_application_form (branch_id);
CREATE INDEX idx_mem_app_form_cancel_br ON sc_mem_m_application_form (cancel_branch);
CREATE INDEX idx_mem_app_form_cancel_code ON sc_mem_m_application_form (cancel_code);
CREATE INDEX idx_mem_app_form_cancel_id ON sc_mem_m_application_form (cancel_id);
CREATE INDEX idx_mem_app_form_docplace ON sc_mem_m_application_form (doc_place_status);
CREATE INDEX idx_mem_app_form_entry_id ON sc_mem_m_application_form (entry_id);
CREATE INDEX idx_mem_app_form_marriage ON sc_mem_m_application_form (marriage_status);
CREATE INDEX idx_mem_app_form_memtype ON sc_mem_m_application_form (mem_type);
CREATE INDEX idx_mem_app_form_nationality ON sc_mem_m_application_form (nationality_code);
ALTER TABLE sc_mem_m_application_form ADD PRIMARY KEY (application_form_no);


