CREATE TABLE sc_lon_loan_card_atm_detail_old (
	loan_contract_no char(15) NOT NULL,
	seq_no double precision NOT NULL,
	prin_amount decimal(15,2) NOT NULL,
	fee_amount decimal(15,2) NOT NULL,
	operate_date timestamp NOT NULL,
	item_type char(3) NOT NULL,
	city_code char(2),
	transaction_no char(8),
	terminal_number char(7),
	terminal_lacation char(15),
	entry_date timestamp NOT NULL,
	entry_id char(10) NOT NULL,
	client_name char(15) NOT NULL,
	limit_amount_last decimal(15,2),
	approve_amount decimal(15,2),
	balance decimal(15,2),
	remark char(100),
	operate_datetime timestamp,
	member_group_no char(15)
) ;
CREATE UNIQUE INDEX sc_lon_loan_card_atm_detail_x ON sc_lon_loan_card_atm_detail_old (loan_contract_no, seq_no);
ALTER TABLE sc_lon_loan_card_atm_detail_old ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_lon_loan_card_atm_detail_old ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_lon_loan_card_atm_detail_old ALTER COLUMN prin_amount SET NOT NULL;
ALTER TABLE sc_lon_loan_card_atm_detail_old ALTER COLUMN fee_amount SET NOT NULL;
ALTER TABLE sc_lon_loan_card_atm_detail_old ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_lon_loan_card_atm_detail_old ALTER COLUMN item_type SET NOT NULL;
ALTER TABLE sc_lon_loan_card_atm_detail_old ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_lon_loan_card_atm_detail_old ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_lon_loan_card_atm_detail_old ALTER COLUMN client_name SET NOT NULL;


