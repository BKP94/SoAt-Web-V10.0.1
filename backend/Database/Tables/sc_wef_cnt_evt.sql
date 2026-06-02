CREATE TABLE sc_wef_cnt_evt (
	coop_no varchar(20) NOT NULL,
	within_days double precision NOT NULL DEFAULT 0
) ;
ALTER TABLE sc_wef_cnt_evt ADD PRIMARY KEY (coop_no);
ALTER TABLE sc_wef_cnt_evt ALTER COLUMN coop_no SET NOT NULL;
ALTER TABLE sc_wef_cnt_evt ALTER COLUMN within_days SET NOT NULL;


