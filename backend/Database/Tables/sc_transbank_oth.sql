CREATE TABLE sc_transbank_oth (
	operate_date timestamp NOT NULL,
	membership_no varchar(15) NOT NULL,
	seq_no integer NOT NULL DEFAULT 0,
	amount decimal(15,2) DEFAULT 0,
	post_status char(1) DEFAULT '0',
	entry_id varchar(16),
	entry_branch_id varchar(2),
	entry_date timestamp,
	bank_code varchar(6),
	bank_branch_code varchar(6),
	bank_acc_no varchar(15),
	acc_name varchar(100),
	c_ref varchar(3),
	item_type varchar(6)
) ;
ALTER TABLE sc_transbank_oth ADD PRIMARY KEY (operate_date,membership_no,seq_no);


