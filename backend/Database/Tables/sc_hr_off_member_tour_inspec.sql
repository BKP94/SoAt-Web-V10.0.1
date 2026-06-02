CREATE TABLE sc_hr_off_member_tour_inspec (
	official_no varchar(5) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	tour_name varchar(100),
	tour_desc varchar(500),
	tour_place varchar(100),
	begin_date timestamp,
	end_date timestamp,
	tour_year double precision DEFAULT 0,
	tour_time varchar(50)
) ;
ALTER TABLE sc_hr_off_member_tour_inspec ADD PRIMARY KEY (official_no,seq_no);


