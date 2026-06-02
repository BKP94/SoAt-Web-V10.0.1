CREATE TABLE sc_mem_m_ucf_app_validlock (
	valid_code varchar(6) NOT NULL,
	table_name varchar(30),
	col_name varchar(30),
	message_alert varchar(250)
) ;
COMMENT ON TABLE sc_mem_m_ucf_app_validlock IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_ucf_app_validlock.col_name IS E'!N???? ColumnN!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_app_validlock.message_alert IS E'!N???????????????N!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_app_validlock.table_name IS E'!N???? TableN!!MM!';
COMMENT ON COLUMN sc_mem_m_ucf_app_validlock.valid_code IS E'!N????N!!MM!';
ALTER TABLE sc_mem_m_ucf_app_validlock ADD PRIMARY KEY (valid_code);


