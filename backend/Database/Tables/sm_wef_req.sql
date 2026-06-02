CREATE TABLE sm_wef_req (
	requestment_no varchar(15) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_wef_req ADD PRIMARY KEY (requestment_no,sm_seq);
ALTER TABLE sm_wef_req ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_wef_req ALTER COLUMN requestment_no SET NOT NULL;


