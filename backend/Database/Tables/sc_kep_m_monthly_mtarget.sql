CREATE TABLE sc_kep_m_monthly_mtarget (
	client_pc varchar(3) NOT NULL,
	membership_no varchar(15) NOT NULL
) ;
ALTER TABLE sc_kep_m_monthly_mtarget ADD PRIMARY KEY (client_pc,membership_no);
ALTER TABLE sc_kep_m_monthly_mtarget ALTER COLUMN client_pc SET NOT NULL;
ALTER TABLE sc_kep_m_monthly_mtarget ALTER COLUMN membership_no SET NOT NULL;


