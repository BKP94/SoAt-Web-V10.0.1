CREATE TABLE sc_wef_ucf_ded_reason (
	reason_type varchar(6) NOT NULL,
	reason_desc varchar(50)
) ;
ALTER TABLE sc_wef_ucf_ded_reason ADD PRIMARY KEY (reason_type);
ALTER TABLE sc_wef_ucf_ded_reason ALTER COLUMN reason_type SET NOT NULL;


