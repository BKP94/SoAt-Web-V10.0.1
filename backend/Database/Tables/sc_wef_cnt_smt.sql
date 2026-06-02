CREATE TABLE sc_wef_cnt_smt (
	coop_no varchar(20) NOT NULL,
	within_days double precision DEFAULT '0'
) ;
ALTER TABLE sc_wef_cnt_smt ADD PRIMARY KEY (coop_no);
ALTER TABLE sc_wef_cnt_smt ALTER COLUMN coop_no SET NOT NULL;


