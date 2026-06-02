CREATE TABLE sc_mem_m_insure_ucf (
	item_type varchar(6) NOT NULL DEFAULT '00',
	item_type_desc varchar(50),
	sign_flage double precision DEFAULT 0
) ;
ALTER TABLE sc_mem_m_insure_ucf ADD PRIMARY KEY (item_type);
ALTER TABLE sc_mem_m_insure_ucf ALTER COLUMN item_type SET NOT NULL;


