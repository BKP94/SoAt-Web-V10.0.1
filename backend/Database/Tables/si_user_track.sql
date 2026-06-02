CREATE TABLE si_user_track (
	user_id varchar(15),
	user_branch varchar(15),
	session_id varchar(100),
	action varchar(100),
	action_table varchar(100),
	action_column varchar(2000),
	action_where varchar(500),
	page_app varchar(100),
	app_name varchar(50),
	app_url varchar(100),
	operate_date timestamp
) ;


