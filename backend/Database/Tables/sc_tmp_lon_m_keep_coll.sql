CREATE TABLE sc_tmp_lon_m_keep_coll (
	seq_no double precision NOT NULL,
	member_group_no varchar(15),
	membership_no varchar(15),
	loan_contract_no varchar(15),
	period_payment_amount decimal(15,2) DEFAULT 0.00,
	loan_payment_type_code varchar(6),
	principal_balance decimal(15,2) DEFAULT 0.00,
	principal_arr_all decimal(15,2) DEFAULT 0.00,
	interest_arrear decimal(15,2) DEFAULT 0.00,
	ref_own_no varchar(15) NOT NULL,
	principal_keep decimal(15,2) DEFAULT 0.00,
	interest_keep decimal(15,2) DEFAULT 0.00
) ;
ALTER TABLE sc_tmp_lon_m_keep_coll ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_tmp_lon_m_keep_coll ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_tmp_lon_m_keep_coll ALTER COLUMN ref_own_no SET NOT NULL;


