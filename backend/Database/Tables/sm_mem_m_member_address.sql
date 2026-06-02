CREATE TABLE sm_mem_m_member_address (
	membership_no varchar(15) NOT NULL,
	address_type char(1) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mem_m_member_address ADD PRIMARY KEY (membership_no,address_type,sm_seq);
ALTER TABLE sm_mem_m_member_address ALTER COLUMN sm_seq SET NOT NULL;


