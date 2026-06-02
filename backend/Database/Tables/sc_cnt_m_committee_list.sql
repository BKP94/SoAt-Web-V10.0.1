CREATE TABLE sc_cnt_m_committee_list (
	year_doom double precision NOT NULL DEFAULT 0,
	seq_no double precision NOT NULL DEFAULT 0,
	cmt_fullname varchar(100),
	cmt_group varchar(3),
	membership_no varchar(15),
	cmt_status char(1) DEFAULT '0',
	sort_order double precision DEFAULT 0,
	region_group varchar(15)
) ;
ALTER TABLE sc_cnt_m_committee_list ADD PRIMARY KEY (year_doom,seq_no);
ALTER TABLE sc_cnt_m_committee_list ALTER COLUMN year_doom SET NOT NULL;
ALTER TABLE sc_cnt_m_committee_list ALTER COLUMN seq_no SET NOT NULL;


