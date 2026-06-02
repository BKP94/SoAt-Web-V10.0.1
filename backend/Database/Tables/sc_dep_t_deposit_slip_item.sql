CREATE TABLE sc_dep_t_deposit_slip_item (
	deposit_slip_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	deposit_money_type_code varchar(6) NOT NULL DEFAULT '00',
	item_amount decimal(15,2) DEFAULT 0,
	chq_bank varchar(6),
	chq_date timestamp,
	chq_no varchar(20),
	bank_fr varchar(6),
	bank_to varchar(6),
	bank_date timestamp,
	oth_item char(3),
	trans_bank_status char(1),
	bank_code varchar(6),
	bank_branch_code varchar(6),
	bank_acc_no varchar(15),
	link_book_bank char(1),
	book_bank_seq numeric(38),
	chq_branch varchar(6)
) ;
ALTER TABLE sc_dep_t_deposit_slip_item ADD PRIMARY KEY (deposit_slip_no,seq_no);
ALTER TABLE sc_dep_t_deposit_slip_item ALTER COLUMN deposit_slip_no SET NOT NULL;
ALTER TABLE sc_dep_t_deposit_slip_item ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_dep_t_deposit_slip_item ALTER COLUMN deposit_money_type_code SET NOT NULL;


