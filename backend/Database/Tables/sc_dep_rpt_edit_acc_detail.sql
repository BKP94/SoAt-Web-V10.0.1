CREATE TABLE sc_dep_rpt_edit_acc_detail (
	deposit_account_no char(15),
	seq_no double precision,
	entry_date timestamp,
	entry_id varchar(20),
	working_day timestamp,
	client_name varchar(20),
	branch_id char(2),
	detail_error varchar(200),
	detail_old varchar(200),
	detail_new varchar(200)
) ;


