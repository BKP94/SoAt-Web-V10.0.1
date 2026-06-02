CREATE TABLE sc_com_holiday_date (
	accountyear double precision NOT NULL DEFAULT 0,
	holidaydate timestamp NOT NULL
) ;
COMMENT ON TABLE sc_com_holiday_date IS E'!NN!';
ALTER TABLE sc_com_holiday_date ADD PRIMARY KEY (accountyear,holidaydate);


