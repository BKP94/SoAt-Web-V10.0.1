CREATE TABLE sc_cnt_m_month (
	month_no double precision NOT NULL,
	month_name_thai varchar(30),
	month_name_eng varchar(30),
	shot_month_thai varchar(5),
	shot_month_eng varchar(5)
) ;
COMMENT ON TABLE sc_cnt_m_month IS E'!NN!';
ALTER TABLE sc_cnt_m_month ADD PRIMARY KEY (month_no);


