CREATE TABLE pbcatedt (
	pbe_name varchar(30),
	pbe_edit varchar(254),
	pbe_type numeric(38),
	pbe_cntr numeric(38),
	pbe_seqn numeric(38),
	pbe_flag numeric(38),
	pbe_work varchar(32)
) ;
CREATE UNIQUE INDEX pbsyspbe_idx ON pbcatedt (pbe_name, pbe_seqn);


