CREATE TABLE sc_mem_m_member_member_refer (
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	membership_no_ref varchar(15),
	conceern_code varchar(6) DEFAULT '00',
	entry_id varchar(16),
	entry_date timestamp,
	entry_br varchar(6) DEFAULT '01',
	refer_status char(1) DEFAULT '0',
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_br varchar(6) DEFAULT '01',
	entry_pc varchar(3),
	cancel_pc varchar(3)
) ;
COMMENT ON TABLE sc_mem_m_member_member_refer IS E'!N????????????????????N!';
COMMENT ON COLUMN sc_mem_m_member_member_refer.cancel_br IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_member_member_refer.cancel_date IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_member_member_refer.cancel_id IS E'!N?????????N!';
COMMENT ON COLUMN sc_mem_m_member_member_refer.cancel_pc IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_member_member_refer.conceern_code IS E'!N????????????N!';
COMMENT ON COLUMN sc_mem_m_member_member_refer.entry_br IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_member_member_refer.entry_date IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_member_member_refer.entry_id IS E'!N?????????N!';
COMMENT ON COLUMN sc_mem_m_member_member_refer.entry_pc IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_member_member_refer.membership_no IS E'!N?????????????N!';
COMMENT ON COLUMN sc_mem_m_member_member_refer.membership_no_ref IS E'!N?????????????N!!M????????????????????M!';
COMMENT ON COLUMN sc_mem_m_member_member_refer.refer_status IS E'!N?????N!';
COMMENT ON COLUMN sc_mem_m_member_member_refer.seq_no IS E'!NN!';
CREATE INDEX idx_mem_refer ON sc_mem_m_member_member_refer (membership_no);
CREATE INDEX idx_mem_refer_cancel_br ON sc_mem_m_member_member_refer (cancel_br);
CREATE INDEX idx_mem_refer_cancel_id ON sc_mem_m_member_member_refer (cancel_id);
CREATE INDEX idx_mem_refer_cancel_pc ON sc_mem_m_member_member_refer (cancel_pc);
CREATE INDEX idx_mem_refer_concern ON sc_mem_m_member_member_refer (conceern_code);
CREATE INDEX idx_mem_refer_entry_br ON sc_mem_m_member_member_refer (entry_br);
CREATE INDEX idx_mem_refer_entry_id ON sc_mem_m_member_member_refer (entry_id);
CREATE INDEX idx_mem_refer_mem_ref ON sc_mem_m_member_member_refer (membership_no_ref);
ALTER TABLE sc_mem_m_member_member_refer ADD PRIMARY KEY (membership_no,seq_no);


