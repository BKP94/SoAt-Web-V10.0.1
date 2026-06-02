CREATE TABLE sc_crem_constant (
	organization_name varchar(200) NOT NULL,
	card_status char(1) NOT NULL,
	card_line_per_page double precision,
	card_middle_line double precision,
	card_middle_line_count double precision,
	card_max_line double precision,
	book_status char(1) NOT NULL,
	book_line_per_page double precision,
	book_middle_line double precision,
	book_middle_line_count double precision,
	book_max_line double precision,
	carcass_last_year double precision,
	carcass_last double precision,
	dw_card varchar(50),
	dw_book varchar(50),
	dw_book_first_page varchar(50),
	month_fee_year double precision,
	organization_type char(1),
	keep_advance_arrear char(1),
	crem_group_code varchar(10),
	dw_passbook_gainpage varchar(50)
) ;
ALTER TABLE sc_crem_constant ADD PRIMARY KEY (organization_name);
ALTER TABLE sc_crem_constant ALTER COLUMN organization_name SET NOT NULL;
ALTER TABLE sc_crem_constant ALTER COLUMN card_status SET NOT NULL;
ALTER TABLE sc_crem_constant ALTER COLUMN book_status SET NOT NULL;


