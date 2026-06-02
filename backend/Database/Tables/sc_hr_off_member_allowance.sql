CREATE TABLE sc_hr_off_member_allowance (
	official_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	allowance_type varchar(6) DEFAULT '00',
	travel_date timestamp,
	paid_amount decimal(15,2) DEFAULT 0,
	paid_date timestamp
) ;
ALTER TABLE sc_hr_off_member_allowance ADD PRIMARY KEY (official_no,seq_no);
ALTER TABLE sc_hr_off_member_allowance ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_member_allowance ALTER COLUMN seq_no SET NOT NULL;


