CREATE TABLE sc_kep_m_ucf_process_by_mtype (
	proc_code varchar(3) NOT NULL,
	mem_type_code varchar(6) NOT NULL DEFAULT '00'
) ;
ALTER TABLE sc_kep_m_ucf_process_by_mtype ADD PRIMARY KEY (proc_code,mem_type_code);


