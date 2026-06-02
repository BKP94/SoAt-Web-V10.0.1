CREATE TABLE sc_com_m_file_sys_criteria (
	criteria_code varchar(50) NOT NULL,
	seq_no smallint NOT NULL DEFAULT 0,
	text varchar(100),
	table_name varchar(30),
	field_name varchar(30),
	combo varchar(40),
	column_name varchar(30),
	concat char(1),
	type varchar(30),
	format varchar(50),
	operator varchar(50),
	default_data varchar(250)
) ;
ALTER TABLE sc_com_m_file_sys_criteria ADD PRIMARY KEY (criteria_code,seq_no);
ALTER TABLE sc_com_m_file_sys_criteria ALTER COLUMN criteria_code SET NOT NULL;
ALTER TABLE sc_com_m_file_sys_criteria ALTER COLUMN seq_no SET NOT NULL;


