CREATE TABLE sc_tmp_inv_bill_dued_date (
	bill_no varchar(15) NOT NULL,
	cal_int_date timestamp NOT NULL,
	period integer NOT NULL,
	op_date timestamp NOT NULL,
	interest decimal(15,2) NOT NULL,
	tax decimal(15,2) NOT NULL,
	pricipal decimal(15,2) NOT NULL,
	status char(1) NOT NULL,
	cal_int_date_real timestamp,
	op_date_real timestamp,
	interest_real decimal(15,2) DEFAULT 0.00,
	tax_real decimal(15,2) DEFAULT 0.00,
	principal_real decimal(15,2) DEFAULT 0.00,
	interest_rate decimal(15,8)
) ;
ALTER TABLE sc_tmp_inv_bill_dued_date ADD PRIMARY KEY (bill_no,cal_int_date);
ALTER TABLE sc_tmp_inv_bill_dued_date ALTER COLUMN bill_no SET NOT NULL;
ALTER TABLE sc_tmp_inv_bill_dued_date ALTER COLUMN cal_int_date SET NOT NULL;
ALTER TABLE sc_tmp_inv_bill_dued_date ALTER COLUMN period SET NOT NULL;
ALTER TABLE sc_tmp_inv_bill_dued_date ALTER COLUMN op_date SET NOT NULL;
ALTER TABLE sc_tmp_inv_bill_dued_date ALTER COLUMN interest SET NOT NULL;
ALTER TABLE sc_tmp_inv_bill_dued_date ALTER COLUMN tax SET NOT NULL;
ALTER TABLE sc_tmp_inv_bill_dued_date ALTER COLUMN pricipal SET NOT NULL;
ALTER TABLE sc_tmp_inv_bill_dued_date ALTER COLUMN status SET NOT NULL;


