CREATE TABLE sc_lon_ins_m_constant (
	coop_registered_no varchar(15) NOT NULL,
	new_contact_begin timestamp,
	loan_insure_force decimal(15,2) DEFAULT 0,
	insure_rate decimal(6,5) DEFAULT 0,
	account_id_int varchar(8)
) ;
ALTER TABLE sc_lon_ins_m_constant ADD PRIMARY KEY (coop_registered_no);


