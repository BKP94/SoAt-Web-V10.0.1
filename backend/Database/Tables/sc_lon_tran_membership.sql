CREATE TABLE sc_lon_tran_membership (
	loan_contract_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	membership_no varchar(15) NOT NULL,
	membership_no_new varchar(15) NOT NULL,
	principal_balance decimal(15,2) NOT NULL,
	tran_date timestamp NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(10) NOT NULL,
	last_access_date timestamp NOT NULL,
	doc_no varchar(15) NOT NULL,
	operate_date timestamp NOT NULL,
	last_calcint_date timestamp NOT NULL,
	old_membership_no varchar(15)
) ;
COMMENT ON TABLE sc_lon_tran_membership IS E'!Nโอนหนี้ให้บุคคลอื่นN!';
COMMENT ON COLUMN sc_lon_tran_membership.doc_no IS E'!NN!';
COMMENT ON COLUMN sc_lon_tran_membership.entry_date IS E'!Nวันที่บันทึกN!';
COMMENT ON COLUMN sc_lon_tran_membership.entry_id IS E'!Nผู้บันทึกN!';
COMMENT ON COLUMN sc_lon_tran_membership.last_access_date IS E'!NN!';
COMMENT ON COLUMN sc_lon_tran_membership.last_calcint_date IS E'!NN!';
COMMENT ON COLUMN sc_lon_tran_membership.loan_contract_no IS E'!Nเลขที่สัญญาN!';
COMMENT ON COLUMN sc_lon_tran_membership.membership_no IS E'!Nทะเบียนเก่าN!';
COMMENT ON COLUMN sc_lon_tran_membership.membership_no_new IS E'!Nทะเบียนใหม่N!';
COMMENT ON COLUMN sc_lon_tran_membership.old_membership_no IS E'!NN!';
COMMENT ON COLUMN sc_lon_tran_membership.operate_date IS E'!NN!';
COMMENT ON COLUMN sc_lon_tran_membership.principal_balance IS E'!NยอดคงเหลือN!';
COMMENT ON COLUMN sc_lon_tran_membership.seq_no IS E'!NลำดับN!';
COMMENT ON COLUMN sc_lon_tran_membership.tran_date IS E'!Nวันที่โอนN!';
ALTER TABLE sc_lon_tran_membership ADD PRIMARY KEY (loan_contract_no,seq_no);
ALTER TABLE sc_lon_tran_membership ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_lon_tran_membership ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_lon_tran_membership ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_lon_tran_membership ALTER COLUMN membership_no_new SET NOT NULL;
ALTER TABLE sc_lon_tran_membership ALTER COLUMN principal_balance SET NOT NULL;
ALTER TABLE sc_lon_tran_membership ALTER COLUMN tran_date SET NOT NULL;
ALTER TABLE sc_lon_tran_membership ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_lon_tran_membership ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_lon_tran_membership ALTER COLUMN last_access_date SET NOT NULL;
ALTER TABLE sc_lon_tran_membership ALTER COLUMN doc_no SET NOT NULL;
ALTER TABLE sc_lon_tran_membership ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_lon_tran_membership ALTER COLUMN last_calcint_date SET NOT NULL;


