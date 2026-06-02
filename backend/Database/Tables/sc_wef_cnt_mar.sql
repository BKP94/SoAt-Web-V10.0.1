CREATE TABLE sc_wef_cnt_mar (
	coop_no varchar(20) NOT NULL,
	paid_within_day bigint NOT NULL DEFAULT 0,
	paid_rate decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_wef_cnt_mar ADD PRIMARY KEY (coop_no);
ALTER TABLE sc_wef_cnt_mar ALTER COLUMN coop_no SET NOT NULL;
ALTER TABLE sc_wef_cnt_mar ALTER COLUMN paid_within_day SET NOT NULL;


