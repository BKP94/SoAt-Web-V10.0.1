CREATE TABLE sc_lon_property_meeting (
	loan_requestment_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	meeting_date timestamp,
	type_of_meet char(1) DEFAULT '0',
	place_meet varchar(50),
	officer varchar(50),
	remark varchar(100),
	used_car char(1) DEFAULT '0',
	used_kilo double precision DEFAULT 0,
	car_fee_amount decimal(15,2) DEFAULT 0,
	keep_car_fee_status char(1) DEFAULT '0',
	coll_ref varchar(50),
	time_meet timestamp,
	chq_paid varchar(50),
	chq_amount decimal(15,2) DEFAULT 0,
	servey_place varchar(50)
) ;
COMMENT ON TABLE sc_lon_property_meeting IS E'!NN!';
ALTER TABLE sc_lon_property_meeting ADD PRIMARY KEY (loan_requestment_no,seq_no);


