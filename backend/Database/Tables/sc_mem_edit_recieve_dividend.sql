CREATE TABLE sc_mem_edit_recieve_dividend (
	membership_no varchar(15) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	operate_date timestamp NOT NULL,
	pre_method_recieve_dividend varchar(3),
	method_recieve_dividend varchar(3),
	entry_br varchar(20)
) ;
ALTER TABLE sc_mem_edit_recieve_dividend ADD PRIMARY KEY (membership_no,entry_date);
ALTER TABLE sc_mem_edit_recieve_dividend ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_edit_recieve_dividend ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_mem_edit_recieve_dividend ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_mem_edit_recieve_dividend ALTER COLUMN operate_date SET NOT NULL;


