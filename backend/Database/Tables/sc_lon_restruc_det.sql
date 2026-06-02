CREATE TABLE sc_lon_restruc_det (
	document_no varchar(15) NOT NULL,
	membership_no varchar(15) NOT NULL,
	loan_contract_no varchar(15) NOT NULL,
	sort_payment integer,
	last_period decimal(15,2),
	balance decimal(15,2),
	int_arrear decimal(15,2),
	drop_status_old char(1),
	installment_old double precision,
	paytype_code_old varchar(6),
	payment_amount_old decimal(15,2),
	fixed_payment_old decimal(15,2),
	fixed_int_rate_old decimal(15,4),
	restruc_status char(1) DEFAULT '0',
	fixed_payment_new decimal(15,2),
	fixed_int_rate_new decimal(15,4),
	installment_new double precision DEFAULT 0
) ;
ALTER TABLE sc_lon_restruc_det ADD PRIMARY KEY (document_no,membership_no,loan_contract_no);
ALTER TABLE sc_lon_restruc_det ALTER COLUMN document_no SET NOT NULL;
ALTER TABLE sc_lon_restruc_det ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_lon_restruc_det ALTER COLUMN loan_contract_no SET NOT NULL;


