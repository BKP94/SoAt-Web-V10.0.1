CREATE TABLE si_sys_process (
	control_name varchar(50) NOT NULL,
	action_type char(1) NOT NULL,
	process_name varchar(50),
	dw_name varchar(50),
	alert_message varchar(70),
	notcall_pfcnew char(1),
	confirm_message varchar(70),
	function_name varchar(50),
	cols_arg varchar(50)
) ;
ALTER TABLE si_sys_process ADD PRIMARY KEY (control_name,action_type);
ALTER TABLE si_sys_process ALTER COLUMN control_name SET NOT NULL;
ALTER TABLE si_sys_process ALTER COLUMN action_type SET NOT NULL;


