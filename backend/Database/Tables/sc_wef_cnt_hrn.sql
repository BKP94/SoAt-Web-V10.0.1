CREATE TABLE sc_wef_cnt_hrn (
	coop_no double precision NOT NULL,
	within_day double precision
) ;
ALTER TABLE sc_wef_cnt_hrn ADD PRIMARY KEY (coop_no);
ALTER TABLE sc_wef_cnt_hrn ALTER COLUMN coop_no SET NOT NULL;


