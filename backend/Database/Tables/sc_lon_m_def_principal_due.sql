CREATE TABLE sc_lon_m_def_principal_due (
	loan_requestment_no varchar(15) NOT NULL,
	sequence_no double precision,
	due_date timestamp,
	loan_amount decimal(15,2),
	seq_no double precision NOT NULL DEFAULT 0,
	to_sybase char(1) DEFAULT '0',
	loan_32 char(1) DEFAULT '0'
) ;
COMMENT ON TABLE sc_lon_m_def_principal_due IS E'!N??????? - ???????????????N!';
COMMENT ON COLUMN sc_lon_m_def_principal_due.due_date IS E'!N???????????????N!!MM!';
COMMENT ON COLUMN sc_lon_m_def_principal_due.loan_amount IS E'!N????????? (???)N!!M????????????????????????M!';
COMMENT ON COLUMN sc_lon_m_def_principal_due.loan_requestment_no IS E'!N???????N!!MM!';
COMMENT ON COLUMN sc_lon_m_def_principal_due.seq_no IS E'!N?????N!!MM!';
CREATE INDEX idx_lon_req_prindue ON sc_lon_m_def_principal_due (loan_requestment_no);
ALTER TABLE sc_lon_m_def_principal_due ADD PRIMARY KEY (loan_requestment_no,seq_no);
ALTER TABLE sc_lon_m_def_principal_due ALTER COLUMN seq_no SET NOT NULL;


