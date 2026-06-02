CREATE TABLE sm_doc_inout (
	io char(1) NOT NULL,
	tdata varchar(6) NOT NULL,
	requestment_no varchar(15) NOT NULL,
	loan_contract_no varchar(15) NOT NULL,
	sm_seq bigint NOT NULL DEFAULT 0
) ;
ALTER TABLE sm_doc_inout ADD PRIMARY KEY (io,tdata,requestment_no,loan_contract_no,sm_seq);
ALTER TABLE sm_doc_inout ALTER COLUMN sm_seq SET NOT NULL;
ALTER TABLE sm_doc_inout ALTER COLUMN io SET NOT NULL;
ALTER TABLE sm_doc_inout ALTER COLUMN tdata SET NOT NULL;
ALTER TABLE sm_doc_inout ALTER COLUMN requestment_no SET NOT NULL;
ALTER TABLE sm_doc_inout ALTER COLUMN loan_contract_no SET NOT NULL;


