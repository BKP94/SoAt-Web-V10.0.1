CREATE TABLE sc_transbank_detail (
	data_code varchar(3) NOT NULL,
	bank_code varchar(6) NOT NULL,
	trandate timestamp NOT NULL,
	seq_tran integer NOT NULL DEFAULT 0,
	seq_no integer NOT NULL DEFAULT 0,
	membership_no varchar(15),
	cmember_name varchar(200),
	amount decimal(15,2) DEFAULT 0,
	acc_no varchar(15),
	member_group_no varchar(15),
	c_reference varchar(15),
	item_type varchar(15),
	branch_bank_code varchar(6),
	fee_amount decimal(15,2) DEFAULT 0,
	salary_id varchar(15),
	amount_bf decimal(15,2) DEFAULT 0,
	bank_det varchar(6),
	ref_div decimal(15,2) DEFAULT 0,
	ref_aver decimal(15,2) DEFAULT 0,
	ref_fee_member char(1) DEFAULT '0'
) ;
ALTER TABLE sc_transbank_detail ADD PRIMARY KEY (data_code,bank_code,trandate,seq_tran,seq_no);


