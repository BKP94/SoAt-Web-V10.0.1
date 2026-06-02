CREATE TABLE sc_lon_edit_data (
	table_name char(30),
	column_name char(30),
	seq_no bigint,
	operate_date timestamp,
	entry_date timestamp,
	user_id char(16),
	client_id char(3),
	branch_id char(2),
	type_of_data char(15),
	old_value varchar(1000),
	new_value varchar(1000),
	ref_value_1 varchar(100),
	ref_value_2 varchar(100),
	ref_value_3 varchar(100),
	ref_value_4 varchar(100),
	ref_value_5 varchar(100),
	edit_type char(3),
	app_name char(30),
	w_sheet_name varchar(50),
	edit_time bigint
) ;


