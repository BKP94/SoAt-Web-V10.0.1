CREATE TABLE sc_lon_req_coll_per_square (
	doc_no varchar(15) NOT NULL,
	lessland_square double precision NOT NULL DEFAULT 0,
	per_square_amount decimal(15,2) DEFAULT 0
) ;
ALTER TABLE sc_lon_req_coll_per_square ADD PRIMARY KEY (doc_no,lessland_square);
ALTER TABLE sc_lon_req_coll_per_square ALTER COLUMN doc_no SET NOT NULL;
ALTER TABLE sc_lon_req_coll_per_square ALTER COLUMN lessland_square SET NOT NULL;


