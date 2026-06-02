CREATE TABLE sc_adm_tun_marry (
	pay_by varchar(50),
	marry_form_no varchar(9),
	membership_no varchar(7),
	marry_date timestamp,
	spouse_prename varchar(6),
	spouse_name varchar(50),
	money_date timestamp,
	account_no varchar(20),
	receive_prename varchar(6),
	receive_name varchar(50),
	receive_surname varchar(50),
	footnote varchar(50),
	entry_id varchar(10),
	entry_branch varchar(6),
	entry_date timestamp,
	request_date timestamp,
	pay_date timestamp,
	status char(1),
	detail_pay varchar(100),
	money_pay decimal(15,2),
	paid_entry_id varchar(50),
	paid_entry_date timestamp
) ;


