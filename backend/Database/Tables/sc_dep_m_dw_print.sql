CREATE TABLE sc_dep_m_dw_print (
	seq_no double precision NOT NULL DEFAULT 0,
	dw_print_card varchar(60),
	dw_print_passbook_fp varchar(60),
	dw_print_passbook_item varchar(60),
	dw_print_slip varchar(60),
	dw_print_interest varchar(60),
	dw_print_withdraw_fee varchar(60)
) ;
ALTER TABLE sc_dep_m_dw_print ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_dep_m_dw_print ALTER COLUMN seq_no SET NOT NULL;


