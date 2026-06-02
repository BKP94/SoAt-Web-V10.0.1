CREATE TABLE sc_mem_m_member_card (
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	date_issue timestamp,
	date_expire timestamp,
	receive_status char(1) DEFAULT '0',
	receive_date timestamp,
	receive_person varchar(100),
	reason_code varchar(6) DEFAULT '00',
	reason_remark varchar(200),
	entry_id varchar(16),
	entry_date timestamp,
	entry_br varchar(6),
	entry_pc varchar(3),
	cancel_status char(1) DEFAULT '0',
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_br varchar(6),
	cancel_pc varchar(3),
	card_no varchar(15)
) ;
ALTER TABLE sc_mem_m_member_card ADD PRIMARY KEY (membership_no,seq_no);
ALTER TABLE sc_mem_m_member_card ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_m_member_card ALTER COLUMN seq_no SET NOT NULL;


