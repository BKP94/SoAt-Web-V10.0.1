CREATE TABLE sc_adsync_ucf_enable (
	seq_no double precision NOT NULL,
	ads_code varchar(10) NOT NULL,
	ads_desc varchar(50) NOT NULL
) ;
ALTER TABLE sc_adsync_ucf_enable ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_adsync_ucf_enable ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_adsync_ucf_enable ALTER COLUMN ads_code SET NOT NULL;
ALTER TABLE sc_adsync_ucf_enable ALTER COLUMN ads_desc SET NOT NULL;


