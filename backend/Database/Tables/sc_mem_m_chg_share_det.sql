CREATE TABLE sc_mem_m_chg_share_det (
	membership_no varchar(15) NOT NULL,
	document_no varchar(15) NOT NULL,
	shr_qty_old decimal(15,2),
	shr_value_old decimal(15,2),
	shr_qty_new decimal(15,2),
	shr_value_new decimal(15,2),
	period double precision,
	drop_status char(1),
	effactive_date timestamp,
	remark varchar(100),
	period_compomise double precision,
	drop_status_last char(1),
	approve_status char(1),
	keep_from_deposit char(1) DEFAULT '0',
	deposit_account_no varchar(15),
	amount_from_deposit decimal(15,2) DEFAULT 0,
	last_keep_from_deposit char(1) DEFAULT '0',
	last_deposit_account_no varchar(15),
	last_amount_from_deposit decimal(15,2) DEFAULT 0,
	effactive_status char(1) DEFAULT '0',
	old_effactive_status char(1) DEFAULT '0',
	old_effactive_date timestamp,
	old_period_compomise double precision DEFAULT 0,
	old_period double precision DEFAULT 0,
	effactive_end timestamp,
	old_effactive_end timestamp
) ;
COMMENT ON TABLE sc_mem_m_chg_share_det IS E'!NN!';
CREATE INDEX idx_chg_share ON sc_mem_m_chg_share_det (membership_no);
ALTER TABLE sc_mem_m_chg_share_det ADD PRIMARY KEY (membership_no,document_no);


