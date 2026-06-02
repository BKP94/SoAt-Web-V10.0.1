CREATE TABLE sc_mem_m_chg_accno (
	acc_type varchar(6) NOT NULL,
	seq_no bigint NOT NULL,
	membership_no varchar(15) NOT NULL,
	bank_old varchar(6),
	accno_old varchar(15),
	bank_new varchar(6) NOT NULL,
	accno_new varchar(15) NOT NULL,
	remark varchar(100),
	entry_date timestamp NOT NULL,
	entry_id varchar(15) NOT NULL,
	app_status char(1) NOT NULL,
	app_date timestamp,
	app_id varchar(15)
) ;
ALTER TABLE sc_mem_m_chg_accno ADD PRIMARY KEY (acc_type,seq_no);
ALTER TABLE sc_mem_m_chg_accno ALTER COLUMN acc_type SET NOT NULL;
ALTER TABLE sc_mem_m_chg_accno ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_mem_m_chg_accno ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_m_chg_accno ALTER COLUMN bank_new SET NOT NULL;
ALTER TABLE sc_mem_m_chg_accno ALTER COLUMN accno_new SET NOT NULL;
ALTER TABLE sc_mem_m_chg_accno ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_mem_m_chg_accno ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_mem_m_chg_accno ALTER COLUMN app_status SET NOT NULL;


