CREATE TABLE sc_mem_m_member_children (
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	children_name varchar(250),
	date_of_birth timestamp,
	entry_id varchar(16),
	entry_date timestamp,
	entry_br varchar(6)
) ;
ALTER TABLE sc_mem_m_member_children ADD PRIMARY KEY (membership_no,seq_no);
ALTER TABLE sc_mem_m_member_children ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_m_member_children ALTER COLUMN seq_no SET NOT NULL;


