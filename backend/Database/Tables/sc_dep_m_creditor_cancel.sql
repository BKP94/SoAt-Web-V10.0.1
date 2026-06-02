CREATE TABLE sc_dep_m_creditor_cancel (
	deposit_account_no varchar(15) NOT NULL,
	remark varchar(100),
	entry_id varchar(16),
	entry_date timestamp,
	enrty_br char(2)
) ;
ALTER TABLE sc_dep_m_creditor_cancel ADD PRIMARY KEY (deposit_account_no);
ALTER TABLE sc_dep_m_creditor_cancel ALTER COLUMN deposit_account_no SET NOT NULL;


