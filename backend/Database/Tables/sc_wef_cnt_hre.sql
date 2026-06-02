CREATE TABLE sc_wef_cnt_hre (
	coop_no varchar(20) NOT NULL,
	within_days double precision NOT NULL DEFAULT 0,
	max_amount decimal(15,2) DEFAULT '0'
) ;
ALTER TABLE sc_wef_cnt_hre ADD PRIMARY KEY (coop_no);
ALTER TABLE sc_wef_cnt_hre ALTER COLUMN coop_no SET NOT NULL;
ALTER TABLE sc_wef_cnt_hre ALTER COLUMN within_days SET NOT NULL;


