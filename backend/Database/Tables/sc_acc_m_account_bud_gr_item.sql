CREATE TABLE sc_acc_m_account_bud_gr_item (
	account_year double precision NOT NULL DEFAULT 0,
	budget_id varchar(6) NOT NULL,
	branch_id varchar(6) NOT NULL DEFAULT '00',
	seq_no double precision NOT NULL DEFAULT 0,
	operate_date timestamp,
	item_type varchar(3),
	amount decimal(15,2) DEFAULT 0,
	transfer_id double precision DEFAULT 0
) ;
COMMENT ON TABLE sc_acc_m_account_bud_gr_item IS E'!NN!';
ALTER TABLE sc_acc_m_account_bud_gr_item ADD PRIMARY KEY (account_year,budget_id,branch_id,seq_no);


