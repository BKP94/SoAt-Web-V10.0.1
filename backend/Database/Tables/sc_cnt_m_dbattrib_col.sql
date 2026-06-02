CREATE TABLE sc_cnt_m_dbattrib_col (
	tab_name varchar(30) NOT NULL,
	col_name varchar(30) NOT NULL,
	number_negativeable char(1),
	out_list_able char(1) DEFAULT '0'
) ;
COMMENT ON TABLE sc_cnt_m_dbattrib_col IS E'!N????????????????????????????N!';
COMMENT ON COLUMN sc_cnt_m_dbattrib_col.number_negativeable IS E'!N????????????????????N!';
CREATE INDEX idx_cnt_dbattcol ON sc_cnt_m_dbattrib_col (tab_name);
ALTER TABLE sc_cnt_m_dbattrib_col ADD PRIMARY KEY (tab_name,col_name);


