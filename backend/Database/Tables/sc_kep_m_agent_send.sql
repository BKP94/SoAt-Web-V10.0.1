CREATE TABLE sc_kep_m_agent_send (
	receive_year double precision NOT NULL DEFAULT 0,
	receive_month double precision NOT NULL DEFAULT 0,
	salary_time double precision NOT NULL DEFAULT 0,
	agent_no varchar(15) NOT NULL,
	keeping_amount decimal(15,2) DEFAULT 0,
	keeping_lock char(1) DEFAULT '0',
	keeping_balance decimal(15,2) DEFAULT 0,
	keeping_calc decimal(15,2) DEFAULT 0,
	count_mem bigint DEFAULT 0,
	count_return bigint DEFAULT 0,
	return_amount decimal(15,2) DEFAULT 0,
	comp_amount decimal(15,2) DEFAULT 0,
	comp_post char(1) DEFAULT '0',
	agent_status char(1) DEFAULT '0',
	agent_amount decimal(15,2) DEFAULT 0,
	agent_balance decimal(15,2) DEFAULT 0,
	agent_count_return bigint DEFAULT 0,
	agent_return decimal(15,2) DEFAULT 0,
	mod_id varchar(16) NOT NULL,
	mod_date timestamp NOT NULL,
	mod_br varchar(6) NOT NULL,
	mod_pc varchar(3) NOT NULL,
	vourcher_no varchar(15),
	link_book_bank char(1) DEFAULT '0',
	book_bank_fin varchar(15),
	book_bank_seq numeric(38) DEFAULT 0,
	post_status char(1) DEFAULT '0',
	post_date timestamp,
	agent_sended char(1),
	count_return_file bigint DEFAULT 0,
	return_amount_file decimal(15,2) DEFAULT 0,
	kep_limit decimal(15,2) DEFAULT 0.00
) ;
ALTER TABLE sc_kep_m_agent_send ADD PRIMARY KEY (receive_year,receive_month,salary_time,agent_no);
ALTER TABLE sc_kep_m_agent_send ALTER COLUMN receive_year SET NOT NULL;
ALTER TABLE sc_kep_m_agent_send ALTER COLUMN receive_month SET NOT NULL;
ALTER TABLE sc_kep_m_agent_send ALTER COLUMN salary_time SET NOT NULL;
ALTER TABLE sc_kep_m_agent_send ALTER COLUMN agent_no SET NOT NULL;
ALTER TABLE sc_kep_m_agent_send ALTER COLUMN mod_id SET NOT NULL;
ALTER TABLE sc_kep_m_agent_send ALTER COLUMN mod_date SET NOT NULL;
ALTER TABLE sc_kep_m_agent_send ALTER COLUMN mod_br SET NOT NULL;
ALTER TABLE sc_kep_m_agent_send ALTER COLUMN mod_pc SET NOT NULL;


