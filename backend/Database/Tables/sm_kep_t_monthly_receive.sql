CREATE TABLE sm_kep_t_monthly_receive (
	receive_year double precision NOT NULL DEFAULT 0,
	receive_month double precision NOT NULL DEFAULT 0,
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_kep_t_monthly_receive ADD PRIMARY KEY (receive_year,receive_month,membership_no,seq_no,sm_seq);
ALTER TABLE sm_kep_t_monthly_receive ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_kep_t_monthly_receive ALTER COLUMN receive_year SET NOT NULL;
ALTER TABLE sm_kep_t_monthly_receive ALTER COLUMN receive_month SET NOT NULL;
ALTER TABLE sm_kep_t_monthly_receive ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sm_kep_t_monthly_receive ALTER COLUMN seq_no SET NOT NULL;


