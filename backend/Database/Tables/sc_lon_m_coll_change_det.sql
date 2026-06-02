CREATE TABLE sc_lon_m_coll_change_det (
	change_doc_no varchar(10) NOT NULL,
	seq_no double precision NOT NULL,
	operate_type varchar(6),
	old_collateral_type varchar(6),
	old_collateral_no varchar(15),
	old_collateral_refno varchar(20),
	old_collateral_description varchar(100),
	old_collateral_amount decimal(15,2),
	new_collateral_type varchar(6),
	new_collateral_refno varchar(20),
	new_collateral_description varchar(100),
	new_collateral_amount decimal(15,2),
	new_mem_coll varchar(7),
	new_support_coll char(1) DEFAULT '0',
	item_status char(1) DEFAULT '0',
	evaluate_coll decimal(15,2) DEFAULT 0,
	old_mem_coll varchar(7)
) ;
COMMENT ON TABLE sc_lon_m_coll_change_det IS E'!N??????????????????? DN!!MM!';
COMMENT ON COLUMN sc_lon_m_coll_change_det.change_doc_no IS E'!NN!!MM!';
ALTER TABLE sc_lon_m_coll_change_det ADD PRIMARY KEY (change_doc_no,seq_no);


