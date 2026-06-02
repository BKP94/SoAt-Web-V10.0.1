CREATE TABLE sm_kep_crem_web (
	membership_no varchar(15) NOT NULL,
	receive_year double precision NOT NULL,
	receive_month double precision NOT NULL,
	seq_no double precision NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_kep_crem_web ADD PRIMARY KEY (membership_no,receive_year,receive_month,seq_no,sm_seq);
ALTER TABLE sm_kep_crem_web ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_kep_crem_web ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sm_kep_crem_web ALTER COLUMN receive_year SET NOT NULL;
ALTER TABLE sm_kep_crem_web ALTER COLUMN receive_month SET NOT NULL;
ALTER TABLE sm_kep_crem_web ALTER COLUMN seq_no SET NOT NULL;


