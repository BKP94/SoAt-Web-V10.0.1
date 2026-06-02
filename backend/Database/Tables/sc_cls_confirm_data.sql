CREATE TABLE sc_cls_confirm_data (
	confirm_date timestamp NOT NULL,
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	data_group varchar(3),
	data_type varchar(6),
	data_balance decimal(15,2),
	data_monthly decimal(15,2),
	data_refno varchar(15),
	int_arr decimal(16,2),
	paycode varchar(6),
	loanshot decimal(16,2),
	loanlong decimal(16,2),
	loan_code char(1),
	entry_id varchar(16),
	entry_date timestamp
) ;
CREATE INDEX idx_cls_cfd_head ON sc_cls_confirm_data (confirm_date, membership_no);
ALTER TABLE sc_cls_confirm_data ADD PRIMARY KEY (confirm_date,membership_no,seq_no);


