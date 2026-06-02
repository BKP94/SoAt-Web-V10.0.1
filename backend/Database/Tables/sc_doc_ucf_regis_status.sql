CREATE TABLE sc_doc_ucf_regis_status (
	regis_status varchar(2) NOT NULL,
	regis_status_des varchar(50),
	check_status char(1)
) ;
ALTER TABLE sc_doc_ucf_regis_status ADD PRIMARY KEY (regis_status);


