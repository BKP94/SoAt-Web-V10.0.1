CREATE TABLE sc_wef_req_snr (
	requestment_no varchar(15) NOT NULL,
	manual_status char(1),
	snr_date timestamp,
	snr_detail varchar(100),
	remark varchar(100),
	receive_name varchar(200),
	money_type_id varchar(6),
	bank_id varchar(6),
	bank_acc_no varchar(15),
	date_of_birth timestamp,
	approve_date timestamp,
	age_life varchar(100),
	age_mem varchar(100),
	snr_type varchar(6)
) ;
ALTER TABLE sc_wef_req_snr ADD PRIMARY KEY (requestment_no);
ALTER TABLE sc_wef_req_snr ALTER COLUMN requestment_no SET NOT NULL;


