CREATE TABLE sc_fin_ucf_cheque_desc (
	desc_type varchar(6) NOT NULL,
	desc_name varchar(100),
	calc_desc varchar(50),
	active_status char(1) DEFAULT '0',
	sort_order integer,
	note varchar(1000)
) ;
ALTER TABLE sc_fin_ucf_cheque_desc ADD PRIMARY KEY (desc_type);
ALTER TABLE sc_fin_ucf_cheque_desc ALTER COLUMN desc_type SET NOT NULL;


