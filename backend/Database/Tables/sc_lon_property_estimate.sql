CREATE TABLE sc_lon_property_estimate (
	loan_requestment_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	group_estimate char(1),
	desc_detail varchar(255),
	desc_unit decimal(15,4) DEFAULT 0,
	amount_per_unit decimal(15,2) DEFAULT 0,
	total_value decimal(15,2) DEFAULT 0,
	tum_amount decimal(15,2) DEFAULT 0,
	coll_ref varchar(50) NOT NULL,
	percent_estimate decimal(10,4) DEFAULT 0,
	expire_value decimal(15,2) DEFAULT 0,
	depreciate_percent double precision DEFAULT 0,
	detail_estimate varchar(100),
	group_order char(1),
	deposit_status char(1)
) ;
COMMENT ON TABLE sc_lon_property_estimate IS E'!NN!';
ALTER TABLE sc_lon_property_estimate ADD PRIMARY KEY (loan_requestment_no,seq_no,coll_ref);


