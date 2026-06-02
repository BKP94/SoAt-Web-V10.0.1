CREATE TABLE sc_wef_cnt_hrd (
	coop_no double precision NOT NULL,
	within_day double precision
) ;
ALTER TABLE sc_wef_cnt_hrd ADD PRIMARY KEY (coop_no);
ALTER TABLE sc_wef_cnt_hrd ALTER COLUMN coop_no SET NOT NULL;


