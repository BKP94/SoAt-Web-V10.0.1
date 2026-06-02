CREATE TABLE pbcatvld (
	pbv_name varchar(30),
	pbv_vald varchar(254),
	pbv_type numeric(38),
	pbv_cntr numeric(38),
	pbv_msg varchar(254)
) ;
CREATE UNIQUE INDEX pbsyscatvlds_idx ON pbcatvld (pbv_name);


