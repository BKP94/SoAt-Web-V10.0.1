CREATE TABLE sc_crm_constant (
	cremation_cons_no varchar(15) NOT NULL,
	dead_perunit decimal(15,2) DEFAULT 0,
	dead_limit numeric(38) DEFAULT 0,
	money_stock decimal(15,2) DEFAULT 0,
	money_maintain decimal(15,2) DEFAULT 0,
	operate_date timestamp,
	adv_payment decimal(15,2) DEFAULT 0,
	fee_percent decimal(15,2) DEFAULT 0,
	money_new decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_crm_constant ADD PRIMARY KEY (cremation_cons_no);


