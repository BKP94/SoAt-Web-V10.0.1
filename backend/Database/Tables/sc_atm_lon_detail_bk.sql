CREATE TABLE sc_atm_lon_detail_bk (
	loan_contract_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	operate_date timestamp,
	item_type varchar(3),
	prin_amount decimal(15,2),
	fee_amount decimal(15,2),
	loan_balance decimal(15,2),
	approve_amount decimal(15,2),
	ref_sys_lon double precision,
	entry_id varchar(16),
	entry_date timestamp,
	entry_br varchar(6),
	entry_pc varchar(3),
	transaction_no varchar(8),
	terminal_lacation varchar(15),
	remark varchar(250)
) ;
CREATE UNIQUE INDEX sc_atm_lon_detail_x ON sc_atm_lon_detail_bk (loan_contract_no, seq_no);
ALTER TABLE sc_atm_lon_detail_bk ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_atm_lon_detail_bk ALTER COLUMN seq_no SET NOT NULL;


