CREATE TABLE sc_wef_cnt_bon (
	coop_no varchar(20) NOT NULL,
	within_days double precision DEFAULT 0,
	count_limit double precision DEFAULT 0
) ;
ALTER TABLE sc_wef_cnt_bon ADD PRIMARY KEY (coop_no);
ALTER TABLE sc_wef_cnt_bon ALTER COLUMN coop_no SET NOT NULL;


