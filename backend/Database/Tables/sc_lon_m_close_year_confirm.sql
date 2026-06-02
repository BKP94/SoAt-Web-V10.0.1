CREATE TABLE sc_lon_m_close_year_confirm (
	lon_year double precision NOT NULL DEFAULT 0,
	member_group_no varchar(15) NOT NULL,
	confirm_status char(1) DEFAULT '0',
	confirm_id varchar(15),
	confirm_time timestamp
) ;
ALTER TABLE sc_lon_m_close_year_confirm ADD PRIMARY KEY (lon_year,member_group_no);
ALTER TABLE sc_lon_m_close_year_confirm ALTER COLUMN lon_year SET NOT NULL;
ALTER TABLE sc_lon_m_close_year_confirm ALTER COLUMN member_group_no SET NOT NULL;


