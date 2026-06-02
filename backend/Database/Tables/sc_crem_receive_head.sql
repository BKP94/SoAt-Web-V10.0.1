CREATE TABLE sc_crem_receive_head (
	membership_no varchar(15) NOT NULL,
	receive_year double precision NOT NULL,
	receive_month double precision NOT NULL,
	receipt_no varchar(50),
	receipt_date timestamp NOT NULL,
	receive_status char(1) NOT NULL,
	crem_code_array varchar(255),
	remark varchar(255)
) ;
ALTER TABLE sc_crem_receive_head ADD PRIMARY KEY (membership_no,receive_year,receive_month);
ALTER TABLE sc_crem_receive_head ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_crem_receive_head ALTER COLUMN receive_year SET NOT NULL;
ALTER TABLE sc_crem_receive_head ALTER COLUMN receive_month SET NOT NULL;
ALTER TABLE sc_crem_receive_head ALTER COLUMN receipt_date SET NOT NULL;
ALTER TABLE sc_crem_receive_head ALTER COLUMN receive_status SET NOT NULL;


