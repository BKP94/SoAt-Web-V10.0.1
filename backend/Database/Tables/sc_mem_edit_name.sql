CREATE TABLE sc_mem_edit_name (
	membership_no varchar(15) NOT NULL,
	entry_date timestamp NOT NULL,
	entry_id varchar(16) NOT NULL,
	operate_date timestamp NOT NULL,
	pre_prename_code varchar(6),
	pre_member_name varchar(50),
	pre_member_surname varchar(50),
	prename_code varchar(6),
	member_name varchar(50),
	member_surname varchar(50),
	entry_br varchar(6),
	doc_edit varchar(15),
	pre_date_of_birth timestamp,
	date_of_birth timestamp,
	seq_no numeric(38) NOT NULL
) ;
ALTER TABLE sc_mem_edit_name ADD PRIMARY KEY (membership_no,entry_date,seq_no);
ALTER TABLE sc_mem_edit_name ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_edit_name ALTER COLUMN entry_date SET NOT NULL;
ALTER TABLE sc_mem_edit_name ALTER COLUMN entry_id SET NOT NULL;
ALTER TABLE sc_mem_edit_name ALTER COLUMN operate_date SET NOT NULL;
ALTER TABLE sc_mem_edit_name ALTER COLUMN seq_no SET NOT NULL;


