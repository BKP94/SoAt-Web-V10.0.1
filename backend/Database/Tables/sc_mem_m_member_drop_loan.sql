CREATE TABLE sc_mem_m_member_drop_loan (
	membership_no varchar(15) NOT NULL,
	loan_type varchar(6) NOT NULL DEFAULT '00',
	drop_reason varchar(6) DEFAULT '00',
	entry_id varchar(16),
	entry_date timestamp
) ;
COMMENT ON TABLE sc_mem_m_member_drop_loan IS E'!N????????????????????N!';
COMMENT ON COLUMN sc_mem_m_member_drop_loan.drop_reason IS E'!N??????????????N!';
COMMENT ON COLUMN sc_mem_m_member_drop_loan.loan_type IS E'!N?????????????N!';
COMMENT ON COLUMN sc_mem_m_member_drop_loan.membership_no IS E'!N?????????????N!';
CREATE INDEX idx_mem_droploan ON sc_mem_m_member_drop_loan (membership_no);
CREATE INDEX idx_mem_droploan_loan_type ON sc_mem_m_member_drop_loan (loan_type);
CREATE INDEX idx_mem_droploan_reason ON sc_mem_m_member_drop_loan (drop_reason);
ALTER TABLE sc_mem_m_member_drop_loan ADD PRIMARY KEY (membership_no,loan_type);


