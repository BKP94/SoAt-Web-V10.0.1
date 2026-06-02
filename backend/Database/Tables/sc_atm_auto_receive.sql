CREATE TABLE sc_atm_auto_receive (
	loan_contract_no char(15),
	ref_loan_doc_no char(20),
	seq_no double precision,
	process_date timestamp,
	entry_date timestamp,
	entry_id char(7),
	branch_id varchar(6),
	receive_status char(1),
	receive_no char(10)
) ;
CREATE UNIQUE INDEX sys_c0011302 ON sc_atm_auto_receive (loan_contract_no, ref_loan_doc_no);


