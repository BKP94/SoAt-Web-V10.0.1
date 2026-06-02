CREATE TABLE sc_sch_post2dep_h (
	doc_no varchar(10) NOT NULL,
	operate_date timestamp,
	entry_id varchar(16),
	entry_date timestamp,
	entry_br varchar(6),
	cancel_status char(1) NOT NULL DEFAULT '0',
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_br varchar(6),
	post_status char(1) NOT NULL DEFAULT '0',
	post_id varchar(16),
	post_date timestamp,
	post_br varchar(6)
) ;
ALTER TABLE sc_sch_post2dep_h ADD PRIMARY KEY (doc_no);
ALTER TABLE sc_sch_post2dep_h ALTER COLUMN doc_no SET NOT NULL;
ALTER TABLE sc_sch_post2dep_h ALTER COLUMN cancel_status SET NOT NULL;
ALTER TABLE sc_sch_post2dep_h ALTER COLUMN post_status SET NOT NULL;


