CREATE TABLE cnv_atmreq (
	docacc varchar(10),
	docdat integer,
	mem_no varchar(5),
	acc_no1 varchar(2),
	acc_no2 varchar(5),
	balance decimal(12,2),
	mx_p_trn decimal(12,2),
	mx_p_day decimal(12,2),
	mx_p_wek decimal(12,2),
	mx_p_mon decimal(12,2),
	wdrw_dat integer,
	deps_dat integer,
	fl_wdrw varchar(1),
	fl_deps varchar(1),
	docstat varchar(1),
	credid varchar(20),
	trnseri integer,
	bankcod varchar(6),
	accnobk varchar(15),
	usr_id1 smallint,
	usr_id2 smallint
) ;


