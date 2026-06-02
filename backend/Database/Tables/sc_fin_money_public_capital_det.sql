CREATE TABLE sc_fin_money_public_capital_det (
	public_no varchar(15) NOT NULL,
	item_no double precision NOT NULL DEFAULT 0,
	seq_no double precision NOT NULL DEFAULT 0,
	item_type varchar(6) DEFAULT '00',
	action_user varchar(16),
	action_date timestamp,
	action_br varchar(6),
	voucher_no varchar(15),
	status char(1) NOT NULL DEFAULT '0',
	seq_adjust double precision DEFAULT 0
) ;
ALTER TABLE sc_fin_money_public_capital_det ADD PRIMARY KEY (public_no,item_no,seq_no);
ALTER TABLE sc_fin_money_public_capital_det ALTER COLUMN public_no SET NOT NULL;
ALTER TABLE sc_fin_money_public_capital_det ALTER COLUMN item_no SET NOT NULL;
ALTER TABLE sc_fin_money_public_capital_det ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_fin_money_public_capital_det ALTER COLUMN status SET NOT NULL;


