CREATE TABLE sm_wef_ucf_type (
	wef_type varchar(3) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_wef_ucf_type ADD PRIMARY KEY (wef_type,sm_seq);
ALTER TABLE sm_wef_ucf_type ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_wef_ucf_type ALTER COLUMN wef_type SET NOT NULL;


