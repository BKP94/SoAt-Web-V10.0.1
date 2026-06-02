CREATE TABLE sc_acc_m_expire_estimate_month (
	meterial_id varchar(10) NOT NULL,
	begin_date timestamp NOT NULL,
	end_date timestamp NOT NULL,
	day_num double precision NOT NULL DEFAULT 0,
	day_in_year double precision NOT NULL DEFAULT 0,
	rate_expire decimal(6,4) DEFAULT 0,
	amount_value decimal(15,2) DEFAULT 0,
	expire_accu decimal(15,2) DEFAULT 0,
	expire_amount decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_acc_m_expire_estimate_month ADD PRIMARY KEY (meterial_id,begin_date);
ALTER TABLE sc_acc_m_expire_estimate_month ALTER COLUMN meterial_id SET NOT NULL;
ALTER TABLE sc_acc_m_expire_estimate_month ALTER COLUMN begin_date SET NOT NULL;
ALTER TABLE sc_acc_m_expire_estimate_month ALTER COLUMN end_date SET NOT NULL;
ALTER TABLE sc_acc_m_expire_estimate_month ALTER COLUMN day_num SET NOT NULL;
ALTER TABLE sc_acc_m_expire_estimate_month ALTER COLUMN day_in_year SET NOT NULL;


