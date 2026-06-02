CREATE TABLE sc_wef_cnt_snr (
	coop_no varchar(20) NOT NULL,
	within_days double precision DEFAULT '0'
) ;
ALTER TABLE sc_wef_cnt_snr ADD PRIMARY KEY (coop_no);
ALTER TABLE sc_wef_cnt_snr ALTER COLUMN coop_no SET NOT NULL;


