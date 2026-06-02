CREATE TABLE sc_wef_cnt_edu (
	coop_no varchar(20) NOT NULL,
	within_days double precision DEFAULT 0,
	mem_date timestamp
) ;
ALTER TABLE sc_wef_cnt_edu ADD PRIMARY KEY (coop_no);
ALTER TABLE sc_wef_cnt_edu ALTER COLUMN coop_no SET NOT NULL;


