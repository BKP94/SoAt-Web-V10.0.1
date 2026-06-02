CREATE TABLE sc_mobile_regis (
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	bank_id varchar(6) NOT NULL,
	mobile_number varchar(15) NOT NULL,
	close_status char(1) NOT NULL DEFAULT '0',
	mobile_lon char(1) NOT NULL DEFAULT 'N',
	mobile_dep char(1) NOT NULL DEFAULT 'N',
	mobile_trans char(1) NOT NULL DEFAULT 'N',
	entry_id varchar(16) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_br varchar(6) NOT NULL,
	bank_acc_no varchar(200),
	mobile_dep_spec char(1) DEFAULT 'N',
	mobile_active char(1) DEFAULT (0),
	max_tran_day decimal(15,2) DEFAULT 0,
	max_withdraw_day decimal(15,2) DEFAULT 0,
	max_deposit_day decimal(15,2) DEFAULT 0,
	max_addloan_day decimal(15,2) DEFAULT 0,
	max_payment_day decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_mobile_regis ADD PRIMARY KEY (membership_no,seq_no,bank_id);
ALTER TABLE sc_mobile_regis ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mobile_regis ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_mobile_regis ALTER COLUMN bank_id SET NOT NULL;
ALTER TABLE sc_mobile_regis ALTER COLUMN mobile_number SET NOT NULL;
ALTER TABLE sc_mobile_regis ALTER COLUMN close_status SET NOT NULL;
ALTER TABLE sc_mobile_regis ALTER COLUMN mobile_lon SET NOT NULL;
ALTER TABLE sc_mobile_regis ALTER COLUMN mobile_dep SET NOT NULL;
ALTER TABLE sc_mobile_regis ALTER COLUMN mobile_trans SET NOT NULL;
ALTER TABLE sc_mobile_regis ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_mobile_regis ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_mobile_regis ALTER COLUMN entry_br SET NOT NULL;


