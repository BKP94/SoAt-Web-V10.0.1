CREATE TABLE sc_mem_m_member_permit_changed (
	membership_no varchar(15) NOT NULL,
	seq_no numeric(38) NOT NULL DEFAULT 0,
	operate_date timestamp,
	permit_name varchar(30),
	old_status varchar(3),
	new_status varchar(3),
	entry_id varchar(16),
	entry_date timestamp,
	entry_br varchar(6) DEFAULT '01',
	remark_desc varchar(250),
	entry_branch char(2)
) ;
COMMENT ON TABLE sc_mem_m_member_permit_changed IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_member_permit_changed.entry_br IS E'!NN!!MM!';
CREATE INDEX idx_mem_permit_chg ON sc_mem_m_member_permit_changed (membership_no);
CREATE INDEX idx_mem_permit_chg_entry_br ON sc_mem_m_member_permit_changed (entry_br);
CREATE INDEX idx_mem_permit_chg_entry_id ON sc_mem_m_member_permit_changed (entry_id);
ALTER TABLE sc_mem_m_member_permit_changed ADD PRIMARY KEY (membership_no,seq_no);


