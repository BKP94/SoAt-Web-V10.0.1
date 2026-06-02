CREATE TABLE sc_mem_m_ucf_prename_old (
	prename_code char(3) NOT NULL,
	prename char(60),
	sex char(1),
	group_rank char(1) NOT NULL,
	marriage_status char(1) NOT NULL
) ;
CREATE UNIQUE INDEX sc_mem_m_ucf_prename_x ON sc_mem_m_ucf_prename_old (prename_code);
ALTER TABLE sc_mem_m_ucf_prename_old ALTER COLUMN prename_code SET NOT NULL;
ALTER TABLE sc_mem_m_ucf_prename_old ALTER COLUMN group_rank SET NOT NULL;
ALTER TABLE sc_mem_m_ucf_prename_old ALTER COLUMN marriage_status SET NOT NULL;


