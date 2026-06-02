CREATE TABLE sc_lon_property_setpower (
	loan_requestment_no varchar(15) NOT NULL,
	coll_ref varchar(50) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	power_id varchar(16),
	power_position varchar(100)
) ;
ALTER TABLE sc_lon_property_setpower ADD PRIMARY KEY (loan_requestment_no,coll_ref,seq_no);


