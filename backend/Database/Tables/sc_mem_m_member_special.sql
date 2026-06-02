CREATE TABLE sc_mem_m_member_special (
	membership_no varchar(15) NOT NULL,
	debtor_code varchar(6),
	deptor_detail varchar(100),
	seq_no double precision NOT NULL DEFAULT 0,
	entry_date timestamp,
	entry_id varchar(16),
	entry_br varchar(6) DEFAULT '01',
	entry_pc varchar(3),
	cancel_status char(1) DEFAULT '0',
	cancel_date timestamp,
	cancel_id varchar(16),
	cancel_br varchar(6) DEFAULT '01',
	cancel_pc varchar(3),
	approve_date timestamp,
	approve_userid varchar(16),
	approve_branch varchar(6),
	approve_cilent varchar(50),
	lastedit_date timestamp,
	lastedit_userid varchar(16),
	lastedit_branch varchar(6),
	lastedit_cilent varchar(50),
	special_code varchar(6)
) ;
COMMENT ON TABLE sc_mem_m_member_special IS E'!N???????????????????N!';
COMMENT ON COLUMN sc_mem_m_member_special.cancel_br IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_member_special.cancel_date IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_member_special.cancel_id IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_member_special.cancel_pc IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_member_special.cancel_status IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_member_special.debtor_code IS E'!N??????????N!';
COMMENT ON COLUMN sc_mem_m_member_special.deptor_detail IS E'!N????????N!';
COMMENT ON COLUMN sc_mem_m_member_special.entry_br IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_member_special.entry_date IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_member_special.entry_id IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_member_special.entry_pc IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_member_special.membership_no IS E'!N?????????????N!';
COMMENT ON COLUMN sc_mem_m_member_special.seq_no IS E'!NN!';
CREATE INDEX idx_mem_special ON sc_mem_m_member_special (membership_no);
CREATE INDEX idx_mem_special_cancel_br ON sc_mem_m_member_special (cancel_br);
CREATE INDEX idx_mem_special_cancel_id ON sc_mem_m_member_special (cancel_id);
CREATE INDEX idx_mem_special_cancel_pc ON sc_mem_m_member_special (cancel_pc);
CREATE INDEX idx_mem_special_debtor ON sc_mem_m_member_special (debtor_code);
CREATE INDEX idx_mem_special_entry_br ON sc_mem_m_member_special (entry_br);
CREATE INDEX idx_mem_special_entry_id ON sc_mem_m_member_special (entry_id);
CREATE INDEX idx_mem_special_entry_pc ON sc_mem_m_member_special (entry_pc);
ALTER TABLE sc_mem_m_member_special ADD PRIMARY KEY (membership_no,seq_no);


