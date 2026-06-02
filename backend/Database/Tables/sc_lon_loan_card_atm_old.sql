CREATE TABLE sc_lon_loan_card_atm_old (
	loan_contract_no char(15) NOT NULL,
	balance_send decimal(15,2) NOT NULL,
	send_last_date timestamp,
	bank_code char(6) NOT NULL,
	bank_acc_no char(10) NOT NULL,
	req_count double precision NOT NULL,
	new_send_status char(1) NOT NULL,
	modify_status char(1),
	approve_amount decimal(15,2),
	bank_branch char(6),
	send_last_no double precision,
	remark char(200)
) ;
ALTER TABLE sc_lon_loan_card_atm_old ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_lon_loan_card_atm_old ALTER COLUMN balance_send SET NOT NULL;
ALTER TABLE sc_lon_loan_card_atm_old ALTER COLUMN bank_code SET NOT NULL;
ALTER TABLE sc_lon_loan_card_atm_old ALTER COLUMN bank_acc_no SET NOT NULL;
ALTER TABLE sc_lon_loan_card_atm_old ALTER COLUMN req_count SET NOT NULL;
ALTER TABLE sc_lon_loan_card_atm_old ALTER COLUMN new_send_status SET NOT NULL;


