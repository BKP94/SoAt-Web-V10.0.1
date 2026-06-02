CREATE TABLE sc_dep_m_transfer_h (
	group_no varchar(10) NOT NULL,
	operate_date timestamp,
	effect_date timestamp,
	item_type varchar(3),
	remark varchar(100),
	total_item double precision DEFAULT 0,
	total_amount double precision DEFAULT 0,
	entry_system varchar(6),
	entry_id varchar(16),
	entry_date timestamp NOT NULL,
	entry_br varchar(6),
	cancel_status char(1) NOT NULL DEFAULT '0',
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_br varchar(6),
	post_status char(1) NOT NULL DEFAULT '0',
	post_id varchar(16),
	post_date timestamp,
	post_br varchar(6),
	success_item double precision DEFAULT 0,
	success_amount double precision DEFAULT 0,
	failure_item double precision DEFAULT 0,
	failure_amount double precision DEFAULT 0
) ;
ALTER TABLE sc_dep_m_transfer_h ADD PRIMARY KEY (group_no);
ALTER TABLE sc_dep_m_transfer_h ALTER COLUMN group_no SET NOT NULL;
ALTER TABLE sc_dep_m_transfer_h ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_dep_m_transfer_h ALTER COLUMN cancel_status SET NOT NULL;
ALTER TABLE sc_dep_m_transfer_h ALTER COLUMN post_status SET NOT NULL;


