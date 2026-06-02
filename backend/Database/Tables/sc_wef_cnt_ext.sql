CREATE TABLE sc_wef_cnt_ext (
	coop_no varchar(20) NOT NULL,
	within_days double precision DEFAULT '0',
	min_heal double precision
) ;
ALTER TABLE sc_wef_cnt_ext ADD PRIMARY KEY (coop_no);
ALTER TABLE sc_wef_cnt_ext ALTER COLUMN coop_no SET NOT NULL;


