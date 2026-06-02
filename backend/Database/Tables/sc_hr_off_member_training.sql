CREATE TABLE sc_hr_off_member_training (
	official_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	training_name varchar(100),
	training_desc varchar(500),
	training_place varchar(100),
	begin_date timestamp,
	end_date timestamp,
	training_year double precision DEFAULT 0,
	training_time varchar(50),
	training_refer varchar(50),
	training_pay_amount decimal(15,2) DEFAULT 0,
	regis_cost decimal(15,2),
	trav_cost decimal(15,2),
	allowance decimal(15,2),
	hotel_cost decimal(15,2)
) ;
ALTER TABLE sc_hr_off_member_training ADD PRIMARY KEY (official_no,seq_no);
ALTER TABLE sc_hr_off_member_training ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_member_training ALTER COLUMN seq_no SET NOT NULL;


