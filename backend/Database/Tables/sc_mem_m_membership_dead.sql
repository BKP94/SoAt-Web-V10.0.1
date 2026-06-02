CREATE TABLE sc_mem_m_membership_dead (
	membership_no varchar(15) NOT NULL,
	dead_date timestamp,
	receive_status char(1) DEFAULT '0',
	receive_year double precision,
	receive_month double precision,
	receive_entry_id varchar(16),
	receive_entry_date timestamp
) ;
ALTER TABLE sc_mem_m_membership_dead ADD PRIMARY KEY (membership_no);
ALTER TABLE sc_mem_m_membership_dead ALTER COLUMN membership_no SET NOT NULL;


