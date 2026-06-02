CREATE TABLE sc_sch_constant (
	school_year decimal(15,2),
	school_budget decimal(15,2),
	status_child char(1),
	coop_no varchar(15) NOT NULL,
	average_grade decimal(15,2) DEFAULT 0,
	percent decimal(15,4) DEFAULT 0,
	year_notreceive double precision DEFAULT 0,
	child_age_limit double precision DEFAULT 0
) ;
ALTER TABLE sc_sch_constant ADD PRIMARY KEY (coop_no);
ALTER TABLE sc_sch_constant ALTER COLUMN coop_no SET NOT NULL;


