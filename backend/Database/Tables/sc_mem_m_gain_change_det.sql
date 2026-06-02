CREATE TABLE sc_mem_m_gain_change_det (
	change_doc_no varchar(10) NOT NULL,
	seq_no integer NOT NULL DEFAULT 0,
	operate_type varchar(2) DEFAULT '00',
	old_prename_code varchar(6),
	old_gain_name varchar(50),
	old_gain_surname varchar(50),
	old_concern_code varchar(2) DEFAULT '00',
	old_book_date timestamp,
	old_order_number integer DEFAULT 0,
	old_gain_address varchar(200),
	old_gain_id_card varchar(15),
	old_gain_telephone varchar(50),
	old_gain_desc varchar(200),
	old_gain_percent decimal(15,4) DEFAULT 0,
	new_prename_code varchar(6),
	new_gain_name varchar(50),
	new_gain_surname varchar(50),
	new_concern_code varchar(2) DEFAULT '00',
	new_book_date timestamp,
	new_order_number integer DEFAULT 0,
	new_gain_address varchar(200),
	new_gain_id_card varchar(15),
	new_gain_telephone varchar(50),
	new_gain_desc varchar(200),
	new_gain_percent decimal(15,4) DEFAULT 0,
	old_wef_type varchar(3),
	new_wef_type varchar(3)
) ;
ALTER TABLE sc_mem_m_gain_change_det ADD PRIMARY KEY (change_doc_no,seq_no);
ALTER TABLE sc_mem_m_gain_change_det ALTER COLUMN change_doc_no SET NOT NULL;
ALTER TABLE sc_mem_m_gain_change_det ALTER COLUMN seq_no SET NOT NULL;


