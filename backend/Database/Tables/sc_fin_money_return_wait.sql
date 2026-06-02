CREATE TABLE sc_fin_money_return_wait (
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	operate_date timestamp,
	money_amount decimal(15,2),
	money_system char(3),
	money_refno char(15),
	money_vourcher char(15),
	entry_id char(16),
	entry_date timestamp,
	entry_branch char(2),
	entry_clientid char(3),
	cancel_status char(1),
	return_status char(1),
	return_account char(8),
	return_vourcher char(15),
	cancel_return char(1),
	cancel_vourcher char(15)
) ;
ALTER TABLE sc_fin_money_return_wait ADD PRIMARY KEY (membership_no,seq_no);


