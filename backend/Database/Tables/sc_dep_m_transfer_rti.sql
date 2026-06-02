CREATE TABLE sc_dep_m_transfer_rti (
	group_no varchar(10) NOT NULL,
	date_fr timestamp NOT NULL,
	date_to timestamp NOT NULL
) ;
ALTER TABLE sc_dep_m_transfer_rti ADD PRIMARY KEY (group_no);
ALTER TABLE sc_dep_m_transfer_rti ALTER COLUMN group_no SET NOT NULL;
ALTER TABLE sc_dep_m_transfer_rti ALTER COLUMN date_fr SET NOT NULL;
ALTER TABLE sc_dep_m_transfer_rti ALTER COLUMN date_to SET NOT NULL;


