CREATE TABLE sc_hr_off_member_aid (
	official_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	operate_date timestamp,
	aid_type varchar(6) DEFAULT '00',
	aid_amount decimal(15,2) DEFAULT 0,
	cancel_status char(1) DEFAULT '0',
	post_status char(1) DEFAULT '0',
	post_date timestamp,
	post_id varchar(16),
	entry_id varchar(16),
	entry_date timestamp,
	entry_br varchar(6),
	entry_pc varchar(6),
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_br varchar(6),
	vourcher_no varchar(15),
	cancel_vourcher_no varchar(15)
) ;
ALTER TABLE sc_hr_off_member_aid ADD PRIMARY KEY (official_no,seq_no);
ALTER TABLE sc_hr_off_member_aid ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_member_aid ALTER COLUMN seq_no SET NOT NULL;


