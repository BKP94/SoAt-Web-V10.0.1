CREATE TABLE sc_mem_m_insure_req (
	insurance_no varchar(15) NOT NULL,
	req_date timestamp NOT NULL,
	insurance_type varchar(5) NOT NULL,
	membership_no varchar(15) NOT NULL,
	age_life varchar(100),
	count_krom integer,
	insurance_approve decimal(15,2) DEFAULT 0,
	insurance_cost decimal(15,2) DEFAULT 0,
	insurance_detail varchar(100),
	approve_status char(1) DEFAULT '2',
	entry_id varchar(16),
	entry_date timestamp,
	method_status varchar(15),
	loan_bal decimal(15,2),
	count_krom_last integer DEFAULT 0,
	age_year integer DEFAULT 0,
	insure_year double precision DEFAULT 0,
	prename_code varchar(6),
	member_name varchar(50),
	member_surname varchar(50),
	id_card varchar(13),
	insurance_mobile varchar(15)
) ;
ALTER TABLE sc_mem_m_insure_req ADD PRIMARY KEY (insurance_no);
ALTER TABLE sc_mem_m_insure_req ALTER COLUMN insurance_no SET NOT NULL;
ALTER TABLE sc_mem_m_insure_req ALTER COLUMN req_date SET NOT NULL;
ALTER TABLE sc_mem_m_insure_req ALTER COLUMN insurance_type SET NOT NULL;
ALTER TABLE sc_mem_m_insure_req ALTER COLUMN membership_no SET NOT NULL;


