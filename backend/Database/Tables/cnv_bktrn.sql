CREATE TABLE cnv_bktrn (
	bktrntyp varchar(2),
	trndat integer,
	chqnum varchar(10),
	chqdat integer,
	bnkcod varchar(3),
	cuscod varchar(5),
	payindat integer,
	getdat integer,
	amount decimal(13,2),
	charge decimal(12,2),
	netamt decimal(13,2),
	remamt decimal(13,2),
	cmplapp varchar(1),
	chqstat varchar(2),
	bnkacc varchar(3),
	jnltrntyp varchar(1),
	chqtyp varchar(1),
	remark varchar(40),
	postgl varchar(1),
	refdoc varchar(10),
	usr_id1 smallint
) ;


