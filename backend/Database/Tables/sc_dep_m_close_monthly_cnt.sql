CREATE TABLE sc_dep_m_close_monthly_cnt (
	year double precision,
	month double precision,
	monthly_day_first timestamp,
	monthly_day_end timestamp,
	monthly_entry varchar(15),
	monthly_op timestamp,
	monthly_branch char(2),
	monthly_int_entry varchar(15),
	monthly_int_op timestamp,
	monthly_int_branch char(2),
	monthly_dep_entry varchar(15),
	monthly_dep_op timestamp,
	monthly_dep_branch char(2),
	yearly_int_entry varchar(15),
	yearly_int_op timestamp,
	yearly_int_branch char(2)
) ;


