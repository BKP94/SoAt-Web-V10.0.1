CREATE TABLE sc_kep_t_monthly_lookup (
	membership_no varchar(15) NOT NULL,
	receive_year double precision NOT NULL,
	receive_month double precision NOT NULL,
	seq_no double precision NOT NULL,
	receipt_date timestamp NOT NULL,
	send_amount decimal(15,2) DEFAULT 0,
	entry_id varchar(16) NOT NULL,
	entry_date timestamp NOT NULL,
	unkeep_amount decimal(15,2) DEFAULT 0,
	unkeep_id varchar(16),
	unkeep_date timestamp,
	agent_no varchar(15) NOT NULL,
	member_group_no varchar(15) NOT NULL,
	prename varchar(50) NOT NULL,
	member_name varchar(50) NOT NULL,
	member_surname varchar(50) NOT NULL,
	id_card varchar(15),
	bank_id varchar(6),
	bank_acc_no varchar(15)
) ;
ALTER TABLE sc_kep_t_monthly_lookup ADD PRIMARY KEY (membership_no);
ALTER TABLE sc_kep_t_monthly_lookup ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_lookup ALTER COLUMN receive_year SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_lookup ALTER COLUMN receive_month SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_lookup ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_lookup ALTER COLUMN receipt_date SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_lookup ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_lookup ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_lookup ALTER COLUMN agent_no SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_lookup ALTER COLUMN member_group_no SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_lookup ALTER COLUMN prename SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_lookup ALTER COLUMN member_name SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_lookup ALTER COLUMN member_surname SET NOT NULL;


