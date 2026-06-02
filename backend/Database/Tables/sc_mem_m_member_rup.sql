CREATE TABLE sc_mem_m_member_rup (
	rup_date timestamp NOT NULL,
	seq_no integer NOT NULL,
	rup_name varchar(100),
	rup_id varchar(100),
	rup_book_no varchar(100),
	rup_book_date varchar(100),
	entry_id varchar(16) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_br varchar(6) NOT NULL
) ;
ALTER TABLE sc_mem_m_member_rup ADD PRIMARY KEY (rup_date,seq_no);
ALTER TABLE sc_mem_m_member_rup ALTER COLUMN rup_date SET NOT NULL;
ALTER TABLE sc_mem_m_member_rup ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_mem_m_member_rup ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_mem_m_member_rup ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_mem_m_member_rup ALTER COLUMN entry_br SET NOT NULL;


