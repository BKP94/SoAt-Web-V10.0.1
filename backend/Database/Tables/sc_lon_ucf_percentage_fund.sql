CREATE TABLE sc_lon_ucf_percentage_fund (
	seq_no double precision NOT NULL,
	mem_age varchar(255),
	mem_type varchar(255),
	pay_percentage decimal(15,2)
) ;
ALTER TABLE sc_lon_ucf_percentage_fund ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_lon_ucf_percentage_fund ALTER COLUMN seq_no SET NOT NULL;


