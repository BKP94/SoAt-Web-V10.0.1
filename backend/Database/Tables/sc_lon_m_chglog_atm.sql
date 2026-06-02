CREATE TABLE sc_lon_m_chglog_atm (
	loan_contract_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	modify_status char(1) NOT NULL DEFAULT '0',
	old_bankacc varchar(15),
	new_bankacc varchar(15),
	entry_id varchar(16),
	entry_time timestamp,
	entry_br varchar(6),
	send_last_no double precision DEFAULT 0
) ;
ALTER TABLE sc_lon_m_chglog_atm ADD PRIMARY KEY (loan_contract_no,seq_no);
ALTER TABLE sc_lon_m_chglog_atm ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_lon_m_chglog_atm ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_lon_m_chglog_atm ALTER COLUMN modify_status SET NOT NULL;


