CREATE TABLE sc_lon_edit_atm (
	loan_contract_no varchar(15) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	entry_br varchar(6),
	operate_date timestamp NOT NULL,
	pre_new_send_status char(1),
	pre_modify_status char(1) NOT NULL,
	pre_close_status char(1),
	pre_current_account varchar(15),
	new_send_status char(1),
	modify_status char(1),
	close_status char(1),
	current_account varchar(15)
) ;
ALTER TABLE sc_lon_edit_atm ADD PRIMARY KEY (loan_contract_no,entry_date,pre_modify_status);
ALTER TABLE sc_lon_edit_atm ALTER COLUMN loan_contract_no SET NOT NULL;
ALTER TABLE sc_lon_edit_atm ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_lon_edit_atm ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_lon_edit_atm ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_lon_edit_atm ALTER COLUMN pre_modify_status SET NOT NULL;


