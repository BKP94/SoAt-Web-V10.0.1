CREATE TABLE sc_hr_off_salary_paid (
	official_no varchar(15) NOT NULL,
	year numeric(38) DEFAULT 0,
	month numeric(38) DEFAULT 0,
	operate_date timestamp,
	deposit_account_no varchar(15),
	salary_amount decimal(15,2) DEFAULT 0,
	salary_living decimal(15,2) DEFAULT 0,
	salary_special decimal(15,2) DEFAULT 0,
	social_security_amount decimal(15,2) DEFAULT 0,
	tax_amount decimal(15,2) DEFAULT 0,
	monthly_amount decimal(15,2) DEFAULT 0,
	salary_net decimal(15,2) DEFAULT 0,
	post_date timestamp,
	post_status char(1) DEFAULT '0',
	post_id varchar(16),
	entry_id varchar(16),
	entry_date timestamp,
	entry_branch varchar(6),
	entry_clientid varchar(30),
	vourcher_no varchar(15),
	cancel_vourcher_no varchar(15),
	otherpaid_amount decimal(15,2) DEFAULT 0,
	sal_year double precision NOT NULL DEFAULT 0,
	sal_month double precision NOT NULL DEFAULT 0,
	type_pay_salary char(3) DEFAULT 'TRD',
	bank_acc_no varchar(15),
	compensate_amount decimal(15,2) DEFAULT 0,
	employer_provided_amount decimal(15,2) DEFAULT 0,
	other_income decimal(15,2) DEFAULT 0,
	other_expense decimal(15,2) DEFAULT 0,
	salary_minus decimal(15,2) DEFAULT 0,
	trans_status char(1) DEFAULT '0',
	sasom_amt decimal(15,2) DEFAULT 0,
	bank_code varchar(6),
	student_loan_amount decimal(15,2) DEFAULT 0,
	overtime_pay decimal(16,2),
	amount_pro_fund double precision
) ;
ALTER TABLE sc_hr_off_salary_paid ADD PRIMARY KEY (official_no,sal_year,sal_month);
ALTER TABLE sc_hr_off_salary_paid ALTER COLUMN official_no SET NOT NULL;
ALTER TABLE sc_hr_off_salary_paid ALTER COLUMN sal_year SET NOT NULL;
ALTER TABLE sc_hr_off_salary_paid ALTER COLUMN sal_month SET NOT NULL;


