CREATE TABLE sc_dep_print_card_item (
	session_id varchar(30) NOT NULL,
	deposit_account_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	page_no double precision,
	line_no double precision,
	operate_date timestamp,
	print_code varchar(6),
	item_wtd double precision,
	item_dep double precision,
	total_balance double precision,
	officer_id varchar(15),
	fixed_item double precision,
	creditor_seq double precision
) ;
ALTER TABLE sc_dep_print_card_item ADD PRIMARY KEY (session_id,deposit_account_no,seq_no);
ALTER TABLE sc_dep_print_card_item ALTER COLUMN session_id SET NOT NULL;
ALTER TABLE sc_dep_print_card_item ALTER COLUMN deposit_account_no SET NOT NULL;
ALTER TABLE sc_dep_print_card_item ALTER COLUMN seq_no SET NOT NULL;


