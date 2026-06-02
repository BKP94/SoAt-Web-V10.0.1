CREATE TABLE sc_mem_m_member_keeping (
	membership_no char(7),
	seq_no double precision,
	membership_child char(7),
	keep_type char(3),
	ref_no char(15),
	keep_amount decimal(15,2),
	status char(1),
	entry_id char(10),
	entry_date timestamp,
	entry_branch char(2),
	cancel_id char(10),
	cancel_date timestamp,
	cancel_branch char(2)
) ;


