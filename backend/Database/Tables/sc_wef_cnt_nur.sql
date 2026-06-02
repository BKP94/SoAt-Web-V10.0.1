CREATE TABLE sc_wef_cnt_nur (
	coop_no varchar(20) NOT NULL,
	within_day double precision
) ;
ALTER TABLE sc_wef_cnt_nur ADD PRIMARY KEY (coop_no);
ALTER TABLE sc_wef_cnt_nur ALTER COLUMN coop_no SET NOT NULL;


