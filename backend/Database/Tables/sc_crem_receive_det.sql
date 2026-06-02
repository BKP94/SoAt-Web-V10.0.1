CREATE TABLE sc_crem_receive_det (
	membership_no varchar(15) NOT NULL,
	crem_code varchar(10) NOT NULL,
	receive_year double precision NOT NULL,
	receive_month double precision NOT NULL,
	receive_seq double precision NOT NULL,
	item_type_code varchar(3) NOT NULL,
	description varchar(100),
	amount decimal(18,2),
	balance decimal(18,2),
	post_status char(1) NOT NULL,
	return_status char(1)
) ;
CREATE UNIQUE INDEX sc_crem_receive_det_x ON sc_crem_receive_det (membership_no, crem_code, receive_seq, receive_year, receive_month);
ALTER TABLE sc_crem_receive_det ADD PRIMARY KEY (membership_no,crem_code,receive_year,receive_month,receive_seq);
ALTER TABLE sc_crem_receive_det ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_crem_receive_det ALTER COLUMN crem_code SET NOT NULL;
ALTER TABLE sc_crem_receive_det ALTER COLUMN receive_year SET NOT NULL;
ALTER TABLE sc_crem_receive_det ALTER COLUMN receive_month SET NOT NULL;
ALTER TABLE sc_crem_receive_det ALTER COLUMN receive_seq SET NOT NULL;
ALTER TABLE sc_crem_receive_det ALTER COLUMN item_type_code SET NOT NULL;
ALTER TABLE sc_crem_receive_det ALTER COLUMN post_status SET NOT NULL;


