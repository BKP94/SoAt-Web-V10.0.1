CREATE TABLE sc_wef_dead_req (
	requestment_no char(15),
	membership_no char(7),
	operate_date timestamp,
	member_date timestamp,
	dead_date timestamp,
	pay_amount decimal(15,2),
	approve_status char(1),
	cancel_status char(1),
	approve_date timestamp,
	approve_id char(16),
	dead_doc_no char(15),
	remark_desc varchar(100),
	entry_id char(16),
	entry_date timestamp,
	entry_branch char(2),
	entry_clientid varchar(30),
	cancel_id char(16),
	cancel_date timestamp,
	cancel_branch char(2)
) ;


