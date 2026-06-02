CREATE TABLE sc_lon_req_coll_law_owner_old (
	loan_requestment_no varchar(15),
	coll_ref varchar(50),
	seq_no double precision NOT NULL,
	owner_name varchar(150),
	age double precision,
	parent varchar(50),
	married varchar(10),
	sponse_name varchar(50),
	nationality varchar(10),
	status char(1),
	address varchar(50),
	tambol varchar(50),
	amper varchar(50),
	jungwat varchar(50),
	muu varchar(20),
	seq_coll double precision,
	marriage_status char(1),
	datetime_of_birth timestamp,
	id_card varchar(13),
	tel_no varchar(50),
	road varchar(30),
	soi varchar(30),
	muu_ban varchar(30),
	date_of_birth timestamp
) ;
ALTER TABLE sc_lon_req_coll_law_owner_old ALTER COLUMN seq_no SET NOT NULL;


