CREATE TABLE sc_lon_prooerty_summary (
	loan_requestment_no varchar(15) NOT NULL,
	coll_ref varchar(50) NOT NULL,
	chud_te varchar(25),
	krag_te varchar(25),
	approve_amount decimal(15,2) DEFAULT 0,
	installment double precision DEFAULT 0,
	insurance_amount decimal(15,2) DEFAULT 0,
	approve_desc varchar(255),
	percent_estimate decimal(10,4) DEFAULT 0,
	total_collecteral decimal(15,2) DEFAULT 0,
	share_coll decimal(15,2) DEFAULT 0,
	property_amount decimal(15,2) DEFAULT 0,
	approve_because varchar(100)
) ;
COMMENT ON TABLE sc_lon_prooerty_summary IS E'!NN!';
ALTER TABLE sc_lon_prooerty_summary ADD PRIMARY KEY (loan_requestment_no,coll_ref);


