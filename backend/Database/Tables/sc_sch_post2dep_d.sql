CREATE TABLE sc_sch_post2dep_d (
	doc_no varchar(10) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	requestment_no varchar(15) NOT NULL,
	sch_receive double precision DEFAULT 0,
	deposit_account_no varchar(15),
	post_result char(1) NOT NULL DEFAULT 'W',
	post_error varchar(100)
) ;
ALTER TABLE sc_sch_post2dep_d ADD PRIMARY KEY (doc_no,seq_no);
ALTER TABLE sc_sch_post2dep_d ALTER COLUMN doc_no SET NOT NULL;
ALTER TABLE sc_sch_post2dep_d ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_sch_post2dep_d ALTER COLUMN requestment_no SET NOT NULL;
ALTER TABLE sc_sch_post2dep_d ALTER COLUMN post_result SET NOT NULL;


