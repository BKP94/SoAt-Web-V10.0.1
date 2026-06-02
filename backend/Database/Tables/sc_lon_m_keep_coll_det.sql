CREATE TABLE sc_lon_m_keep_coll_det (
	keep_coll_doc_no varchar(15) NOT NULL,
	ref_own_no varchar(15) NOT NULL,
	principal_keep decimal(15,2) DEFAULT 0.00,
	interest_keep decimal(15,2) DEFAULT 0.00,
	keeping_status char(1) DEFAULT '0',
	keep_year integer DEFAULT 0,
	keep_month integer DEFAULT 0,
	post_status char(1) DEFAULT '0',
	keep_group varchar(15),
	cancel_status char(1),
	cancel_id varchar(16),
	cancel_date timestamp,
	cancel_br varchar(6)
) ;
ALTER TABLE sc_lon_m_keep_coll_det ADD PRIMARY KEY (keep_coll_doc_no,ref_own_no);
ALTER TABLE sc_lon_m_keep_coll_det ALTER COLUMN keep_coll_doc_no SET NOT NULL;
ALTER TABLE sc_lon_m_keep_coll_det ALTER COLUMN ref_own_no SET NOT NULL;


