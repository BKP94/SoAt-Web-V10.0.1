CREATE TABLE sc_kep_monthly_giro_file (
	receive_year double precision NOT NULL DEFAULT 0,
	receive_month double precision NOT NULL DEFAULT 0,
	seq_no double precision NOT NULL DEFAULT 0,
	membership_no varchar(15),
	user_id varchar(15),
	money_amount decimal(15,2) DEFAULT 0,
	paid_amount decimal(15,2) DEFAULT 0,
	giro_amount decimal(15,2) DEFAULT 0,
	balance decimal(15,2) DEFAULT 0,
	receipt_status varchar(50) DEFAULT '0'
) ;
CREATE UNIQUE INDEX sys_c0040082 ON sc_kep_monthly_giro_file (receive_year, receive_month, seq_no, membership_no);
ALTER TABLE sc_kep_monthly_giro_file ALTER COLUMN receive_year SET NOT NULL;
ALTER TABLE sc_kep_monthly_giro_file ALTER COLUMN receive_month SET NOT NULL;
ALTER TABLE sc_kep_monthly_giro_file ALTER COLUMN seq_no SET NOT NULL;


