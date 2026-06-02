CREATE TABLE sc_wef_cnt_hbd (
	coop_no varchar(20) NOT NULL,
	within_days double precision NOT NULL DEFAULT 0
) ;
ALTER TABLE sc_wef_cnt_hbd ADD PRIMARY KEY (coop_no);
ALTER TABLE sc_wef_cnt_hbd ALTER COLUMN coop_no SET NOT NULL;
ALTER TABLE sc_wef_cnt_hbd ALTER COLUMN within_days SET NOT NULL;


