CREATE TABLE sc_crm_cnt_parent (
	parent_code varchar(6) NOT NULL DEFAULT '00',
	parent_name varchar(100)
) ;
ALTER TABLE sc_crm_cnt_parent ADD PRIMARY KEY (parent_code);


