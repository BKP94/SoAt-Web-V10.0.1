CREATE TABLE pbcattbl (
	pbt_tnam varchar(30) NOT NULL,
	pbt_tid numeric(38),
	pbt_ownr varchar(30) NOT NULL,
	pbd_fhgt numeric(38),
	pbd_fwgt numeric(38),
	pbd_fitl char(1),
	pbd_funl char(1),
	pbd_fchr numeric(38),
	pbd_fptc numeric(38),
	pbd_ffce varchar(18),
	pbh_fhgt numeric(38),
	pbh_fwgt numeric(38),
	pbh_fitl char(1),
	pbh_funl char(1),
	pbh_fchr numeric(38),
	pbh_fptc numeric(38),
	pbh_ffce varchar(18),
	pbl_fhgt numeric(38),
	pbl_fwgt numeric(38),
	pbl_fitl char(1),
	pbl_funl char(1),
	pbl_fchr numeric(38),
	pbl_fptc numeric(38),
	pbl_ffce varchar(18),
	pbt_cmnt varchar(254)
) ;
CREATE UNIQUE INDEX pbsyscatpbt_idx ON pbcattbl (pbt_tnam, pbt_ownr);
ALTER TABLE pbcattbl ALTER COLUMN pbt_tnam SET NOT NULL;
ALTER TABLE pbcattbl ALTER COLUMN pbt_ownr SET NOT NULL;


