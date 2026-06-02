CREATE TABLE sc_hr_off_member_superannuate (
	official_no varchar(15) NOT NULL,
	paid_amount decimal(15,2) DEFAULT 0,
	paid_date timestamp
) ;
ALTER TABLE sc_hr_off_member_superannuate ADD PRIMARY KEY (official_no);
ALTER TABLE sc_hr_off_member_superannuate ALTER COLUMN official_no SET NOT NULL;


