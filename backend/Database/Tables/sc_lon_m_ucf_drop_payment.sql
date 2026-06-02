CREATE TABLE sc_lon_m_ucf_drop_payment (
	drop_payment_status char(1) NOT NULL,
	drop_payment_desc varchar(100)
) ;
ALTER TABLE sc_lon_m_ucf_drop_payment ADD PRIMARY KEY (drop_payment_status);
ALTER TABLE sc_lon_m_ucf_drop_payment ALTER COLUMN drop_payment_status SET NOT NULL;


