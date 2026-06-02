CREATE TABLE sc_crem_rule (
	crem_type varchar(3) NOT NULL,
	description varchar(100),
	new_fee decimal(15,2),
	year_fee decimal(15,2),
	expenses decimal(15,2),
	pay_same_type decimal(15,2),
	pay_different_type decimal(15,2),
	max_age bigint,
	min_advance decimal(15,2),
	month_dead_acc bigint,
	month_dead_acc_other bigint,
	month_dead_max bigint,
	month_dead_m_other bigint,
	crem_advance_arrear decimal(18,2),
	return_receive_count double precision,
	registered_before_pay char(1)
) ;
ALTER TABLE sc_crem_rule ADD PRIMARY KEY (crem_type);
ALTER TABLE sc_crem_rule ALTER COLUMN crem_type SET NOT NULL;


