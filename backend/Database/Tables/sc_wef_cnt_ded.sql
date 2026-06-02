CREATE TABLE sc_wef_cnt_ded (
	coop_no varchar(20) NOT NULL,
	within_days double precision NOT NULL DEFAULT 0
) ;
ALTER TABLE sc_wef_cnt_ded ADD PRIMARY KEY (coop_no);
ALTER TABLE sc_wef_cnt_ded ALTER COLUMN coop_no SET NOT NULL;
ALTER TABLE sc_wef_cnt_ded ALTER COLUMN within_days SET NOT NULL;


