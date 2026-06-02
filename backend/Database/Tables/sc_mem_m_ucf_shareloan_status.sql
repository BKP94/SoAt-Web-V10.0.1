CREATE TABLE sc_mem_m_ucf_shareloan_status (
	shareloan_code varchar(6) NOT NULL,
	description varchar(250),
	marktype varchar(6),
	sort_order decimal(15,2) DEFAULT 0
) ;
COMMENT ON TABLE sc_mem_m_ucf_shareloan_status IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_ucf_shareloan_status.description IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_shareloan_status.shareloan_code IS E'!N????N!!MM!';
ALTER TABLE sc_mem_m_ucf_shareloan_status ADD PRIMARY KEY (shareloan_code);


