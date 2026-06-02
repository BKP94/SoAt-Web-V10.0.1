CREATE TABLE sc_mem_m_member_reg_no_control (
	membership_no varchar(15) NOT NULL,
	member_name varchar(50),
	member_surname varchar(50),
	approve_date timestamp,
	approve_man varchar(100),
	registration_status char(1),
	recrieve_status char(1),
	registration_date varchar(20),
	entry_type varchar(3),
	approve_id varchar(16),
	recrieve_docno varchar(15),
	recrieve_date timestamp
) ;
COMMENT ON TABLE sc_mem_m_member_reg_no_control IS E'!N?????????????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_member_reg_no_control.recrieve_docno IS E'!N??????????????????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_member_reg_no_control.recrieve_status IS E'!NN!!MM!';
CREATE INDEX idx_mem_reqno_approve_id ON sc_mem_m_member_reg_no_control (approve_id);
CREATE INDEX idx_reg_no_control_appdate ON sc_mem_m_member_reg_no_control (approve_date);
CREATE INDEX idx_reg_no_control_recstatus ON sc_mem_m_member_reg_no_control (recrieve_status);
ALTER TABLE sc_mem_m_member_reg_no_control ADD PRIMARY KEY (membership_no);


