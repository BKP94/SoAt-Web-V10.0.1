CREATE TABLE sc_mem_m_member_crem_rec_det (
	receipt_no varchar(15) NOT NULL,
	seq_no double precision,
	item_type varchar(6) NOT NULL,
	item_amount decimal(15,2),
	description char(100),
	crem_type varchar(6) NOT NULL,
	ref_cremmemno varchar(15) NOT NULL,
	balance double precision,
	ref_cremnumber varchar(15),
	register_round integer
) ;
ALTER TABLE sc_mem_m_member_crem_rec_det ADD PRIMARY KEY (receipt_no,item_type,crem_type,ref_cremmemno);


