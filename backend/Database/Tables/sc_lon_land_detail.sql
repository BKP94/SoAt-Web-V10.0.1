CREATE TABLE sc_lon_land_detail (
	loan_requestment_no varchar(15) NOT NULL,
	coll_ref varchar(50) NOT NULL,
	near_road_status char(1),
	road_name varchar(50),
	traffic_soi varchar(50),
	distance_road decimal(15,2) DEFAULT 0,
	wide_road decimal(15,2) DEFAULT 0,
	road_type varchar(6),
	right_use_road varchar(50),
	north varchar(50),
	south varchar(50),
	east varchar(50),
	west varchar(50),
	remark varchar(50),
	higth decimal(15,2) DEFAULT 0,
	land_type varchar(6),
	lak_kad_status char(1),
	lak_kad varchar(30),
	other_load varchar(50),
	lak_kad_what varchar(100),
	unit_distance varchar(5),
	tuam_amount decimal(15,2) DEFAULT 0,
	load_code varchar(6),
	sumnak_tidin varchar(50)
) ;
ALTER TABLE sc_lon_land_detail ADD PRIMARY KEY (loan_requestment_no,coll_ref);
ALTER TABLE sc_lon_land_detail ALTER COLUMN loan_requestment_no SET NOT NULL;
ALTER TABLE sc_lon_land_detail ALTER COLUMN coll_ref SET NOT NULL;


