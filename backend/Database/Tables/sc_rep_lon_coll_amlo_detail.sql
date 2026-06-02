CREATE TABLE sc_rep_lon_coll_amlo_detail (
	seq_no double precision NOT NULL,
	coll_detail varchar(2000),
	total_coll decimal(15,2),
	coll_reason varchar(2000),
	op_date timestamp,
	membership_no varchar(8)
) ;
ALTER TABLE sc_rep_lon_coll_amlo_detail ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_rep_lon_coll_amlo_detail ALTER COLUMN seq_no SET NOT NULL;


