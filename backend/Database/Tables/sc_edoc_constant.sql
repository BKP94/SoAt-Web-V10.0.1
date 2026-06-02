CREATE TABLE sc_edoc_constant (
	seq_no double precision NOT NULL,
	use_img_picture char(1),
	use_pdf char(1),
	size_img double precision,
	size_pdf double precision,
	imgdb_status char(1),
	address_img varchar(250),
	loan_request_folder varchar(100),
	loan_contract_folder varchar(100),
	loan_coll_folder varchar(100),
	member_new_folder varchar(100),
	member_resign_folder varchar(100),
	member_oth_folder varchar(100),
	chg_share_folder varchar(100),
	chg_coll_folder varchar(100),
	chg_gender_folder varchar(100),
	deposit_new_folder varchar(100),
	use_ini_encrypt char(1),
	file_ini_address varchar(100),
	hrdoc_out_folder varchar(100),
	hrdoc_in_folder varchar(100)
) ;
ALTER TABLE sc_edoc_constant ADD PRIMARY KEY (seq_no);


