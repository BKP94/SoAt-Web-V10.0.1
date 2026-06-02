CREATE TABLE sc_acc_m_ucf_shelf_exp (
	shelf_id varchar(3) NOT NULL,
	shelf_name varchar(100)
) ;
COMMENT ON TABLE sc_acc_m_ucf_shelf_exp IS E'!NN!';
ALTER TABLE sc_acc_m_ucf_shelf_exp ADD PRIMARY KEY (shelf_id);


