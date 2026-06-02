CREATE TABLE sc_tmp_insure_ad (
	time_id varchar(16) NOT NULL,
	seq_no double precision NOT NULL,
	insurance_no varchar(15)
) ;
ALTER TABLE sc_tmp_insure_ad ADD PRIMARY KEY (time_id,seq_no);
ALTER TABLE sc_tmp_insure_ad ALTER COLUMN time_id SET NOT NULL;
ALTER TABLE sc_tmp_insure_ad ALTER COLUMN seq_no SET NOT NULL;


