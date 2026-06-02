CREATE TABLE sc_doc_regis (
	regis_no varchar(10) NOT NULL,
	regis_type varchar(2),
	membership_no varchar(15),
	member_group_no varchar(15),
	regis_date timestamp,
	regis_id varchar(15),
	regis_status varchar(2),
	entry_date timestamp,
	entry_id varchar(15),
	remark varchar(100),
	request_amount decimal(15,2),
	check_date timestamp,
	check_id varchar(16)
) ;
ALTER TABLE sc_doc_regis ADD PRIMARY KEY (regis_no);


