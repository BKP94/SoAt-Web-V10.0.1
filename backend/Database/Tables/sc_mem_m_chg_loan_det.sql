CREATE TABLE sc_mem_m_chg_loan_det (
	membership_no varchar(15) NOT NULL,
	document_no varchar(15) NOT NULL,
	loan_contract varchar(15) NOT NULL,
	pricipal decimal(15,2),
	balance decimal(15,2),
	period_old decimal(15,2),
	period_payment_old decimal(15,2),
	period_payment_new decimal(15,2),
	period_compomise double precision,
	effactive_date timestamp,
	remark varchar(100),
	drop_status char(1),
	code_put varchar(6),
	code_put_old varchar(6),
	arr_int decimal(15,2),
	fixed_prin decimal(15,2),
	fixed_int_rate decimal(15,4),
	fixed_int_rateold decimal(15,4),
	fixed_prin_old decimal(15,2),
	new_count char(1),
	installment_old double precision,
	fixed_arr_int decimal(15,2),
	type_request char(1),
	drop_status_last char(1),
	cumalative_copomise double precision,
	drop_stauts double precision DEFAULT 0,
	old_period_compomise double precision DEFAULT 0,
	installment_new double precision DEFAULT 0,
	keep_method_change char(1),
	effactive_end timestamp,
	effactive_status char(1),
	old_effactive_status char(1),
	old_effactive_date timestamp,
	old_effactive_end timestamp
) ;
COMMENT ON TABLE sc_mem_m_chg_loan_det IS E'!NN!';
COMMENT ON COLUMN sc_mem_m_chg_loan_det.drop_status IS E'!N?????N!!M!V0-????????,1-?????????,2-?????,3-?????,4-??????????V!M!';
CREATE INDEX idx_chg_loan001 ON sc_mem_m_chg_loan_det (membership_no);
ALTER TABLE sc_mem_m_chg_loan_det ADD PRIMARY KEY (membership_no,document_no,loan_contract);


