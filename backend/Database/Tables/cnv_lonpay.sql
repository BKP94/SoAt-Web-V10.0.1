CREATE TABLE cnv_lonpay (
	conn_no varchar(10),
	term_no smallint,
	pay_date integer,
	billnum varchar(10),
	nday_int smallint,
	pay_amt decimal(13,2),
	pay_int decimal(12,2),
	pay_bal decimal(13,2),
	pay_chr decimal(10,2),
	pay_by varchar(2),
	fl_retn varchar(1),
	fl_dupl varchar(1),
	fl_prt varchar(1),
	fl_stat varchar(1),
	leg_bal decimal(13,2),
	membpay varchar(5),
	lstdate integer,
	lstterm smallint,
	usr_id1 smallint
) ;


