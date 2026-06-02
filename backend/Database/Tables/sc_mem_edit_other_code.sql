CREATE TABLE sc_mem_edit_other_code (
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	entry_br varchar(6) NOT NULL,
	operate_date timestamp NOT NULL,
	preother_code varchar(6) NOT NULL,
	other_code varchar(6) NOT NULL,
	remark varchar(100)
) ;
ALTER TABLE sc_mem_edit_other_code ADD PRIMARY KEY (membership_no,seq_no);
ALTER TABLE sc_mem_edit_other_code ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_edit_other_code ALTER COLUMN seq_no SET NOT NULL;
ALTER TABLE sc_mem_edit_other_code ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_mem_edit_other_code ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_mem_edit_other_code ALTER COLUMN entry_br SET NOT NULL;
ALTER TABLE sc_mem_edit_other_code ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_mem_edit_other_code ALTER COLUMN preother_code SET NOT NULL;
ALTER TABLE sc_mem_edit_other_code ALTER COLUMN other_code SET NOT NULL;


