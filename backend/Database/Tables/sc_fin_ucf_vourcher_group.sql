CREATE TABLE sc_fin_ucf_vourcher_group (
	vourcher_group varchar(7) NOT NULL,
	vourcher_desc varchar(100),
	sign_flag double precision,
	slip_group varchar(7),
	post_to_acc char(1) DEFAULT '1',
	receipt_print_status char(1) DEFAULT '0',
	receipt_type char(1) DEFAULT '0',
	doc_type varchar(6) DEFAULT '00',
	soat_note varchar(100)
) ;
COMMENT ON TABLE sc_fin_ucf_vourcher_group IS E'!NN!';
COMMENT ON COLUMN sc_fin_ucf_vourcher_group.post_to_acc IS E'!N?????????????????N!!MM!';
COMMENT ON COLUMN sc_fin_ucf_vourcher_group.sign_flag IS E'!N????N!!MM!';
COMMENT ON COLUMN sc_fin_ucf_vourcher_group.slip_group IS E'!N?????????N!!MM!';
COMMENT ON COLUMN sc_fin_ucf_vourcher_group.vourcher_desc IS E'!N??????????N!!MM!';
COMMENT ON COLUMN sc_fin_ucf_vourcher_group.vourcher_group IS E'!N?????N!!MM!';
ALTER TABLE sc_fin_ucf_vourcher_group ADD PRIMARY KEY (vourcher_group);


