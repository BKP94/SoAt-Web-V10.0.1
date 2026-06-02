CREATE TABLE sm_mobile_regis (
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	bank_id varchar(6) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_mobile_regis ADD PRIMARY KEY (membership_no,seq_no,bank_id,sm_seq);
ALTER TABLE sm_mobile_regis ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_mobile_regis ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sm_mobile_regis ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sm_mobile_regis ALTER COLUMN bank_id SET NOT NULL;


