CREATE TABLE sc_sch_history_graduate (
	application_form_no varchar(15) NOT NULL,
	seq_no decimal(15,2),
	end_primary_year decimal(15,2),
	end_primary_school varchar(50),
	end_prim_province_code varchar(6),
	primary_marks decimal(15,2),
	end_secondary_year decimal(15,2),
	end_secondary_school varchar(100),
	end_second_province_code varchar(6),
	secondary_marks decimal(15,2),
	reward_year decimal(15,2),
	reward_class varchar(100),
	reward_marks decimal(15,2),
	reward_province_code varchar(6),
	department varchar(100),
	grade_class varchar(18)
) ;
ALTER TABLE sc_sch_history_graduate ADD PRIMARY KEY (application_form_no);


