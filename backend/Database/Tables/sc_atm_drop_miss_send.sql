CREATE TABLE sc_atm_drop_miss_send (
	receive_year double precision NOT NULL DEFAULT 0,
	receive_month double precision NOT NULL DEFAULT 0,
	membership_no varchar(15) NOT NULL,
	loan_contract_no varchar(15),
	modify_status_new char(1) DEFAULT '0'
) ;
ALTER TABLE sc_atm_drop_miss_send ADD PRIMARY KEY (receive_year,receive_month,membership_no);
ALTER TABLE sc_atm_drop_miss_send ALTER COLUMN receive_year SET NOT NULL;
ALTER TABLE sc_atm_drop_miss_send ALTER COLUMN receive_month SET NOT NULL;
ALTER TABLE sc_atm_drop_miss_send ALTER COLUMN membership_no SET NOT NULL;


