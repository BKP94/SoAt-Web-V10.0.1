CREATE TABLE sc_kep_m_ucf_process_by_fkg (
	proc_code varchar(3) NOT NULL,
	member_group_keeping varchar(3) NOT NULL
) ;
ALTER TABLE sc_kep_m_ucf_process_by_fkg ADD PRIMARY KEY (proc_code,member_group_keeping);


