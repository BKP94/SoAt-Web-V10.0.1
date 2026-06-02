CREATE TABLE sc_mem_edit_memo (
	membership_no varchar(15) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	operate_date timestamp NOT NULL,
	pre_memo_detail varchar(2500),
	pre_drop_emer char(1) DEFAULT '0',
	pre_drop_norm char(1) DEFAULT '0',
	pre_drop_spec char(1) DEFAULT '0',
	pre_drop_coll char(1) DEFAULT '0',
	pre_lon_restruc char(1) DEFAULT '0',
	memo_detail varchar(2500),
	drop_emer char(1) DEFAULT '0',
	drop_norm char(1) DEFAULT '0',
	drop_spec char(1) DEFAULT '0',
	drop_coll char(1) DEFAULT '0',
	lon_restruc char(1) DEFAULT '0'
) ;
ALTER TABLE sc_mem_edit_memo ADD PRIMARY KEY (membership_no,entry_date);
ALTER TABLE sc_mem_edit_memo ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_edit_memo ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_mem_edit_memo ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_mem_edit_memo ALTER COLUMN operate_date SET NOT NULL;


