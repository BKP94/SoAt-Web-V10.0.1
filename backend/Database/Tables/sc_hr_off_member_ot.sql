CREATE TABLE sc_hr_off_member_ot (
	official_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	time_begin timestamp,
	time_end timestamp,
	ot_amount decimal(15,2) DEFAULT 0,
	cancel_status char(1) DEFAULT '0',
	post_status char(1) DEFAULT '0',
	post_date timestamp,
	post_id varchar(16),
	entry_id varchar(16),
	entry_date timestamp,
	entry_branch varchar(6),
	entry_clientid varchar(30),
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_branch varchar(6),
	vourcher_no varchar(15),
	tax_amount decimal(15,2) DEFAULT 0,
	money_type_id varchar(6),
	bank_acc_no varchar(15),
	deposit_account_no varchar(15),
	cancel_vourcher_no char(15)
) ;
ALTER TABLE sc_hr_off_member_ot ADD PRIMARY KEY (official_no,seq_no);
ALTER TABLE sc_hr_off_member_ot ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_member_ot ALTER COLUMN seq_no SET NOT NULL;


