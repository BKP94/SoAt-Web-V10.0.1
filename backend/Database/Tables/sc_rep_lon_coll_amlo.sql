CREATE TABLE sc_rep_lon_coll_amlo (
	seq_no double precision NOT NULL,
	operate_date timestamp,
	loan_contract_no varchar(15),
	law_appraise varchar(500),
	appraised_rate decimal(15,2),
	loan_reason varchar(500),
	coll_ref_des varchar(100),
	membership_no varchar(8)
) ;
ALTER TABLE sc_rep_lon_coll_amlo ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_rep_lon_coll_amlo ALTER COLUMN seq_no SET NOT NULL;


