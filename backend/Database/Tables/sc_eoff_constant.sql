CREATE TABLE sc_eoff_constant (
	seq_no double precision NOT NULL,
	use_img_picture char(1),
	use_pdf char(1),
	size_img double precision,
	size_pdf double precision,
	imgdb_status char(1),
	address_img varchar(250),
	use_ini_encrypt char(1),
	file_ini_address varchar(100),
	eoff_docin_folder varchar(100),
	eoff_docout_folder varchar(100)
) ;
ALTER TABLE sc_eoff_constant ADD PRIMARY KEY (seq_no);


