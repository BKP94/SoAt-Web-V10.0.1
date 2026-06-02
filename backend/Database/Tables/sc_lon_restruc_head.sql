CREATE TABLE sc_lon_restruc_head (
	document_no varchar(15) NOT NULL,
	membership_no varchar(15) NOT NULL,
	member_group_no varchar(15) NOT NULL,
	operate_date timestamp,
	effect_date timestamp,
	reason_code varchar(6),
	remark varchar(100),
	salary_amount decimal(15,2) DEFAULT 0,
	entry_id varchar(16),
	entry_date timestamp,
	entry_br varchar(6),
	approve_status char(1),
	approve_id varchar(16),
	approve_date timestamp,
	cancel_status char(1) DEFAULT '0',
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_br varchar(6)
) ;
ALTER TABLE sc_lon_restruc_head ADD PRIMARY KEY (document_no);
ALTER TABLE sc_lon_restruc_head ALTER COLUMN document_no SET NOT NULL;
ALTER TABLE sc_lon_restruc_head ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_lon_restruc_head ALTER COLUMN member_group_no SET NOT NULL;


