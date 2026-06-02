CREATE TABLE sc_mem_m_member_crem_detail (
	membership_no varchar(15) NOT NULL,
	crem_type varchar(6) NOT NULL,
	crem_memno varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	seq_no_det double precision NOT NULL,
	operate_date timestamp,
	item_type char(3),
	item_amount decimal(15,2),
	doc_no varchar(15),
	principal_balance decimal(15,2),
	crem_balance decimal(15,2),
	crem_period numeric(38),
	branch_id varchar(6),
	entry_id varchar(16),
	entry_date timestamp,
	client_pc char(3)
) ;
ALTER TABLE sc_mem_m_member_crem_detail ADD PRIMARY KEY (membership_no,crem_type,crem_memno,seq_no,seq_no_det);
ALTER TABLE sc_mem_m_member_crem_detail ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_m_member_crem_detail ALTER COLUMN crem_type SET NOT NULL;
ALTER TABLE sc_mem_m_member_crem_detail ALTER COLUMN crem_memno SET NOT NULL;
ALTER TABLE sc_mem_m_member_crem_detail ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_mem_m_member_crem_detail ALTER COLUMN seq_no_det SET NOT NULL;


