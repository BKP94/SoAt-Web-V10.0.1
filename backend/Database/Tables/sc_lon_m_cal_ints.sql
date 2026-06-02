CREATE TABLE sc_lon_m_cal_ints (
	conno varchar(15) NOT NULL,
	period double precision NOT NULL,
	pay_date timestamp,
	pay_intstall decimal(15,2),
	pay_interest decimal(15,2),
	pay_total decimal(15,2),
	inst_remain decimal(15,2),
	memno varchar(15),
	asset_rate decimal(15,2),
	period_num decimal(15,2),
	int_date timestamp,
	payment_date timestamp
) ;
COMMENT ON TABLE sc_lon_m_cal_ints IS E'!NN!';
ALTER TABLE sc_lon_m_cal_ints ADD PRIMARY KEY (conno,period);


