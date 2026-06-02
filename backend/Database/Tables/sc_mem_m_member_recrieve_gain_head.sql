CREATE TABLE sc_mem_m_member_recrieve_gain_head (
	membership_no varchar(15) NOT NULL,
	change_doc_no varchar(15) NOT NULL,
	condition_1 varchar(4000),
	condition_2 varchar(4000),
	condition_3 varchar(4000)
) ;
ALTER TABLE sc_mem_m_member_recrieve_gain_head ADD PRIMARY KEY (membership_no,change_doc_no);
ALTER TABLE sc_mem_m_member_recrieve_gain_head ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_m_member_recrieve_gain_head ALTER COLUMN change_doc_no SET NOT NULL;


