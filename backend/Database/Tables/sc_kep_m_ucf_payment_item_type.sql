CREATE TABLE sc_kep_m_ucf_payment_item_type (
	payment_item_type_code varchar(5) NOT NULL,
	payment_item_type_name varchar(100)
) ;
COMMENT ON TABLE sc_kep_m_ucf_payment_item_type IS E'!NN!';
ALTER TABLE sc_kep_m_ucf_payment_item_type ADD PRIMARY KEY (payment_item_type_code);


