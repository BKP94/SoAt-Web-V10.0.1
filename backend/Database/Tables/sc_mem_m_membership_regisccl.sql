CREATE TABLE sc_mem_m_membership_regisccl (
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	resign_doc_no varchar(15),
	entry_id varchar(10),
	entry_date timestamp,
	entry_branch varchar(6)
) ;
COMMENT ON TABLE sc_mem_m_membership_regisccl IS E'!NN!';
CREATE INDEX idx_resigcan_mem ON sc_mem_m_membership_regisccl (membership_no);
ALTER TABLE sc_mem_m_membership_regisccl ADD PRIMARY KEY (membership_no,seq_no);


