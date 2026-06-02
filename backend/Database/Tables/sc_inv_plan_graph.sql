CREATE TABLE sc_inv_plan_graph (
	account_year double precision NOT NULL,
	plan_number double precision NOT NULL,
	plan_seq double precision NOT NULL,
	graph_desc varchar(100),
	graph_amount decimal(15,2) DEFAULT 0.00,
	graph_color varchar(50)
) ;
ALTER TABLE sc_inv_plan_graph ADD PRIMARY KEY (account_year,plan_number,plan_seq);
ALTER TABLE sc_inv_plan_graph ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_inv_plan_graph ALTER COLUMN plan_number SET NOT NULL;
ALTER TABLE sc_inv_plan_graph ALTER COLUMN plan_seq SET NOT NULL;


