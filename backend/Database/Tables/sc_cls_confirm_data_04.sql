CREATE TABLE sc_cls_confirm_data_04 (
	confirm_date timestamp NOT NULL,
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	data_group varchar(3),
	data_type varchar(6),
	data_balance decimal(15,2),
	data_monthly decimal(15,2),
	data_refno varchar(15),
	loan_code char(1)
) ;
ALTER TABLE sc_cls_confirm_data_04 ADD PRIMARY KEY (confirm_date,membership_no,seq_no);
ALTER TABLE sc_cls_confirm_data_04 ALTER COLUMN confirm_date SET NOT NULL;
ALTER TABLE sc_cls_confirm_data_04 ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_cls_confirm_data_04 ALTER COLUMN seq_no SET NOT NULL;


