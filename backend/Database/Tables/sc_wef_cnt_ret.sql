CREATE TABLE sc_wef_cnt_ret (
	coop_no varchar(20) NOT NULL,
	within_days double precision DEFAULT '0',
	max_amount decimal(15,2)
) ;
ALTER TABLE sc_wef_cnt_ret ADD PRIMARY KEY (coop_no);
ALTER TABLE sc_wef_cnt_ret ALTER COLUMN coop_no SET NOT NULL;


