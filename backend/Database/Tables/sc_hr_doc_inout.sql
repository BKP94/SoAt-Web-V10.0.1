CREATE TABLE sc_hr_doc_inout (
	doc_no varchar(15) NOT NULL,
	inout_status char(1) NOT NULL DEFAULT '0',
	operate_date timestamp,
	trans_type char(1) DEFAULT '0',
	doc_status varchar(8),
	from_who varchar(250),
	from_department varchar(6),
	sentto_who varchar(250),
	doc_headline varchar(250),
	doc_signature varchar(100),
	doc_remark varchar(250),
	keep_placement varchar(6),
	entry_id varchar(16),
	entry_date timestamp,
	entry_branch varchar(6),
	entry_clientid varchar(30),
	last_modify_id varchar(16),
	last_modify_date timestamp,
	cancel_status char(1) DEFAULT '0',
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_branch varchar(6),
	doc_date timestamp,
	doc_headcode varchar(8),
	member_fr varchar(7),
	memgroup_fr varchar(15),
	memgroup_to varchar(15),
	cancel_pc varchar(6),
	express_status char(1) DEFAULT '0',
	doc_detailline varchar(250),
	to_department varchar(6),
	member_to varchar(7),
	finish_status char(1) DEFAULT '0',
	filename varchar(150)
) ;
ALTER TABLE sc_hr_doc_inout ADD PRIMARY KEY (doc_no,inout_status);
ALTER TABLE sc_hr_doc_inout ALTER COLUMN doc_no SET NOT NULL;
ALTER TABLE sc_hr_doc_inout ALTER COLUMN inout_status SET NOT NULL;


