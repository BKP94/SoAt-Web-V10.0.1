CREATE TABLE sc_tmp_gen_msg (
	membership_no varchar(15) NOT NULL,
	memname varchar(200),
	messages varchar(4000),
	remark varchar(200)
) ;
ALTER TABLE sc_tmp_gen_msg ADD PRIMARY KEY (membership_no);
ALTER TABLE sc_tmp_gen_msg ALTER COLUMN membership_no SET NOT NULL;


