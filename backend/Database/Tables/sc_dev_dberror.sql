CREATE TABLE sc_dev_dberror (
	client_id varchar(3) NOT NULL,
	error_time varchar(30) NOT NULL,
	seq_no numeric(38) NOT NULL DEFAULT 0,
	sqlerrtext varchar(4000)
) ;
ALTER TABLE sc_dev_dberror ADD PRIMARY KEY (client_id,error_time,seq_no);


