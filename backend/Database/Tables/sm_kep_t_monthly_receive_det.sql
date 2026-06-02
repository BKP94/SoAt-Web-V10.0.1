CREATE TABLE sm_kep_t_monthly_receive_det (
	receive_year double precision NOT NULL DEFAULT 0,
	receive_month double precision NOT NULL DEFAULT 0,
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	receive_seq double precision NOT NULL DEFAULT 0,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_kep_t_monthly_receive_det ADD PRIMARY KEY (receive_year,receive_month,membership_no,seq_no,receive_seq,sm_seq);
ALTER TABLE sm_kep_t_monthly_receive_det ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_kep_t_monthly_receive_det ALTER COLUMN receive_year SET NOT NULL;
ALTER TABLE sm_kep_t_monthly_receive_det ALTER COLUMN receive_month SET NOT NULL;
ALTER TABLE sm_kep_t_monthly_receive_det ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sm_kep_t_monthly_receive_det ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sm_kep_t_monthly_receive_det ALTER COLUMN receive_seq SET NOT NULL;


