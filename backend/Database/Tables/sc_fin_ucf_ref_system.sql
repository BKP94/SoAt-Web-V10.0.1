CREATE TABLE sc_fin_ucf_ref_system (
	ref_system varchar(3) NOT NULL,
	ref_desc varchar(50),
	vourcher_type char(1),
	receipt_print_status char(1) DEFAULT '0',
	form_vourcher_p varchar(100),
	shot_app varchar(3)
) ;
COMMENT ON TABLE sc_fin_ucf_ref_system IS E'!NN!';
ALTER TABLE sc_fin_ucf_ref_system ADD PRIMARY KEY (ref_system);


