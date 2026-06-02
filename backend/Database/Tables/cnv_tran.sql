CREATE TABLE cnv_tran (
	acc_no1 varchar(2),
	acc_no2 varchar(5),
	seri_no integer,
	date_in integer,
	time_in varchar(8),
	tran_amt decimal(13,2),
	balance decimal(13,2),
	prime decimal(12,2),
	intothr decimal(12,2),
	by_opr smallint,
	trn_ty varchar(3),
	trn_no varchar(1),
	fl_int varchar(1),
	fl_prt varchar(1),
	fl_crd varchar(1),
	lnbk_no smallint,
	book_no integer,
	card_no integer,
	work_no smallint,
	docrefn varchar(10),
	docnum varchar(10),
	trncod varchar(2),
	curdate integer
) ;


