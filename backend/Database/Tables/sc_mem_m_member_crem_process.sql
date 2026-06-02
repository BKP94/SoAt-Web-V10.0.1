CREATE TABLE sc_mem_m_member_crem_process (
	membership_no char(7),
	crem_number char(7),
	crem_type char(2),
	account_year double precision,
	keeping_type char(3),
	crem_balance decimal(15,2),
	kep_ref char(10),
	entry_date timestamp,
	post_status char(1),
	start_kep_date timestamp,
	last_process_date timestamp,
	period_of_month decimal(15,2),
	fee_balance decimal(15,2),
	money_amount_kep decimal(15,2),
	fee_year_balance decimal(15,2),
	register_round integer
) ;


