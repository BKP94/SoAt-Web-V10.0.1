CREATE TABLE sc_fin_close_det (
	operate_date timestamp,
	entry_id varchar(15),
	application_type varchar(10),
	in_branch char(1),
	item_type varchar(6),
	item_des varchar(100),
	item_count integer,
	dr_amount decimal(15,2),
	cr_amount decimal(15,2)
) ;


