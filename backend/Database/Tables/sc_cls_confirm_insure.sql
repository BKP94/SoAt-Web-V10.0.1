CREATE TABLE sc_cls_confirm_insure (
	confirm_date timestamp NOT NULL,
	insurance_no varchar(15) NOT NULL,
	insurance_type varchar(5),
	membership_no varchar(15) NOT NULL,
	protec_begin timestamp,
	protec_end timestamp,
	insurance_approve decimal(15,2),
	insurance_money_waiting decimal(15,2),
	insurance_balance decimal(15,2),
	insurance_money_wait_bal decimal(15,2),
	insurance_accumulate_money decimal(15,2),
	advan_amount decimal(15,2),
	receive_advance_date timestamp,
	paid_advance_date timestamp,
	insurance_status char(1),
	pay_status char(1),
	money_insur_status char(1),
	cancel_status char(1),
	start_keep_date timestamp,
	entry_date timestamp
) ;
ALTER TABLE sc_cls_confirm_insure ADD PRIMARY KEY (confirm_date,insurance_no,membership_no);


