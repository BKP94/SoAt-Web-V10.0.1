CREATE TABLE sc_bill_recv_file_head (
	bank_fin varchar(6) NOT NULL,
	operate_date timestamp NOT NULL,
	item_no smallint NOT NULL DEFAULT 0,
	total_recode bigint DEFAULT 0,
	type_file varchar(6) DEFAULT '01',
	office_id varchar(16),
	analy_tot_success bigint,
	analy_tot_failure bigint,
	post_to_success bigint,
	file_name varchar(200),
	entry_date timestamp,
	entry_id varchar(16)
) ;
ALTER TABLE sc_bill_recv_file_head ADD PRIMARY KEY (bank_fin,operate_date,item_no);
ALTER TABLE sc_bill_recv_file_head ALTER COLUMN bank_fin SET NOT NULL;
ALTER TABLE sc_bill_recv_file_head ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_bill_recv_file_head ALTER COLUMN item_no SET NOT NULL;


