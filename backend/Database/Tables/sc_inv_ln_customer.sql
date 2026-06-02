CREATE TABLE sc_inv_ln_customer (
	customer_no varchar(7) NOT NULL,
	coop_reqistered_no varchar(15),
	cus_type varchar(6) NOT NULL,
	cus_name varchar(100),
	cus_address varchar(80),
	cus_road varchar(50),
	tambol varchar(50),
	district_code varchar(6),
	province_code varchar(6),
	postcode varchar(10),
	phonenumber varchar(50),
	local_region char(1),
	registereddate timestamp,
	signofapprove varchar(50),
	bankcode varchar(6),
	bankbranch varchar(6),
	bank_account_no varchar(15),
	free_of_transfer decimal(15,2),
	free_of_misssend decimal(15,2),
	entry_id varchar(16),
	entry_date timestamp,
	small_name varchar(15),
	remark varchar(50),
	email_address varchar(100),
	website_name varchar(100),
	contact_name varchar(70),
	contact_department varchar(70),
	contact_posittion varchar(50),
	contact_telephone varchar(50),
	fax_number varchar(25),
	bank_type_desc varchar(35),
	partofprovince char(1),
	bank_fin varchar(6),
	cus_group char(1),
	bank_trans_debt varchar(6),
	sign_condition varchar(50),
	sign_detail varchar(200)
) ;
ALTER TABLE sc_inv_ln_customer ADD PRIMARY KEY (customer_no);
ALTER TABLE sc_inv_ln_customer ALTER COLUMN customer_no SET NOT NULL;
ALTER TABLE sc_inv_ln_customer ALTER COLUMN cus_type SET NOT NULL;


