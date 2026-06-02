CREATE TABLE sc_law_bang_kup_detail (
	prosec_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL DEFAULT 0,
	operate_date timestamp,
	operate_time timestamp,
	sesult_sale varchar(50),
	sale_amount decimal(15,2) DEFAULT 0,
	sale_amount_net decimal(15,2) DEFAULT 0,
	loan_balance decimal(15,2) DEFAULT 0,
	remark varchar(50),
	seq_no_yed double precision NOT NULL DEFAULT 0
) ;
ALTER TABLE sc_law_bang_kup_detail ADD PRIMARY KEY (prosec_no,seq_no,seq_no_yed);
ALTER TABLE sc_law_bang_kup_detail ALTER COLUMN prosec_no SET NOT NULL;
ALTER TABLE sc_law_bang_kup_detail ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_law_bang_kup_detail ALTER COLUMN seq_no_yed SET NOT NULL;


