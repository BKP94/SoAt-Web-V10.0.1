CREATE TABLE sc_sch_money_total (
	money_status double precision NOT NULL,
	amount double precision,
	money_def varchar(200)
) ;
ALTER TABLE sc_sch_money_total ADD PRIMARY KEY (money_status);


