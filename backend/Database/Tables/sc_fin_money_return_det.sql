CREATE TABLE sc_fin_money_return_det (
	membership_no varchar(15) NOT NULL,
	item_no double precision NOT NULL DEFAULT 0,
	seq_no double precision NOT NULL DEFAULT 0,
	item_type varchar(6) DEFAULT '00',
	action_user varchar(16) NOT NULL,
	action_date timestamp,
	action_br varchar(6) NOT NULL,
	voucher_no varchar(30),
	status char(1) NOT NULL DEFAULT '0',
	seq_adjust double precision DEFAULT 0,
	dep_group_no varchar(15)
) ;
ALTER TABLE sc_fin_money_return_det ADD PRIMARY KEY (membership_no,item_no,seq_no);
ALTER TABLE sc_fin_money_return_det ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_fin_money_return_det ALTER COLUMN item_no SET NOT NULL;
ALTER TABLE sc_fin_money_return_det ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_fin_money_return_det ALTER COLUMN action_user SET NOT NULL;
ALTER TABLE sc_fin_money_return_det ALTER COLUMN action_br SET NOT NULL;
ALTER TABLE sc_fin_money_return_det ALTER COLUMN status SET NOT NULL;


