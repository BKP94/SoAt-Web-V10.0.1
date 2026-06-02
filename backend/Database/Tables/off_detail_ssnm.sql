CREATE TABLE off_detail_ssnm (
	no_coop char(10),
	pre_coop char(20),
	name_coop char(50),
	surname_coop char(50),
	no_ssnm char(10) NOT NULL,
	pre_ssnm char(20),
	name_ssnm char(50),
	surname_ssnm char(50),
	group_no char(15),
	group_name char(100)
) ;
ALTER TABLE off_detail_ssnm ADD PRIMARY KEY (no_ssnm);


