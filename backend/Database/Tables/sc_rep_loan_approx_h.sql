CREATE TABLE sc_rep_loan_approx_h (
	entry_id varchar(16) NOT NULL,
	approve_amount double precision DEFAULT 0,
	pay_type_code varchar(6) DEFAULT '00',
	install_amount double precision DEFAULT 0,
	payment_amount double precision DEFAULT 0,
	int_rate double precision DEFAULT 0,
	begin_date timestamp,
	start_date timestamp,
	loan_type varchar(6) DEFAULT '00'
) ;
ALTER TABLE sc_rep_loan_approx_h ADD PRIMARY KEY (entry_id);
ALTER TABLE sc_rep_loan_approx_h ALTER COLUMN entry_id SET NOT NULL;


