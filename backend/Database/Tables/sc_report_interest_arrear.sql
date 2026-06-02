CREATE TABLE sc_report_interest_arrear (
	membership_no varchar(15) NOT NULL,
	seq_no bigint NOT NULL DEFAULT 0,
	contract_no varchar(15),
	interest decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_report_interest_arrear ADD PRIMARY KEY (membership_no,seq_no);
ALTER TABLE sc_report_interest_arrear ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_report_interest_arrear ALTER COLUMN seq_no SET NOT NULL;


