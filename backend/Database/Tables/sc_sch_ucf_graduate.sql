CREATE TABLE sc_sch_ucf_graduate (
	graduate_type varchar(6) NOT NULL,
	graduate_name varchar(50),
	graduate_amount decimal(15,2),
	max_age_receive numeric(38) DEFAULT (0)
) ;
ALTER TABLE sc_sch_ucf_graduate ADD PRIMARY KEY (graduate_type);


