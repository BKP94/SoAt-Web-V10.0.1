CREATE TABLE sc_wef_superannuation_req (
	requestment_no char(15),
	membership_no char(7),
	operate_date timestamp,
	member_date timestamp,
	resign_work_date timestamp,
	pay_amount decimal(15,2),
	approve_status char(1),
	cancel_status char(1),
	approve_date timestamp,
	approve_id char(16),
	remark_desc varchar(100),
	entry_id char(16),
	entry_date timestamp,
	entry_branch char(2),
	entry_clientid varchar(30),
	cancel_id char(16),
	cancel_date timestamp,
	cancel_branch char(2),
	order_no varchar(100),
	money_type_id char(3),
	bank_code char(6),
	branch_code char(6),
	bank_acc_no char(20),
	age_text varchar(50)
) ;


