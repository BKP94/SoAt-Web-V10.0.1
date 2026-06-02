CREATE TABLE sc_dep_t_depslip_fixitem (
	deposit_account_no varchar(15),
	deposit_slip_no varchar(15) NOT NULL,
	ref_seq_no numeric(38) NOT NULL,
	fixed_amount decimal(15,2),
	prinpal_amount decimal(15,2),
	intpaid decimal(15,2) DEFAULT 0,
	taxpaid decimal(15,2) DEFAULT 0,
	intrecall decimal(15,2) DEFAULT 0,
	realpaid decimal(15,2) DEFAULT 0,
	date_dep timestamp,
	date_due timestamp,
	month_int decimal(15,2) DEFAULT 0.00,
	month_dued timestamp
) ;
ALTER TABLE sc_dep_t_depslip_fixitem ADD PRIMARY KEY (deposit_slip_no,ref_seq_no);


