CREATE TABLE sc_fin_m_agent_officer (
	agent_no varchar(15) NOT NULL,
	id_card varchar(15) NOT NULL,
	prename_code varchar(4),
	officer_name varchar(50),
	officer_surname varchar(50)
) ;
ALTER TABLE sc_fin_m_agent_officer ADD PRIMARY KEY (agent_no,id_card);
ALTER TABLE sc_fin_m_agent_officer ALTER COLUMN agent_no SET NOT NULL;
ALTER TABLE sc_fin_m_agent_officer ALTER COLUMN id_card SET NOT NULL;


