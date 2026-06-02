CREATE TABLE sc_rep_scq_form8_mis65 (
	operate_date timestamp NOT NULL,
	item_type varchar(6) NOT NULL DEFAULT '00',
	item_desc varchar(100),
	time_now double precision DEFAULT 0,
	time_d2_d7 double precision DEFAULT 0,
	time_d8_m1 double precision DEFAULT 0,
	time_m1g_m3 double precision DEFAULT 0,
	time_m3g_m6 double precision DEFAULT 0,
	time_m6g_m12 double precision DEFAULT 0,
	time_y1g_y5 double precision DEFAULT 0,
	time_y5g_y10 double precision DEFAULT 0,
	time_y10g double precision DEFAULT 0,
	time_noterm double precision DEFAULT 0,
	time_1m decimal(15,2) DEFAULT 0,
	time_2m decimal(15,2) DEFAULT 0,
	time_3m decimal(15,2) DEFAULT 0,
	time_4m decimal(15,2) DEFAULT 0,
	time_5m decimal(15,2) DEFAULT 0,
	time_6m decimal(15,2) DEFAULT 0,
	time_7m decimal(15,2) DEFAULT 0,
	time_8m decimal(15,2) DEFAULT 0,
	time_9m decimal(15,2) DEFAULT 0,
	time_10m decimal(15,2) DEFAULT 0,
	time_11m decimal(15,2) DEFAULT 0,
	time_12m decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_rep_scq_form8_mis65 ADD PRIMARY KEY (operate_date,item_type);
ALTER TABLE sc_rep_scq_form8_mis65 ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_rep_scq_form8_mis65 ALTER COLUMN item_type SET NOT NULL;


