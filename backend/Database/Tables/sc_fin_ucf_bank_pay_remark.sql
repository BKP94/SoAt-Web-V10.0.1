CREATE TABLE sc_fin_ucf_bank_pay_remark (
	seq_no integer NOT NULL,
	item_remark varchar(500),
	sort_order integer DEFAULT 0
) ;
ALTER TABLE sc_fin_ucf_bank_pay_remark ADD PRIMARY KEY (seq_no);
ALTER TABLE sc_fin_ucf_bank_pay_remark ALTER COLUMN seq_no SET NOT NULL;


