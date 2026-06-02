CREATE TABLE sc_lon_m_chglog_looping (
	loan_contract_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	modify_type char(3),
	old_approve double precision DEFAULT 0,
	new_approve double precision DEFAULT 0,
	entry_id varchar(16),
	entry_time timestamp,
	entry_br varchar(6)
) ;
ALTER TABLE sc_lon_m_chglog_looping ADD PRIMARY KEY (loan_contract_no,seq_no);
ALTER TABLE sc_lon_m_chglog_looping ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_lon_m_chglog_looping ALTER COLUMN seq_no SET NOT NULL;


