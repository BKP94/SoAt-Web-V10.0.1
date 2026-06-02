CREATE TABLE sc_mem_m_member_crem_gain (
	membership_no varchar(15) NOT NULL,
	crem_type varchar(6) NOT NULL,
	crem_memno varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	seq_no_gain double precision NOT NULL,
	member_gain_no varchar(15),
	prename_code varchar(6),
	gain_name varchar(50),
	gain_surname varchar(50),
	id_card varchar(15),
	address_gain varchar(255),
	conceern_code varchar(6),
	crem_legate char(1),
	entry_id varchar(16) NOT NULL,
	entry_date timestamp NOT NULL,
	gain_tel varchar(250)
) ;
ALTER TABLE sc_mem_m_member_crem_gain ADD PRIMARY KEY (membership_no,crem_type,crem_memno,seq_no,seq_no_gain);
ALTER TABLE sc_mem_m_member_crem_gain ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_m_member_crem_gain ALTER COLUMN crem_type SET NOT NULL;
ALTER TABLE sc_mem_m_member_crem_gain ALTER COLUMN crem_memno SET NOT NULL;
ALTER TABLE sc_mem_m_member_crem_gain ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_mem_m_member_crem_gain ALTER COLUMN seq_no_gain SET NOT NULL;
ALTER TABLE sc_mem_m_member_crem_gain ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_mem_m_member_crem_gain ALTER COLUMN entry_date SET NOT NULL;


