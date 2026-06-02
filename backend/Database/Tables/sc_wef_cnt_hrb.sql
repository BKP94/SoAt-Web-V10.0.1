CREATE TABLE sc_wef_cnt_hrb (
	coop_no double precision NOT NULL,
	within_day double precision
) ;
ALTER TABLE sc_wef_cnt_hrb ADD PRIMARY KEY (coop_no);
ALTER TABLE sc_wef_cnt_hrb ALTER COLUMN coop_no SET NOT NULL;


