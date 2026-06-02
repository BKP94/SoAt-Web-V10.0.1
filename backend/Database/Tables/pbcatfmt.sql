CREATE TABLE pbcatfmt (
	pbf_name varchar(30),
	pbf_frmt varchar(254),
	pbf_type numeric(38) NOT NULL,
	pbf_cntr numeric(38)
) ;
CREATE UNIQUE INDEX pbsyscatfrmts_idx ON pbcatfmt (pbf_name);
ALTER TABLE pbcatfmt ALTER COLUMN pbf_type SET NOT NULL;


