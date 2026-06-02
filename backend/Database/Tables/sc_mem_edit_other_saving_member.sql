CREATE TABLE sc_mem_edit_other_saving_member (
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	entry_br varchar(6) NOT NULL,
	operate_date timestamp NOT NULL,
	pre_other_saving_member varchar(6) NOT NULL,
	other_saving_member varchar(6) NOT NULL,
	remark varchar(100)
) ;
ALTER TABLE sc_mem_edit_other_saving_member ADD PRIMARY KEY (membership_no,seq_no);
ALTER TABLE sc_mem_edit_other_saving_member ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_edit_other_saving_member ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_mem_edit_other_saving_member ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_mem_edit_other_saving_member ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_mem_edit_other_saving_member ALTER COLUMN entry_br SET NOT NULL;
ALTER TABLE sc_mem_edit_other_saving_member ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_mem_edit_other_saving_member ALTER COLUMN pre_other_saving_member SET NOT NULL;
ALTER TABLE sc_mem_edit_other_saving_member ALTER COLUMN other_saving_member SET NOT NULL;


