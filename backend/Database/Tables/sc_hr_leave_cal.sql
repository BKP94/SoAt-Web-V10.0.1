CREATE TABLE sc_hr_leave_cal (
	year integer NOT NULL DEFAULT 0,
	official_no varchar(15) NOT NULL,
	last_year_leave decimal(15,2),
	bring_forward_leave decimal(15,2),
	total_leave decimal(15,2),
	last_year_leave_day decimal(15,2)
) ;
ALTER TABLE sc_hr_leave_cal ADD PRIMARY KEY (year,official_no);
ALTER TABLE sc_hr_leave_cal ALTER COLUMN year SET NOT NULL;
ALTER TABLE sc_hr_leave_cal ALTER COLUMN official_no SET NOT NULL;


