CREATE TABLE sc_mem_retire_found_detail (
	account_year double precision NOT NULL,
	membership_no varchar(15) NOT NULL,
	member_group_no varchar(15),
	approve_date timestamp,
	member_age double precision,
	date_of_birth timestamp,
	age double precision,
	date_of_retire timestamp,
	dead_date timestamp,
	dead_status char(1),
	share_stock bigint,
	share_payment bigint,
	share_calc bigint,
	age_calc bigint,
	rev_status char(1),
	name_of_rev varchar(100),
	rev_date timestamp,
	entry_date timestamp,
	entry_id varchar(10),
	past_recv_status char(1),
	id_card varchar(15)
) ;
ALTER TABLE sc_mem_retire_found_detail ADD PRIMARY KEY (account_year,membership_no);
ALTER TABLE sc_mem_retire_found_detail ALTER COLUMN account_year SET NOT NULL;
ALTER TABLE sc_mem_retire_found_detail ALTER COLUMN membership_no SET NOT NULL;


