CREATE TABLE sc_mem_surminar (
	membership_no varchar(15) NOT NULL,
	seq_no double precision NOT NULL,
	operate timestamp,
	remark varchar(50)
) ;
ALTER TABLE sc_mem_surminar ADD PRIMARY KEY (membership_no,seq_no);
ALTER TABLE sc_mem_surminar ALTER COLUMN membership_no SET NOT NULL;
ALTER TABLE sc_mem_surminar ALTER COLUMN seq_no SET NOT NULL;


