CREATE TABLE sc_mem_m_member_memo (
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	memo_code varchar(15) DEFAULT '00',
	memo_detail varchar(2500),
	entry_date timestamp,
	entry_id varchar(16),
	entry_br varchar(2) DEFAULT '01',
	entry_pc varchar(3),
	cancel_status char(1) DEFAULT '0',
	cancel_date timestamp,
	cancel_id varchar(16),
	cancel_br varchar(2) DEFAULT '01',
	cancel_pc varchar(3),
	memo_amount decimal(15,2) DEFAULT 0,
	operate_date timestamp,
	notify_status char(1) DEFAULT '0',
	drop_emer char(1) DEFAULT '0',
	drop_norm char(1) DEFAULT '0',
	drop_spec char(1) DEFAULT '0',
	drop_coll char(1) DEFAULT '0',
	lon_restruc char(1) DEFAULT '0',
	miss_year numeric(38),
	miss_month numeric(38)
) ;
ALTER TABLE sc_mem_m_member_memo ADD PRIMARY KEY (membership_no,seq_no);
ALTER TABLE sc_mem_m_member_memo ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_m_member_memo ALTER COLUMN seq_no SET NOT NULL;


