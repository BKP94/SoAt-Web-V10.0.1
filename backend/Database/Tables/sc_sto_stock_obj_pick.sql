CREATE TABLE sc_sto_stock_obj_pick (
	obj_pick_id varchar(6) NOT NULL,
	obj_pick_desc varchar(250)
) ;
ALTER TABLE sc_sto_stock_obj_pick ADD PRIMARY KEY (obj_pick_id);
ALTER TABLE sc_sto_stock_obj_pick ALTER COLUMN obj_pick_id SET NOT NULL;


