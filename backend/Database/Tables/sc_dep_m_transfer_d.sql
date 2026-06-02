CREATE TABLE sc_dep_m_transfer_d (
	group_no varchar(10) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	deposit_account_no varchar(15) NOT NULL,
	item_amount double precision NOT NULL DEFAULT 0,
	ref_item_no varchar(30) NOT NULL,
	post_result char(1) NOT NULL DEFAULT '2',
	error_text varchar(100),
	post_seq double precision DEFAULT 0,
	ref_seq_no double precision DEFAULT 0
) ;
ALTER TABLE sc_dep_m_transfer_d ADD PRIMARY KEY (group_no,seq_no);
ALTER TABLE sc_dep_m_transfer_d ALTER COLUMN group_no SET NOT NULL;
ALTER TABLE sc_dep_m_transfer_d ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_dep_m_transfer_d ALTER COLUMN deposit_account_no SET NOT NULL;
ALTER TABLE sc_dep_m_transfer_d ALTER COLUMN item_amount SET NOT NULL;
ALTER TABLE sc_dep_m_transfer_d ALTER COLUMN ref_item_no SET NOT NULL;
ALTER TABLE sc_dep_m_transfer_d ALTER COLUMN post_result SET NOT NULL;


