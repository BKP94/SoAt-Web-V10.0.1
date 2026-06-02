CREATE TABLE sc_est_m_ucf_borrow_objective (
	borrow_objective_code varchar(26) NOT NULL,
	borrow_objective_desc varchar(200),
	sort_order double precision
) ;
ALTER TABLE sc_est_m_ucf_borrow_objective ADD PRIMARY KEY (borrow_objective_code);
ALTER TABLE sc_est_m_ucf_borrow_objective ALTER COLUMN borrow_objective_code SET NOT NULL;


