CREATE TABLE sc_mem_m_insure_rule (
	insurance_type varchar(5) NOT NULL,
	insurance_desc varchar(50),
	active_status char(1) DEFAULT '0',
	monthly_keep char(1) DEFAULT '0',
	yearly_keep char(1) DEFAULT '0',
	max_age double precision DEFAULT 0,
	prefix_type varchar(5),
	alert_status char(1) DEFAULT '0',
	account_id varchar(8),
	per_contract decimal(15,2),
	account_from varchar(8),
	insure_status char(1),
	law_status char(1),
	sort_order integer,
	loan_type varchar(6),
	protec_begin timestamp,
	protec_end timestamp,
	insure_loan char(1) DEFAULT '0',
	max_krom integer DEFAULT 0,
	cost_per_krom decimal(15,2) DEFAULT 0,
	div_keep char(1) DEFAULT '0',
	insure_year numeric(38) DEFAULT 0,
	spp_status char(1) DEFAULT '1',
	cal_loan char(1) DEFAULT (0),
	insurance_period_amount decimal(15,2) DEFAULT (0),
	insurance_period double precision DEFAULT (0),
	insurance_group varchar(2),
	account_id_wait varchar(8),
	account_id_tod varchar(8),
	account_id_adv varchar(8),
	insurance_group_desc varchar(100)
) ;
ALTER TABLE sc_mem_m_insure_rule ADD PRIMARY KEY (insurance_type);
ALTER TABLE sc_mem_m_insure_rule ALTER COLUMN insurance_type SET NOT NULL;


