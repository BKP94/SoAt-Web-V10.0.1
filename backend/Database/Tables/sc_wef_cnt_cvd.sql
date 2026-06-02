CREATE TABLE sc_wef_cnt_cvd (
	coop_no varchar(20) NOT NULL,
	within_days double precision DEFAULT '0'
) ;
ALTER TABLE sc_wef_cnt_cvd ADD PRIMARY KEY (coop_no);
ALTER TABLE sc_wef_cnt_cvd ALTER COLUMN coop_no SET NOT NULL;


