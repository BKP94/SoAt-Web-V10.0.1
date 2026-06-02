CREATE TABLE sc_dep_t_dwt_detail (
	deposit_account_no char(15),
	deposit_slip_no char(15),
	seq_no double precision,
	operate_date timestamp,
	type_deposit char(2),
	item_type char(3),
	amount decimal(15,2),
	from_system varchar(30),
	from_system_seq double precision,
	entry_date timestamp,
	entry_id varchar(20),
	branch_id char(2),
	working_day timestamp,
	cancle_status char(1),
	ref_seq_no double precision,
	fin_status char(1),
	vourcher_no char(15),
	cancel_vourcher_no char(15)
) ;


