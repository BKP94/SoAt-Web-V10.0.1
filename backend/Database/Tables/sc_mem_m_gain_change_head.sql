CREATE TABLE sc_mem_m_gain_change_head (
	change_doc_no varchar(10) NOT NULL,
	membership_no varchar(15),
	member_name varchar(100),
	change_date timestamp,
	approve_status char(1) DEFAULT '2',
	entry_id varchar(16),
	entry_date timestamp,
	remark varchar(100),
	approve_date timestamp,
	approve_id varchar(16),
	remark2 varchar(100),
	cancel_status char(1) NOT NULL DEFAULT '0',
	cancel_date timestamp,
	cancel_id varchar(16),
	entry_br varchar(6),
	condition_1 varchar(4000),
	condition_2 varchar(4000),
	condition_3 varchar(4000)
) ;
ALTER TABLE sc_mem_m_gain_change_head ADD PRIMARY KEY (change_doc_no);
ALTER TABLE sc_mem_m_gain_change_head ALTER COLUMN change_doc_no SET NOT NULL;
ALTER TABLE sc_mem_m_gain_change_head ALTER COLUMN cancel_status SET NOT NULL;


