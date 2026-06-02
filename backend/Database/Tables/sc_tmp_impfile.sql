CREATE TABLE sc_tmp_impfile (
	time_id varchar(16) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	paid_date timestamp NOT NULL,
	keeping_type_group varchar(3) NOT NULL,
	loan_contract_no varchar(15) NOT NULL,
	membership_no varchar(15) NOT NULL,
	amount decimal(15,2) NOT NULL DEFAULT 0
) ;
ALTER TABLE sc_tmp_impfile ADD PRIMARY KEY (time_id,seq_no);
ALTER TABLE sc_tmp_impfile ALTER COLUMN time_id SET NOT NULL;
ALTER TABLE sc_tmp_impfile ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_tmp_impfile ALTER COLUMN paid_date SET NOT NULL;
ALTER TABLE sc_tmp_impfile ALTER COLUMN keeping_type_group SET NOT NULL;
ALTER TABLE sc_tmp_impfile ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_tmp_impfile ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_tmp_impfile ALTER COLUMN amount SET NOT NULL;


