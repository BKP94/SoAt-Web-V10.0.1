CREATE TABLE sc_hr_off_member_education (
	official_no varchar(3) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	edu_code varchar(2),
	edu_place varchar(200),
	edu_class varchar(200),
	edu_major varchar(200),
	edu_year_begin double precision DEFAULT 0,
	edu_year_end double precision DEFAULT 0,
	edu_inwork char(1)
) ;
ALTER TABLE sc_hr_off_member_education ADD PRIMARY KEY (official_no,seq_no);


