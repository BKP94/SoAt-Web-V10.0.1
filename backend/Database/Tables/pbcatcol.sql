CREATE TABLE pbcatcol (
	pbc_tnam varchar(30) NOT NULL,
	pbc_tid numeric(38),
	pbc_ownr varchar(30) NOT NULL,
	pbc_cnam varchar(30) NOT NULL,
	pbc_cid numeric(38),
	pbc_labl varchar(254),
	pbc_lpos numeric(38),
	pbc_hdr varchar(254),
	pbc_hpos numeric(38),
	pbc_jtfy numeric(38),
	pbc_mask varchar(31),
	pbc_case numeric(38),
	pbc_hght numeric(38),
	pbc_wdth numeric(38),
	pbc_ptrn varchar(31),
	pbc_bmap char(1),
	pbc_init varchar(254),
	pbc_cmnt varchar(254),
	pbc_edit varchar(31),
	pbc_tag varchar(254)
) ;
CREATE UNIQUE INDEX pbsyscatcoldict_idx ON pbcatcol (pbc_tnam, pbc_ownr, pbc_cnam);
ALTER TABLE pbcatcol ALTER COLUMN pbc_tnam SET NOT NULL;
ALTER TABLE pbcatcol ALTER COLUMN pbc_ownr SET NOT NULL;
ALTER TABLE pbcatcol ALTER COLUMN pbc_cnam SET NOT NULL;


