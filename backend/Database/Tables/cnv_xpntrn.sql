CREATE TABLE cnv_xpntrn (
	xpntyp varchar(1),
	docnum varchar(10),
	docdat integer,
	cnfdate integer,
	memtyp varchar(1),
	mem_no varchar(5),
	refdoc varchar(15),
	xpnrefn varchar(10),
	xpnrmk varchar(40),
	xpncash decimal(13,2),
	xpncheq decimal(13,2),
	xpntrnf decimal(13,2),
	xpn_tax decimal(13,2),
	xpntotl decimal(13,2),
	nextseq smallint,
	link_gl varchar(1),
	reqdate integer,
	usr_id1 smallint,
	usr_id2 smallint
) ;


