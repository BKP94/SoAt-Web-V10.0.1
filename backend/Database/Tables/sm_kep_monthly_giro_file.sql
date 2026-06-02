CREATE TABLE sm_kep_monthly_giro_file (
	receive_year double precision NOT NULL,
	receive_month double precision NOT NULL,
	seq_no double precision NOT NULL,
	membership_no varchar(15) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
CREATE UNIQUE INDEX sys_c0040083 ON sm_kep_monthly_giro_file (receive_year, receive_month, seq_no, membership_no);
ALTER TABLE sm_kep_monthly_giro_file ADD PRIMARY KEY (receive_year,receive_month,seq_no,membership_no,sm_seq);
ALTER TABLE sm_kep_monthly_giro_file ALTER COLUMN sm_seq SET NOT NULL;


