CREATE TABLE sc_crem_receive_return (
	membership_no varchar(15) NOT NULL,
	crem_code varchar(10) NOT NULL,
	receive_year double precision NOT NULL,
	receive_month double precision NOT NULL,
	receive_seq double precision NOT NULL,
	item_type_code char(2),
	description varchar(255),
	amount decimal(18,2),
	balance bigint,
	post_status char(1)
) ;
ALTER TABLE sc_crem_receive_return ADD PRIMARY KEY (membership_no,crem_code,receive_year,receive_month,receive_seq);
ALTER TABLE sc_crem_receive_return ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_crem_receive_return ALTER COLUMN crem_code SET NOT NULL;
ALTER TABLE sc_crem_receive_return ALTER COLUMN receive_year SET NOT NULL;
ALTER TABLE sc_crem_receive_return ALTER COLUMN receive_month SET NOT NULL;
ALTER TABLE sc_crem_receive_return ALTER COLUMN receive_seq SET NOT NULL;


