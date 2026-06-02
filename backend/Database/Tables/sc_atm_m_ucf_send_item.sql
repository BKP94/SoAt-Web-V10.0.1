CREATE TABLE sc_atm_m_ucf_send_item (
	item_type char(3) NOT NULL,
	item_desc varchar(50)
) ;
ALTER TABLE sc_atm_m_ucf_send_item ADD PRIMARY KEY (item_type);
ALTER TABLE sc_atm_m_ucf_send_item ALTER COLUMN item_type SET NOT NULL;


