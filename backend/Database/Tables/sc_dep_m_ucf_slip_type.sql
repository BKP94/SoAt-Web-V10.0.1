CREATE TABLE sc_dep_m_ucf_slip_type (
	slip_type varchar(3) NOT NULL,
	slip_desc varchar(20),
	sort_order numeric(38)
) ;
ALTER TABLE sc_dep_m_ucf_slip_type ADD PRIMARY KEY (slip_type);


