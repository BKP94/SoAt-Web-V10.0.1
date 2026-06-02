CREATE TABLE sc_hr_ucf_aid_type (
	aid_type varchar(6) NOT NULL DEFAULT '00',
	aid_desc varchar(100),
	aid_amount decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_hr_ucf_aid_type ADD PRIMARY KEY (aid_type);
ALTER TABLE sc_hr_ucf_aid_type ALTER COLUMN aid_type SET NOT NULL;


