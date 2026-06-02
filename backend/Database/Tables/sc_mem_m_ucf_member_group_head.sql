CREATE TABLE sc_mem_m_ucf_member_group_head (
	member_group_no varchar(15) NOT NULL,
	order_no double precision NOT NULL,
	seq_no double precision NOT NULL,
	head_name varchar(200),
	head_position varchar(200),
	head_sign bytea,
	telephone varchar(50),
	entry_id varchar(16),
	entry_date timestamp,
	head_sign_old bytea
) ;
ALTER TABLE sc_mem_m_ucf_member_group_head ADD PRIMARY KEY (member_group_no,order_no,seq_no);
ALTER TABLE sc_mem_m_ucf_member_group_head ALTER COLUMN member_group_no SET NOT NULL;
ALTER TABLE sc_mem_m_ucf_member_group_head ALTER COLUMN order_no SET NOT NULL;
ALTER TABLE sc_mem_m_ucf_member_group_head ALTER COLUMN seq_no SET NOT NULL;


