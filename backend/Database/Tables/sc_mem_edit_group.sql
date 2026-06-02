CREATE TABLE sc_mem_edit_group (
	membership_no varchar(15) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	operate_date timestamp NOT NULL,
	pre_member_group_no varchar(15),
	member_group_no varchar(15),
	entry_br varchar(6),
	doc_edit varchar(15)
) ;
ALTER TABLE sc_mem_edit_group ADD PRIMARY KEY (membership_no,entry_date);
ALTER TABLE sc_mem_edit_group ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_edit_group ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_mem_edit_group ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_mem_edit_group ALTER COLUMN operate_date SET NOT NULL;


