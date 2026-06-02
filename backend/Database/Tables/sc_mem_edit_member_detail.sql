CREATE TABLE sc_mem_edit_member_detail (
	membership_no varchar(15) NOT NULL,
	seq_no bigint NOT NULL DEFAULT 0,
	column_name varchar(25),
	value_old varchar(50),
	value_new varchar(50),
	userid varchar(10),
	entry_date timestamp,
	branch_id varchar(6)
) ;
COMMENT ON TABLE sc_mem_edit_member_detail IS E'!NN!';
ALTER TABLE sc_mem_edit_member_detail ADD PRIMARY KEY (membership_no,seq_no);


