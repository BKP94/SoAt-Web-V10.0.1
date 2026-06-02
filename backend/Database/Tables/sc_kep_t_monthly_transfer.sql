CREATE TABLE sc_kep_t_monthly_transfer (
	membership_no varchar(15) NOT NULL,
	year double precision NOT NULL DEFAULT 0,
	month double precision NOT NULL DEFAULT 0,
	status varchar(1),
	transfer_data varchar(255),
	money_amount decimal(15,2) DEFAULT 0,
	keep_real decimal(15,2) DEFAULT 0,
	keeping_status varchar(1),
	transfer_data_receive varchar(255),
	fin_group varchar(1),
	member_group_no varchar(15),
	isr_amount decimal(15,2) DEFAULT 0,
	share_amount decimal(15,2) DEFAULT 0,
	fee_amount decimal(15,2) DEFAULT 0,
	dep_amount decimal(15,2) DEFAULT 0,
	emer_amount decimal(15,2) DEFAULT 0,
	norm_amount decimal(15,2) DEFAULT 0,
	spec_amount decimal(15,2) DEFAULT 0,
	keeping_group_no varchar(15),
	salary_id varchar(15),
	txt_transfer varchar(110)
) ;
ALTER TABLE sc_kep_t_monthly_transfer ADD PRIMARY KEY (membership_no,year,month);
ALTER TABLE sc_kep_t_monthly_transfer ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_transfer ALTER COLUMN year SET NOT NULL;
ALTER TABLE sc_kep_t_monthly_transfer ALTER COLUMN month SET NOT NULL;


